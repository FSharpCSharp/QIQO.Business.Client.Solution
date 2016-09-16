﻿using QIQO.Business.Module.Orders.ViewModels;
using System.Windows.Controls;

namespace QIQO.Business.Module.Orders.Views
{
    /// <summary>
    /// Interaction logic for OpenOrderView.xaml
    /// </summary>
    public partial class OpenOrderViewX : UserControl
    {
        public OpenOrderViewX(OpenOrderViewModelX view_model)
        {
            InitializeComponent();
            DataContext = view_model;
        }
    }
}
