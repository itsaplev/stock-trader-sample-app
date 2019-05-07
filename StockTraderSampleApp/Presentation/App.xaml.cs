using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Application;
using Application.DTO;
using Application.Service;
using AutoMapper;
using Domain.Aggregates;
using Infrastructure.Messaging;
using Microsoft.Practices.Unity;
using Persistance.Repository;
using Persistance.Repository.Stock;
using Presentation.ViewModel;
using Presentation.ViewModel.Observables;
using Presentation.Views;
using Application.Service;
using Application = System.Windows.Application;
using System.Globalization;
using System.Threading;

namespace Presentation
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");

            InitMapper();
            
            IUnityContainer container = new UnityContainer();

            var eventBus = new EventBus();
            container.RegisterInstance<IEventBus>(eventBus);
            container.RegisterInstance<IEventHandlersRegistry>(eventBus);
            
            container.RegisterInstance<IStockRepository>(new StockRepository());
            container.RegisterType<IStockService, StockService>();
            container.RegisterType<ITransactionsViewModel, TransactionsViewModel>();
            container.RegisterType<IMainViewModel, MainViewModel>();
            
            var changeMaker = container.Resolve<ChangesMaker>();
            var mainWindow = container.Resolve<MainView>(); 
            
            mainWindow.Show();
        }

        private void InitMapper()
        {
            Mapper.CreateMap<Stock, StockDTO>();
            Mapper.CreateMap<StockDTO, Stock>();
            Mapper.CreateMap<StockDTO, StockObservable>();
            Mapper.CreateMap<TransactionObservable, TransactionDTO>();
        }

    }
}
