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
        MainPageViewModel viewModel;
        public Panel(string login)
        {
            InitializeComponent();

            viewModel = new PanelViewModel(login);

            BindingContext = viewModel;
        }

    }
}