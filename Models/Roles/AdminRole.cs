using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Models
{
    class AdminRole : IRole
    {
        public string Name { get; private set; } = "Администратор";
        public string QueryForLoadDataBase => "SELECT dbo.EmployeeData.id AS EmployeeDataID, dbo.EmployeeData.FName, dbo.EmployeeData.LName," +
             "dbo.EmployeeData.MiddleName, dbo.EmployeeData.Age, dbo.EmployeeData.Address,"+
                        "dbo.Departament.Name AS DepartamentName, dbo.Position.PositionName, dbo.EmployeeData.SnilsNumber, dbo.EmployeeData.PhoneNumber,"+ "dbo.EmployeeData.Gender"+
               " FROM dbo.Departament INNER JOIN"+
                        " dbo.Position ON dbo.Departament.id = dbo.Position.DepartamentId CROSS JOIN"+
                        " dbo.EmployeeData";
        public string ListOfAllowedTables { get; set; } = "Employee,EmployeeData,AccessControl,Position,Departament,AuthorizationData";
    }
}
