using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudExpertSU.Forms;
using SudExpertSU.Presenters;
using SudExpertSU.Views;
using System.Data.SqlClient;

namespace SudExpertSU.Components
{
    public partial class TableData : UserControl , IOrderSource
    {
        
        public IRole Role { get; }
        private string PreviousValue;
        private DataGridViewRow dataGridViewRow;
        private string TableName;
        public TableData(IRole role)
        {          
            InitializeComponent();
            Role = role;
            comboBox1.Items.AddRange(Role.ListOfAllowedTables.Split(','));
            comboBox1.Text = comboBox1.Items[0].ToString();
            LoadTable(comboBox1.Items[0].ToString());
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }
        /// <ezShowCurrentRowChnge>
        /// dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        /// </summary>
        public DataTable Data { get; set; }

        private void LoadTable(string tableName)
        {

            SqlOrderRepositoryPresenter sqlOrderRepositoryPresenter = new SqlOrderRepositoryPresenter(this);
            sqlOrderRepositoryPresenter.load($"select * from {tableName}");
            dataGridView1.DataSource = Data;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridViewRow = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            FillDGVREmptyCells(dataGridViewRow);
            //dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            //dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;

        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string idValue = "";
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != null)
            {
                 idValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            if (PreviousValue != "" && idValue != "" && dataGridView1.Columns[e.ColumnIndex].Name!="Byte[]")
            {
               
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                string query = $"update {TableName} set {columnName} = {TypeOfColumn(dataGridView1.CurrentCell.Value.ToString(), columnName)} where {dataGridView1.Columns[0].Name} = {idValue}";
                SqlOrderRepositoryPresenter sqlOrderRepositoryPresenter = new SqlOrderRepositoryPresenter(this);
                sqlOrderRepositoryPresenter.update(query);
            }
            dataGridViewRow.Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if ((LineIsFull(dataGridViewRow)))
            {
              
                    object[] s = Enumerable.Range(1, dataGridViewRow.Cells.Count - 1).Select(elem => dataGridViewRow.Cells[elem].Value).ToArray();
                    MessageBox.Show(string.Join(",", s));
                    for (int i = 0; i < s.Length; i++)
                    {
                       s[i] = TypeOfColumn(s[i].ToString(), dataGridView1.Columns[i+1].Name);
                    }
               
                    string a = $"insert into {TableName}({GetColumnsNames(dataGridView1)}) values({string.Join(",", s)})";
                    MessageBox.Show(a);
                    FillDGVREmptyCells(dataGridViewRow);
                    SqlOrderRepositoryPresenter sqlOrderRepositoryPresenter = new SqlOrderRepositoryPresenter(this);
                    sqlOrderRepositoryPresenter.insert(a);
                    LoadTable(TableName);
            }            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           TableName = comboBox1.SelectedItem.ToString();
            dataGridView1.CellValueChanged -= DataGridView1_CellValueChanged;
            dataGridView1.CellBeginEdit -= DataGridView1_CellBeginEdit;
            LoadTable(TableName);
        }
        #region OldRealization

        
        private string TypeOfColumn(string value,string columnName)
        {
            switch (dataGridView1.Columns[columnName].ValueType.Name)
            {
                case "String":
                    return $"'{value}'";
                case "Int32":
                    return value;
                default:
                    return value;
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            PreviousValue = dataGridView1.CurrentCell.Value.ToString();
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].ValueType.Name!="Byte[]")
            MessageBox.Show($"{e.Exception.Message} Тип стобца {dataGridView1.Columns[e.ColumnIndex].ValueType.Name}");
        }
        private bool LineIsFull(DataGridViewRow dataGridViewRow)
        {
            bool isEmpty = true;
            for (int i = 1; i < dataGridViewRow.Cells.Count; i++)
            {
                if (dataGridViewRow.Cells[i].Value != null)
                {
                    if (dataGridViewRow.Cells[i].Value.ToString() == "")
                    {
                        //dataGridViewRow.Cells[i].Value = TypeOfColumn(dataGridViewRow.Cells[i].Value.ToString(), dataGridView1.Columns[i].Name);
                        isEmpty = false;
                        break;
                    }
                }
                else isEmpty = false;
            }
            return isEmpty;
        }
        private string GetColumnsNames(DataGridView dataGridView)
        {
            string[] Names = new string[dataGridView.Columns.Count];
            string b = "";
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
               Names[i] = dataGridView.Columns[i].Name;
                b += dataGridView.Columns[i].Name + ",";
            }
            b  = b.Remove(b.Length - 1 , 1);
            return b;
        }
        private  void FillDGVREmptyCells(DataGridViewRow row)
        {
            for (int i = 1; i < row.Cells.Count; i++)
            {
                row.Cells[i].Value = "";       
            }
           
        }
        #endregion

        private void DataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SqlOrderRepositoryPresenter repositoryPresenter = new SqlOrderRepositoryPresenter(this);
            repositoryPresenter.UniversalUpdateChanges(TableName, dataGridView1);
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name == "Byte[]")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "(*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string query = $"update {TableName} set {dataGridView1.Columns[e.ColumnIndex].Name} = (SELECT * FROM OPENROWSET(BULK N'{openFileDialog.FileName}', SINGLE_BLOB) as T1) where {dataGridView1.Columns[0].Name} = {dataGridView1.Rows[e.RowIndex].Cells[0].Value}";
                    SqlOrderRepositoryPresenter repositoryPresenter = new SqlOrderRepositoryPresenter(this);
                    repositoryPresenter.update(query);
                }               
            }
        }
    }
}
