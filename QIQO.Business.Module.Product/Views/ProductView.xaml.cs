﻿using QIQO.Business.Module.Product.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QIQO.Business.Module.Product.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView(ProductViewModel view_model)
        {
            InitializeComponent();
            DataContext = view_model;
        }

        private void ImageBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            //dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ProductViewModel prod_viewmodel = this.DataContext as ProductViewModel;
                prod_viewmodel.Products[prod_viewmodel.SelectedProductIndex].ProductImagePath = filename;
            }
        }
    }
}
