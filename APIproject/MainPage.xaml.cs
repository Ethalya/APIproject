﻿using APIproject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.Login = "";
            viewModel.Password = "";
            entLogin.Text = "";
            entPass.Text = "";
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Login.Length > 0 && viewModel.Password.Length > 0)
            {
                var x = await viewModel.Logging();
                if (x != null)
                {
                    await Navigation.PushAsync(new Panel(x.name, x.album));
                }
                else
                {
                    await DisplayAlert("Sth bad happened", "Bad login or password!", "X");
                }
            }
            else
            {
                await DisplayAlert("Sth bad happened", "Don't leave anything empty", "X");
            }
        }

        private async void btnPortfolio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Portfolio());
        }

        private async void btnRegPanel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}