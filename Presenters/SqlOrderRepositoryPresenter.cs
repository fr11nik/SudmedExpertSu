using SudExpertSU.Models;
using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudExpertSU.Presenters
{
    class SqlOrderRepositoryPresenter
    {
        private IOrderSource View;
        
        public SqlOrderRepositoryPresenter(IOrderSource view)
        {
            View = view;
        }

        public void load(string queryString)
        {
            SqlOrderRepository sqlOrderRepository = new SqlOrderRepository();
            View.Data = sqlOrderRepository.load(queryString);
        }
        public void update(string queryString)
        {
            SqlOrderRepository sqlOrderRepository = new SqlOrderRepository();
            sqlOrderRepository.update(queryString);
        }
        public void insert(string queryString)
        {
            SqlOrderRepository sqlOrderRepository = new SqlOrderRepository();
            sqlOrderRepository.insert(queryString);
        }
        public void remove()
        {

        }
        public void UniversalUpdateChanges(string tablename, DataGridView dataGridView)
        {
            SqlOrderRepository sqlOrderRepository = new SqlOrderRepository();
            sqlOrderRepository.UniversalUpdateChanges(tablename, dataGridView);
        }
    }
}
