using APIproject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Panel : ContentPage
    {
        PanelViewModel viewModel;
        public Panel(string _name, string _album)
        {
            InitializeComponent();

            viewModel = new PanelViewModel(_name, _album);

            BindingContext = viewModel;
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}