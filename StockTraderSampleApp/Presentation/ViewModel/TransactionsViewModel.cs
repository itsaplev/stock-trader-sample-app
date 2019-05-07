using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.DTO;
using Application.Service;
using AutoMapper;
using Infrastructure.Messaging;
using Persistance.Repository.Stock;
using Presentation.ViewModel.Base;
using Presentation.ViewModel.Observables;

namespace Presentation.ViewModel
{
    public class TransactionsViewModel: ObservableObject, ITransactionsViewModel
    {
        private readonly IStockService _stockService;

        private ObservableCollection<TransactionObservable> _transactions;
        public ObservableCollection<TransactionObservable> Transactions
        {
            get { return _transactions; }
            set
            {
                if (_transactions != value)
                {
                    OnPropertyChanging(() => Transactions);
                    _transactions = value;
                    OnPropertyChanged(() => Transactions);
                }
            }
        }

        public ICommand Submit { get; set; }
        public ICommand Cancel { get; set; }

        public ICommand SubmitAll { get; set; }
        public ICommand CancelAll { get; set; }


        public TransactionsViewModel(IStockService stockService) 
        {
            if (stockService == null)
            {
                throw new ArgumentException("stockService");
            }
            _stockService = stockService;

            _transactions = new ObservableCollection<TransactionObservable>();
            
            Submit = new DelegateCommand(SubmitExecute, SubmitCanExecute);
            SubmitAll = new DelegateCommand(SubmitAllExecute, SubmitAllCanExecute);
            Cancel = new DelegateCommand(CancelExecute, CancelCanExecute);
            CancelAll = new DelegateCommand(CancelAllExecute, CancelAllCanExecute);
        }

        #region Commands
        private bool SubmitCanExecute(object param)
        {
            return true;
        }
        private void SubmitExecute(object param)
        {
            var transaction = param as TransactionObservable;
            if (transaction != null)
            {
                var dto = Mapper.Map<TransactionDTO>(transaction);
                _stockService.SubmitTransaction(dto);
                Transactions.Remove(transaction);
            }
        }


        private bool CancelCanExecute(object param)
        {
            return true;
        }
        private void CancelExecute(object param)
        {
            var transaction = param as TransactionObservable;
            if (transaction != null)
            {
                Transactions.Remove(transaction);
            }
        }

        private bool CancelAllCanExecute(object param)
        {
            return true;
        }

        private void CancelAllExecute(object param)
        {
            Transactions.Clear();
        }

        private bool SubmitAllCanExecute(object param)
        {
            return true;
        }
        private void SubmitAllExecute(object param)
        {
            foreach (var t in Transactions)
            {
                var dto = Mapper.Map<TransactionDTO>(t);
                _stockService.SubmitTransaction(dto);
            }
            Transactions.Clear();
        }

        #endregion

        public void AddSellTransaction(StockObservable stock)
        {
            Transactions.Add(new TransactionObservable()
            {
                OrderType = TransactionOrderType.Limit,
                PriceLimit = 0,
                Shares = 0,
                Stock = stock,
                Term = TransactionTerm.EndOfDay,
                Type = TransactionType.Sell
            });
        }

        public void AddBuyTransaction(StockObservable stock)
        {
            Transactions.Add(new TransactionObservable()
            {
                OrderType = TransactionOrderType.Limit,
                PriceLimit = 0,
                Shares = 0,
                Stock = stock,
                Term = TransactionTerm.EndOfDay,
                Type = TransactionType.Buy
            });
        }
        
    }
}
