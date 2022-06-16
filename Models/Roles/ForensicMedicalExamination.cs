using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Models.Roles
{
    class ForensicMedicalExamination : IRole
    {
        public string Name => "Судмедэкспертиза";

        public string ListOfAllowedTables => "MaterialList,Material,ExpertiseResult,Archive";
    }
}
