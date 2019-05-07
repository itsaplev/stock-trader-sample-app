using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Stock
{
    public interface IStockRepository: IRepository<Domain.Aggregates.Stock>
    {
    }
}
