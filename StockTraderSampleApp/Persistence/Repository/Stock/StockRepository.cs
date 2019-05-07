using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates;

namespace Persistance.Repository.Stock
{
    public class StockRepository : IStockRepository
    {
        private IList<Domain.Aggregates.Stock> _stocks;

        public StockRepository()
        {
            _stocks = new List<Domain.Aggregates.Stock>();
        }

        public Guid Add(Domain.Aggregates.Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException("stock");
            }
            stock.Id = Guid.NewGuid();
            _stocks.Add(stock);
            return stock.Id;
        }

        public void Remove(Guid id)
        {
            var stored = _stocks.FirstOrDefault(s => s.Id == id);
            if (stored != null)
            {
                _stocks.Remove(stored);
            }
        }

        public void Update(Domain.Aggregates.Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException("stock");
            }

            var stored = _stocks.FirstOrDefault(s => s.Id == stock.Id);
            if (stored != null)
            {
                var idx = _stocks.IndexOf(stored);
                if (idx >= 0)
                {
                    CopyValues(stored, stock);
                    _stocks[idx] = stored;
                }
            }
            else
            {
                throw new ArgumentException("You need to add object before update","stock");
            }
            
        }

        public IEnumerable<Domain.Aggregates.Stock> GetAll()
        {
            return _stocks;
        }

        public Domain.Aggregates.Stock Get(Guid id)
        {
            return _stocks.FirstOrDefault(s => s.Id == id);
        }

        private void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
    }
}
