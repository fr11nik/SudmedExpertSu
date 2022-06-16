using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SudExpertSU.Models
{
    class SqlOrderRepository
    {
        private string connectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=SudExpertSU;Integrated Security=true;";      
        private SqlConnection connection;

        private void openConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        private void closeConnection()
        {
            connection.Close();
            connection.Dispose();           
        }
        public DataTable load(string queryString)
        {
            openConnection();
            SqlCommand commandLoad = new SqlCommand(queryString, connection);
            DataSet dataSet = new DataSet();
            try
            { 
                commandLoad.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandLoad);
                sqlDataAdapter.Fill(dataSet);
            }
            catch (SqlException msg)
            {
                MessageBox.Show("Запрос не корректен ошибка:" + msg.Message);
                return null;
            }
            closeConnection();
            return dataSet.Tables[0];

        }
        public void update(string queryString)
        {
            openConnection();

            try
            {
                SqlCommand commandUpdate = new SqlCommand(queryString, connection);
                commandUpdate.ExecuteNonQuery();
            }
            catch (SqlException msg)
            {
                MessageBox.Show(msg.Message);
            }
            closeConnection();
        }
        public void insert(string queryString)
        {
            openConnection();
            
            try
            {
                SqlCommand commandInsert = new SqlCommand(queryString, connection);
                if (commandInsert.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("строка успешно вставлена");
                }
                
            }
            catch (SqlException msg)
            {
                MessageBox.Show(msg.Message);
            }
            closeConnection();
           
        }
        public void remove()
        {

        }

        public void UniversalUpdateChanges(string tablename,DataGridView dataGridView)
        {
            openConnection();
            try
            {             
                SqlCommand commandLoad = new SqlCommand($"select * from {tablename}", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandLoad);
                DataTable changes = ((DataTable)dataGridView.DataSource).GetChanges();
                if (changes != null)
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(sqlDataAdapter);
                    sqlDataAdapter.UpdateCommand = scb.GetUpdateCommand();
                    sqlDataAdapter.Update(changes);
                    ((DataTable)dataGridView.DataSource).AcceptChanges();
                    MessageBox.Show("Значения обновленны");
                    return;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message); 
            }
            closeConnection();
        }

       
    }
}
