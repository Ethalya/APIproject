using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APIproject.ViewModels
{
    public class PanelViewModel
    {

        public string Name { get; set; }
        public string Album { get; set; }

        public PanelViewModel(string _name, string _album)
        {
            Name = _name;

            Album = _album;
        }

    }
}