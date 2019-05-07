using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain.Aggregates;
using Infrastructure.Messaging;
using Persistance.Repository.Stock;
using Domain.Events;

namespace Application.Service
{
    public class StockService : IStockService
    {
        private readonly IEventBus _eventBus;
        private readonly IStockRepository _stockRepository;

        public StockService(IEventBus eventBus, IStockRepository stockRepository)
        {
            if (eventBus == null)
            {
                throw new ArgumentException("eventBus");
            }
            _eventBus = eventBus;

            if (stockRepository == null)
            {
                throw new ArgumentException("stockRepository");
            }
            _stockRepository = stockRepository;
        }

        public void AddStock(StockDTO stock)
        {
            var id =_stockRepository.Add(Mapper.Map<StockDTO,Stock>(stock));
            _eventBus.Publish(new StockAddedEvent(id));
        }

        public IEnumerable<StockDTO> GetAll()
        {
           return  Mapper.Map<IEnumerable<StockDTO>>(_stockRepository.GetAll());
        }

        public StockDTO Get(Guid id)
        {
            return Mapper.Map<StockDTO>(_stockRepository.Get(id));
        }

        public void SetMarketValueForStock(Guid id, float newValue)
        {
            var stock = _stockRepository.Get(id);
            if (stock != null)
            {
                stock.MarketValue = newValue;
                _stockRepository.Update(stock);
                _eventBus.Publish(new StockMarketValueChangedEvent(stock.Id, stock.MarketValue));
            }
        }


        public void SubmitTransaction(TransactionDTO transaction)
        {
            //do nothing
        }
    }
}
