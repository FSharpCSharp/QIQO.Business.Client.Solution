﻿using QIQO.Business.Module.Company.ViewModels;
using System.Windows.Controls;

namespace QIQO.Business.Module.Company.Views
{
    /// <summary>
    /// Interaction logic for CompanyNavigationView.xaml
    /// </summary>
    public partial class CompanyNavigationViewX : UserControl
    {
        public CompanyNavigationViewX(CompanyNavigationViewModelX view_model)
        {
            InitializeComponent();
            DataContext = view_model;
        }
    }
}
