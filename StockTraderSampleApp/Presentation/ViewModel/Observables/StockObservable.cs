using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using Persistance.Repository.Stock;
using Presentation.ViewModel.Base;


namespace Presentation.ViewModel.Observables
{
    [DisplayName("Stock")]
    public class StockObservable : ObservableObject
    {

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    OnPropertyChanging(() => Id);
                    _id = value;
                    OnPropertyChanged(() => Id);
                }
                
            }
        }
        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value != _symbol)
                {
                    OnPropertyChanging(() => Symbol);
                    _symbol = value;
                    OnPropertyChanged(() => Symbol);
                }

            }
        }
        private int _shares;
        public int Shares
        {
            get { return _shares; }
            set
            {
                if (value != _shares)
                {
                    OnPropertyChanging(() => Shares);
                    _shares = value;
                    OnPropertyChanged(() => Shares);
                }

            }
        }

        private float _last;
        [Category("Price")]
        public float Last
        {
            get { return _last; }
            set
            {
                if (value != _last)
                {
                    OnPropertyChanging(() => Last);
                    _last = value;
                    OnPropertyChanged(() => Last);
                }

            }
        }

        private float _costBasis;
        [Category("Price")]
        [DisplayName("Cost Basis")]
        public float CostBasis
        {
            get { return _costBasis; }
            set
            {
                if (value != _costBasis)
                {
                    OnPropertyChanging(() => CostBasis);
                    _costBasis = value;
                    OnPropertyChanged(() => CostBasis);
                }

            }
        }

        private float _marketValue;
        [Category("Price")]
        [DisplayName("Market Value")]
        public float MarketValue
        {
            get { return _marketValue; }
            set
            {
                if (value != _marketValue)
                {
                    OnPropertyChanging(() => MarketValue);
                    _marketValue = value;
                    OnPropertyChanged(() => MarketValue);
                }

            }
        }

        private string name;
        [Browsable(false)] //fix for property grid warning message
        public string Name
        {
            get { return this.name; }
            set { this.name = value; OnPropertyChanged(() => this.Name); }
        }

    }
}
