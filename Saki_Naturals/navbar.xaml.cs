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

namespace Saki_Naturals
{
    /// <summary>
    /// Interaction logic for navbar.xaml
    /// </summary>
    public partial class navbar : UserControl
    {
        public event EventHandler<NavButtonEventArg>? NavButtonClicked = null;

        public navbar()
        {
            InitializeComponent();
        }

        private void navButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine((sender as Button).Name);
            String navButtonClickedName = (sender as Button).Name;

            System.Diagnostics.Debug.WriteLine("Outside Event emitter : ", navButtonClickedName);
            EventHandler<NavButtonEventArg>? navButtonClicked = NavButtonClicked;
            navButtonClicked?.Invoke(this, new NavButtonEventArg(navButtonClickedName));
        }

        public class NavButtonEventArg : EventArgs
        {
            public string NavButtonName { get; set; }

            public NavButtonEventArg(string navButtonName)
            {
                this.NavButtonName = navButtonName;
                System.Diagnostics.Debug.WriteLine("Inside Constructor : ",this.NavButtonName);
            }
        }
    }
}
