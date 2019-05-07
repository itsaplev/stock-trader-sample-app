using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using Application.Service;
using AutoMapper;
using Domain.Aggregates;
using Persistance.Repository.Stock;

namespace Application
{
    public class ChangesMaker
    {
        private readonly IStockService _service;
        private readonly Random _random = new Random();
        private readonly Timer _timer;
        public ChangesMaker(IStockService service)
        {
            if (service == null)
            {
                throw  new ArgumentNullException("service");
            }
            _service = service;
            AddStocks();
            _timer = new Timer(TimerTick, null, 0, 1000);
            
        }

        private void TimerTick(object state)
        {
            var stocks = _service.GetAll();
            foreach (var s in stocks)
            {
                _service.SetMarketValueForStock(s.Id, _random.Next(10) + 1);
            }
        }

        private void AddStocks()
        {
            for (var i = 0; i < 15; i++)
            {
                var symbol = string.Concat("STOCK", i.ToString());
                var stock = CreateNewStock(symbol);
                _service.AddStock(Mapper.Map<StockDTO>(stock));
            }
        }

        private Stock CreateNewStock(string symbol)
        {
            return new Stock()
            {
                Id = Guid.NewGuid(),
                CostBasis = _random.Next(10) + 1,
                Last = _random.Next(10) + 1,
                MarketValue = _random.Next(10) + 1,
                Shares = _random.Next(10) + 1,
                Symbol = symbol
            };
        }

      
    }
}
