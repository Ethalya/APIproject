using APIproject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APIproject.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public MainPageViewModel()
        {
            Login = "";
            Password = "";
        }

        public async Task<bool> Register()
        {
            User user = new User() { login = Login, password = Password };

            try
            {
                return await Data.Login(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }
    }
}
