using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Unity;
using Presentation.ViewModel;

namespace Presentation.Views
{
    public partial class MainView : Window
    {
        [Dependency]
        public IMainViewModel ViewModel
        {
            set
            {
                DataContext = value;
            }
        }
        public MainView()
        {
            InitializeComponent();
        }
    }
}
