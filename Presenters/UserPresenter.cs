using SudExpertSU.Models;
using SudExpertSU.Views;
using SudExpertSU.Forms;
namespace SudExpertSU.Presenters
{
    class UserPresenter
    {
        private UserModel UserModel;
        IUser User { get; set; }
        public UserPresenter(IUser user)
        {
            User = user;
        }
     
        public void Verify()
        {
            UserModel = new UserModel();

            UserModel.login = User.login;
            UserModel.password = User.password;
            UserModel.Verify();          
        }
        public void SetAcces()
        {
            User.AccesResult = UserModel.SetAccess();              
        }
        public void OpenManagmentMenu()
        {
            if (User.AccesResult == true)
            {               
                ManagmentForm managmentForm = new ManagmentForm(UserModel.Role);
                managmentForm.Show();
            }           
        }
    }
}
