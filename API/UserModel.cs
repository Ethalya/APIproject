using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class UserModel
    {
        public int? id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string album { get; set; }
    }
}