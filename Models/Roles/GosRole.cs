using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Models.Roles
{
    class GosRole : IRole
    {
        public string Name => "prev_gos_ru";

        public string ListOfAllowedTables => "Archive";
    }
}
