using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Diagnostics;

using Saki_Naturals.DB;
using Saki_Naturals.Models;
using System.ComponentModel;

namespace Saki_Naturals
{
    /// <summary>
    /// Interaction logic for products_page.xaml
    /// </summary>
    public partial class products_page : UserControl
    {
        public string[] listOfStrings = { "Sharan", "Kumar", "Shanthosh" };
        public List<ProductDataClass> productList = new List<ProductDataClass>();
        public ProductDataClass tempProductData;

        BindingProductData productData;
        public BindingProductData ProductData { get { return productData; } }

        public products_page()
        {
            InitializeComponent();

            ProductUserControl.Width = Application.Current.MainWindow.Width;
            ProductUserControl.Height = Application.Current.MainWindow.Height * 0.90;

            //this.productList.Add(new DataClasses.ProductDataClass("Soap", "Chocolate", "Big Soap"));
            //this.productList.Add(new DataClasses.ProductDataClass("Soap", "Chocolate", "Big Soap"));

            productData = new BindingProductData();
            this.DataContext = this;

            this.tempProductData = new ProductDataClass(cmbBoxGroup.SelectedValue == null ? "No Value" : cmbBoxGroup.SelectedValue.ToString(),
                                                                    txtBoxProductName.Text,
                                                                    txtBoxProductDescription.Text,
                                                                    int.Parse(txtBoxCurrentStock.Text == "" ? "0" : txtBoxCurrentStock.Text),
                                                                    decimal.Parse(txtBoxPriceDirectSale.Text == "" ? "0.0" : txtBoxPriceDirectSale.Text),
                                                                    decimal.Parse(txtBoxPriceReseller.Text == "" ? "0.0" : txtBoxPriceReseller.Text),
                                                                    decimal.Parse(txtBoxPriceDealer.Text == "" ? "0.0" : txtBoxPriceDealer.Text),
                                                                    DateTime.Now,
                                                                    int.Parse(txtBoxSold.Text == "" ? "0" : txtBoxSold.Text));

            //SampleListView.ItemsSource = this.productList;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            //SampleListView.ItemsSource = DataBaseService.getAllProductsData();
            PopupAddProduct.IsOpen = true;
            ProductUserControl.IsEnabled = false;
        }

        private void btnCancelPopUp_Click(object sender, RoutedEventArgs e)
        {
            PopupAddProduct.IsOpen = false;
            ProductUserControl.IsEnabled = true;

            this.ProductData.ProductName = "";
            this.ProductData.Group = "";
        }

        private void btnAddProductPopUp_Click(object sender, RoutedEventArgs e)
        {
            string validate = this.addProductValidation();

            if (validate != "")
            {
                PopupAddProduct.IsOpen = false;
                MessageBoxResult res = MessageBox.Show(validate, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (res == MessageBoxResult.OK)
                {
                    PopupAddProduct.IsOpen = true;
                }
            } 
            else
            {
                updateProductTable();
            }

        }

        private void updateProductTable()
        {
            ProductDataClass updatedProductData = new ProductDataClass((cmbBoxGroup.SelectedItem as ComboBoxItem).Content.ToString(),
                                                                        this.ProductData.ProductName,
                                                                        this.ProductData.Description,
                                                                        this.ProductData.Stock,
                                                                        this.ProductData.PriceDirectSale,
                                                                        this.ProductData.PriceReseller,
                                                                        this.ProductData.PriceDealer,
                                                                        DateTime.Now,
                                                                        this.ProductData.Sold);
            PopupAddProduct.IsOpen = false;

            try
            {
                
                DataBaseService.insertProductData(updatedProductData);
                MessageBox.Show("New Product added succesfully", "Update Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                
                ProductUserControl.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Products Table Update Error : {ex.Message}");
                MessageBoxResult res = MessageBox.Show("Unable to add new Product. Something went wrong", "Update error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (res == MessageBoxResult.OK)
                {
                    PopupAddProduct.IsOpen = true;
                }
            }
            
        }

        private string addProductValidation()
        {
            string errorMessage = "";
            
            if (string.IsNullOrEmpty(this.ProductData.Group))
            {
                errorMessage += "Select a Valid Group\n\n";
            }

            if (decimal.Parse(txtBoxCurrentStock.Text) % 1 != 0)
            {
                errorMessage += "Current stock cannot be decimal value\n\n";
            }

            if (decimal.Parse(txtBoxSold.Text) % 1 != 0)
            {
                errorMessage += "Sold units cannot be decimal value\n\n";
            }

            if (string.IsNullOrEmpty(this.ProductData.ProductName))
            {
                errorMessage += "Enter a Valid Product Name\n\n";
            }

            if (string.IsNullOrEmpty(this.ProductData.Description))
            {
                errorMessage += "Enter a Valid Product Description\n\n";
            }

            if ((this.ProductData.PriceDealer <= 0) || (this.ProductData.PriceDirectSale <= 0) || (this.ProductData.PriceReseller <= 0))
            {
                errorMessage += "Price cannot be zero or less than zero\n\n";
            }


            return errorMessage;
        }

    }
}
