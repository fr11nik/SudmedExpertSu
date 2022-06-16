using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Views
{
    interface IUser
    {
        string login { get; set; }
        string password { get; set; }        
        bool AccesResult { get; set; }
    }
}
