using SudExpertSU.Models.Roles;
using SudExpertSU.Views;

namespace SudExpertSU.Models
{
    class SeparatorRoles
    {
        private string Role;
        public SeparatorRoles(string role)
        {
            Role = role;
        }
        public IRole SetType()
        {
            switch (Role)
            {
                case "Администратор":
                    return new AdminRole();
                case "Судмедэкспертиза":
                    return new ForensicMedicalExamination();
                case "prev_gos_ru":
                    return new GosRole();
                default:
                    return null;                                    
            }
           
        }
    }
}
