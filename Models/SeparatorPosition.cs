using SudExpertSU.Models.Positions;
using SudExpertSU.Views;

namespace SudExpertSU.Models
{
    class SeparatorPosition
    {
        private string Position;
        
        public SeparatorPosition(string position)
        {
            Position = position;
        }
        
        
        public IPosition SetType()
        {
            ///<returns>type of Position user</returns>
           
            switch (Position)
            {
                case "Администратор программной архитекруты":
                    return new SoftwareArchitectAdministrator();
                case "Эксперт":
                    return new MedicalExpert();
                case "gov.ru":
                    return new GovRu();
                default:
                    return null;
            }

        }
    }
}
