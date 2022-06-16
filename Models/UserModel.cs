
using SudExpertSU.Presenters;
using SudExpertSU.Views;
using System.Data;
using System.Windows.Forms;

namespace SudExpertSU.Models
{
    class UserModel: IOrderSource
    {
        public string login { get; set; }

        public string password { get; set; }

        public IRole Role { get; set; }

        public IPosition Position { get; set; }
        public DataTable Data { get; set; }

        //role based authentication

        

        public void Verify()
        {
            VerifyModel verifyModel = new VerifyModel(this);
            if(verifyModel.result == true)
            {
                MessageBox.Show("Вход произведен успешно");
            }
            else MessageBox.Show("Ошибка входа");
        }
        public bool SetAccess()
        {
            SqlOrderRepositoryPresenter sqlOrderRepository = new SqlOrderRepositoryPresenter(this);
            string queryString = "SELECT  AuthorizationData.Login, AuthorizationData.Password, AccessControl.accessName, Position.PositionName"+
            " FROM AccessControl INNER JOIN"+
                         " AuthorizationData ON AccessControl.id = AuthorizationData.AccesCode INNER JOIN"+
                         " Position ON AccessControl.positionId = Position.id"+
                        $" where Login = '{login}' and Password = '{password}'";
           
            sqlOrderRepository.load(queryString);
            if (Data.Rows.Count >= 1)
            {
                SeparatorPosition separatorPosition = new SeparatorPosition((string)Data.Rows[0]["PositionName"]);
                SeparatorRoles separatorRoles = new SeparatorRoles((string)Data.Rows[0]["accessName"]);
                Position = separatorPosition.SetType();
                Role = separatorRoles.SetType();
                return true;
            }
            return false;
           
        }      
    }
}
