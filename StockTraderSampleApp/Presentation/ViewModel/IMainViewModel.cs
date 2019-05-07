using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModel.Observables;

namespace Presentation.ViewModel
{
    public interface IMainViewModel
    {
        ObservableCollection<StockObservable> StocksCollection { get; }
    }
}
