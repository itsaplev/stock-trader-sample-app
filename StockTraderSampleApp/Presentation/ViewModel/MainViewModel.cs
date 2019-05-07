using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Service;
using AutoMapper;
using Infrastructure.Messaging;
using Microsoft.Practices.Unity;
using Persistance.Repository.Stock;
using Presentation.ViewModel.Base;
using Presentation.ViewModel.Observables;
using Domain.Events;

namespace Presentation.ViewModel
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        #region Properties

        private readonly IStockService _stockService;
        private readonly IEventHandlersRegistry _eventHandlersRegistry;

        private ObservableCollection<StockObservable> _stocksCollection;
        public ObservableCollection<StockObservable> StocksCollection
        {
            get { return _stocksCollection; }
            set
            {
                if (_stocksCollection != value)
                {
                    OnPropertyChanging(() => StocksCollection);
                    _stocksCollection = value;
                    OnPropertyChanged(() => StocksCollection);
                }
            }
        }

        private ITransactionsViewModel _transactionsViewModel;
        [Dependency]
        public ITransactionsViewModel TransactionsViewModel
        {
            get { return _transactionsViewModel; }
            set
            {
                if (value != _transactionsViewModel)
                {
                    OnPropertyChanging(()=> TransactionsViewModel);
                    _transactionsViewModel = value;
                    OnPropertyChanged(()=> TransactionsViewModel);
                }
            }
        }

        public ICommand Buy { get; set; }
        public ICommand Sell { get; set; }

        #endregion 

        public MainViewModel(IStockService stockService, IEventHandlersRegistry eventHandlersRegistry)
        {
            if (stockService == null)
            {
                throw new ArgumentException("stockService");
            }
            if (eventHandlersRegistry == null)
            {
                throw new ArgumentException("eventBus");
            }
            _stockService = stockService;
            _stocksCollection =
                new ObservableCollection<StockObservable>(
                    Mapper.Map<IEnumerable<StockObservable>>(_stockService.GetAll()));

            _eventHandlersRegistry = eventHandlersRegistry;
            _eventHandlersRegistry.Register(typeof(StockAddedEvent), OnStockAdded);
            _eventHandlersRegistry.Register(typeof(StockMarketValueChangedEvent), OnStockMarketValueChanged);

            Buy = new DelegateCommand(BuyCommandExecute);
            Sell = new DelegateCommand(SellCommandExecute);
        }

        #region Commands
        private void BuyCommandExecute(object param)
        {
            var stock = param as StockObservable;
            if (stock != null && TransactionsViewModel != null)
            {
                TransactionsViewModel.AddBuyTransaction(stock);
            }
        }
        private void SellCommandExecute(object param)
        {
            var stock = param as StockObservable;
            if (stock != null && TransactionsViewModel != null)
            {
               TransactionsViewModel.AddSellTransaction(stock);
            }
        }

        #endregion

        #region Event Handlers
        private void OnStockAdded(IEvent @event)
        {
            var evt = @event as StockAddedEvent;
            var newStock = _stockService.Get(evt.StockId);
            if (newStock != null)
            {
                _stocksCollection.Add(Mapper.Map<StockObservable>(newStock));
            }
        }
        private void OnStockMarketValueChanged(IEvent @event)
        {
            var evt = @event as StockMarketValueChangedEvent;
            var stock = StocksCollection.FirstOrDefault(s => s.Id == evt.StockId);
            if (stock != null)
            {
                stock.MarketValue = evt.MarketValue;
            }
        }

        #endregion
    }
}
