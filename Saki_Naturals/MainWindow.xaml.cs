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
using static Saki_Naturals.navbar;
namespace Saki_Naturals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContentControl productsPage;
        public ContentControl salesPage;
        public MainWindow()
        {
            InitializeComponent();

            this.productsPage = new products_page();
            this.salesPage = new sales_page();

        }

        private void navbar_NavButtonClicked(object sender, NavButtonEventArg e)
        {
           System.Diagnostics.Debug.WriteLine(e.NavButtonName);

            switch (e.NavButtonName)
            {
                case "productsNavButton":
                    content_page.Content = this.productsPage;
                    break;

                case "salesNavButton":
                    content_page.Content = this.salesPage;
                    break;
            }
        }
    }
}
