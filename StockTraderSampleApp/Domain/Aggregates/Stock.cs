using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Aggregates
{
    public class Stock: IEntity
    {
        public Guid Id { get; set; }
        public string Symbol  { get; set; }
        public int Shares  { get; set; }
        public float Last { get; set; }
        public float CostBasis { get; set; }
        public float MarketValue { get; set; }
    }
}
