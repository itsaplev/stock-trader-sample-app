﻿using System;
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

namespace Presentation.Views
{
    /// <summary>
    /// Логика взаимодействия для TransactionsView.xaml
    /// </summary>
    public partial class TransactionsView : UserControl
    {
        public TransactionsView()
        {
            InitializeComponent();
        }

        private void ExpanderHeaderGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            Grid rootElem = sender as Grid;

            ContentPresenter contentPres = rootElem.TemplatedParent as ContentPresenter;

            contentPres.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
    }
}
