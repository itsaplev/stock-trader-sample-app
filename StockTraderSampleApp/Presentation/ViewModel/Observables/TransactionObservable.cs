using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModel.Base;

namespace Presentation.ViewModel.Observables
{
    public enum TransactionType
    {
        Buy = 0,
        Sell = 1, 
    }
    public enum TransactionOrderType
    {
        Market = 0,
        Limit = 1,
    }

    public enum TransactionTerm
    {
        [Display(Name="End Of Day")]
        EndOfDay = 0,
    }

    public class TransactionObservable : ObservableObject
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

        private TransactionType _transactionType;
        public TransactionType Type
        {
            get { return _transactionType; }
            set
            {
                if (value != _transactionType)
                {
                    OnPropertyChanging(()=> Type);
                    _transactionType = value;
                    OnPropertyChanged(()=>Type);

                }
            }
        }

        private TransactionOrderType _transactionOrderType;
        public TransactionOrderType OrderType
        {
            get { return _transactionOrderType; }
            set
            {
                if (value != _transactionOrderType)
                {
                    OnPropertyChanging(() => OrderType);
                    _transactionOrderType = value;
                    OnPropertyChanged(() => OrderType);

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

        private decimal _priceLimit;
        public decimal PriceLimit
        {
            get { return _priceLimit; }
            set
            {
                if (value != _priceLimit)
                {
                    OnPropertyChanging(() => PriceLimit);
                    _priceLimit = value;
                    OnPropertyChanged(() => PriceLimit);

                }
            }
        }

        private TransactionTerm _transactionTerm;
        public TransactionTerm Term
        {
            get { return _transactionTerm; }
            set
            {
                if (value != _transactionTerm)
                {
                    OnPropertyChanging(() => Term);
                    _transactionTerm = value;
                    OnPropertyChanged(() => Term);

                }
            }
        }

        private StockObservable _stock;
        public StockObservable Stock
        {
            get { return _stock; }
            set
            {
                if (value != _stock)
                {
                    OnPropertyChanging(() => Stock);
                    _stock = value;
                    OnPropertyChanged(() => Stock);

                }
            }
        }
    }
}
