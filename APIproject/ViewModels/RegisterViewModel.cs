using APIproject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace APIproject.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }

        public RegisterViewModel()
        {

            Login = "";
            Password = "";
            PasswordRepeat = "";
        }

        public async Task<bool> Register()
        {
            User user = new User() { login = Login, password = Password };

            try
            {
                return await Data.Register(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }
    }
}
