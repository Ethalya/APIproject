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
    public partial class Register : ContentPage
    {
        RegisterViewModel viewModel;
        public Register()
        {
            InitializeComponent();

            viewModel = new RegisterViewModel();

            BindingContext = viewModel;
        }

        private async Task btnRegister_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Login.Length > 0 && viewModel.Password.Length > 0 && (viewModel.Password == viewModel.PasswordRepeat))
            {
                var odpowiedz = await viewModel.Register();
                if (odpowiedz)
                {
                    await DisplayAlert("Sth happened", "Done", "X");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Sth bad happened", "Login taken", "X");
                }
            }
            else
            {
                await DisplayAlert("Sth bad happened", "Something is empty or password doesn't match", "X");
            }
        }

        private async Task btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}