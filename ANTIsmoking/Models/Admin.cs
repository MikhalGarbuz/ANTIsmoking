using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTIsmoking.Models
{
    public class Admin
    {
        public string name { get; set; }
        public string password { get; set; }
        public bool IsAdmin(string _name, string _password)
        {
            if (_name == name && _password == password)
                return true;
            return false;
        }

    }
}
