using System;
using System.Collections.Generic;
using System.Text;

namespace APIproject.Models
{
    public class User
    {
        public int? id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string album { get; set; }
    }
}
