using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Persistance.Repository.Stock;

namespace Application.Service
{
    public interface IStockService
    {
        void AddStock(StockDTO stock);
        IEnumerable<StockDTO> GetAll();
        StockDTO Get(Guid id);

        void SetMarketValueForStock(Guid id, float newValue);

        void SubmitTransaction(TransactionDTO transaction);

    }
}
