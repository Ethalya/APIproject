using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APIproject.ViewModels
{
    public class PanelViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public string login { get; set; }

        public Command LoadCommand { get; set; }
        public PanelViewModel(string _login)
        {
            login = _login;

            Items = new ObservableCollection<string>();

            LoadCommand = new Command(async () => await Load());
        }

        async Task Load()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await Data.RegisteredUsers();

                foreach (var item in items)
                {
                    if (!item.Equals(login))
                        Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {

                IsBusy = false;
            }
        }
    }
}
