using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APIproject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public ICommand regPanel
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage = new Register();
                });
            }
        }

        private void btnLogIn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Panel();
        }

        private void btnPortfolio_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Portfolio();
        }
    }
}
