using System;
using System.Data;
using System.Windows.Forms;
using SudExpertSU.Presenters;
using SudExpertSU.Views;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace SudExpertSU.Models.Components
{
    public partial class GosOrgComponent : UserControl,IOrderSource
    {
        public GosOrgComponent()
        {
            InitializeComponent();
            GetExpertiseResult();
        }

        public DataTable Data { get; set; }

        private void GetExpertiseResult()
        {
            string query = "SELECT      concat(EmployeeData.LName,'.',substring(EmployeeData.FName,1,1),'.',substring(EmployeeData.MiddleName,1,1)) as 'ФИО Эксперта'," +
                "Material.Name AS 'Наименование материала',"+
			 " Material.Weight AS 'Вес', "+
             " MaterialList.receiptDate AS 'Дата поступления материала', [Case].address AS 'Адресс дела', [Case].Date AS 'Дата дела', "+
			  "ExpertiseResult.resultFile AS 'Результат экспертизы' "+
              "FROM ExpertiseResult INNER JOIN "+
              "[Case] ON ExpertiseResult.caseID = [Case].id INNER JOIN "+
              "Employee ON [Case].employeeID = Employee.id inner join "+
			  "MaterialList on MaterialList.listID = [Case].materialListID inner join "+
			 "EmployeeData on EmployeeData.id = Employee.employeeDataID inner join "+
		     "Material on Material.id = MaterialList.materialID where ExpertiseResult.DepartamentID = (select DepartamentId from Position where PositionName = 'gov.ru')";
            SqlOrderRepositoryPresenter repositoryPresenter = new SqlOrderRepositoryPresenter(this);
            repositoryPresenter.load(query);
            labelFullNameExpert.Text = $"ФИО эксперта: {(string)Data.Rows[0]["ФИО Эксперта"]}";
            labelCaseDate.Text = $"Дата дела: {(string)Data.Rows[0]["Дата дела"]}";
            labelCaseAddress.Text = $"Адресс дела: {(string)Data.Rows[0]["Адресс дела"]}";
            for (int i = 0; i < Data.Rows.Count; i++)
            {
                listBoxMaterials.Items.Add($"Наименование материала: {(string)Data.Rows[i]["Наименование материала"]}  Вес: {Data.Rows[i]["Вес"].ToString()}");
            }
        }

        private void ButtonPrintResult_Click(object sender, EventArgs e)
        {
            printPDFWithAcrobat();
        }
      

        public void printPDFWithAcrobat()
        {


            string Filepath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.pdf)|*.pdf";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Filepath = saveFileDialog.FileName;
                File.WriteAllBytes(Filepath, (byte[])Data.Rows[0]["Результат экспертизы"]);
                using (PrintDialog Dialog = new PrintDialog())
                {
                    Dialog.ShowDialog();
                    ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                    {
                        Verb = "print",
                        CreateNoWindow = true,
                        FileName = Filepath,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    try
                    {

                        Process printProcess = new Process();
                        printProcess.StartInfo = printProcessInfo;

                        printProcess.Start();

                        printProcess.WaitForInputIdle();

                        Thread.Sleep(3000);

                        if (false == printProcess.CloseMainWindow())
                        {
                            printProcess.Kill();
                        }
                    }
                    catch(System.ComponentModel.Win32Exception)
                    {
                        MessageBox.Show("Принтер не найден \nрезультат сохранен в файл по выбранному пути");
                    }
                    
                }
            }
            
           
        }
}
}
