using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Views
{
    public interface IRole
    {
        string Name { get; }
        
        string ListOfAllowedTables { get; }
    }
}
