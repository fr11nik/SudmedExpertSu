using SudExpertSU.Presenters;
using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Models
{
    class VerifyModel : IOrderSource
    {
       public bool result { get; set; }
        public DataTable Data { get; set; }

        public VerifyModel(UserModel user)
        {
            SqlOrderRepositoryPresenter repositoryPresenter = new SqlOrderRepositoryPresenter(this);
            repositoryPresenter.load($"select * from AuthorizationData where login = '{user.login}' and password = '{user.password}'");       
            if(Data != null)
            result = Data.Rows.Count > 0;
        }
    }
}
