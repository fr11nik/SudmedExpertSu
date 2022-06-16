using SudExpertSU.Forms;
using SudExpertSU.Presenters;
using SudExpertSU.Views;
using System;
using System.Windows.Forms;

namespace SudExpertSU
{
    public partial class LoginForm : Form, IUser
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string login { get => textBox1.Text; set => textBox1.Text = value; }
        public string password { get => textBox2.Text; set => textBox2.Text = value; }
        public bool AccesResult { get; set; }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            UserPresenter userPresenter = new UserPresenter(this);
            userPresenter.Verify();
            userPresenter.SetAcces();
            userPresenter.OpenManagmentMenu();
            
        }
    }
}
