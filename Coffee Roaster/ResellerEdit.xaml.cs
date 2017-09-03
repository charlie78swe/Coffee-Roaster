using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Coffee_Roaster
{
    public sealed partial class ResellerEdit : UserControl
    {
        DataHolders.Reseller mReseller;

        public ResellerEdit()
        {
            this.InitializeComponent();

            mReseller = new DataHolders.Reseller();

            mainPanel.DataContext = mReseller;
            mReseller.Name = "testar";
            mReseller.Rating = 1;
            
        }
        
        DataHolders.Reseller Reseller
        {
            get { return mReseller; }
            set { mReseller = value; }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //.Text = "men hallå";
        }
    }
}
