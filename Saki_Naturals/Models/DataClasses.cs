using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saki_Naturals.Models
{
    public class ProductDataClass
    {
        public int Id { get; set; }
        public string group { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public decimal priceDirectSale { get; set; }
        public decimal priceReseller { get; set; }
        public decimal priceDealer { get; set; }
        public DateTime createdDate { get; set; }
        public int sold { get; set; }

        public ProductDataClass(String Group,
                                String ProductName,
                                String Description,
                                int stock,
                                decimal priceDirectSale,
                                decimal priceReseller,
                                decimal priceDealer,
                                DateTime created_date,
                                int sold)
        {
            this.group = Group;
            this.productName = ProductName;
            this.description = Description;
            this.stock = stock;
            this.priceDirectSale = priceDirectSale;
            this.priceReseller = priceReseller;
            this.priceDealer = priceDealer;
            this.createdDate = created_date;
            this.sold = sold;
        }
    }

    public class BindingProductData : INotifyPropertyChanged
    {
        public BindingProductData()
        {

        }

        public int Id { get; set; }

        private string group;
        public string Group
        {
            get { return group; }
            set
            {
                if (value == group) return;
                group = value;
                this.OnPropertyChanged("Group");
            }
        }


        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (value == productName) return;
                productName = value;
                this.OnPropertyChanged("ProductName");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value == description) return;
                description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value == stock) return;
                stock = value;
                this.OnPropertyChanged("Stock");
            }
        }

        private decimal priceDirectSale;
        public decimal PriceDirectSale
        {
            get { return priceDirectSale; }
            set
            {
                if (value == priceDirectSale) return;
                priceDirectSale = value;
                this.OnPropertyChanged("PriceDirectSale");
            }
        }

        private decimal priceReseller;
        public decimal PriceReseller
        {
            get { return priceReseller; }
            set
            {
                if (value == priceReseller) return;
                priceReseller = value;
                this.OnPropertyChanged("PriceReseller");
            }
        }

        private decimal priceDealer;
        public decimal PriceDealer
        {
            get { return priceDealer; }
            set
            {
                if (value == priceDealer) return;
                priceDealer = value;
                this.OnPropertyChanged("PriceDealer");
            }
        }

        public DateTime createdDate { get; set; }

        private int sold;
        public int Sold
        {
            get { return sold; }
            set
            {
                if (value == sold) return;
                sold = value;
                this.OnPropertyChanged("Sold");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
