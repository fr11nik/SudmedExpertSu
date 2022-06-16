namespace SudExpertSU.Models.Components
{
    partial class GosOrgComponent
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFullNameExpert = new System.Windows.Forms.Label();
            this.labelCaseAddress = new System.Windows.Forms.Label();
            this.labelCaseDate = new System.Windows.Forms.Label();
            this.buttonPrintResult = new System.Windows.Forms.Button();
            this.listBoxMaterials = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // labelFullNameExpert
            // 
            this.labelFullNameExpert.AutoSize = true;
            this.labelFullNameExpert.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFullNameExpert.Location = new System.Drawing.Point(18, 13);
            this.labelFullNameExpert.Name = "labelFullNameExpert";
            this.labelFullNameExpert.Size = new System.Drawing.Size(96, 23);
            this.labelFullNameExpert.TabIndex = 0;
            this.labelFullNameExpert.Text = "{FLMExpert}";
            // 
            // labelCaseAddress
            // 
            this.labelCaseAddress.AutoSize = true;
            this.labelCaseAddress.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCaseAddress.Location = new System.Drawing.Point(18, 486);
            this.labelCaseAddress.Name = "labelCaseAddress";
            this.labelCaseAddress.Size = new System.Drawing.Size(112, 23);
            this.labelCaseAddress.TabIndex = 0;
            this.labelCaseAddress.Text = "{caseAddress}";
            // 
            // labelCaseDate
            // 
            this.labelCaseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCaseDate.AutoSize = true;
            this.labelCaseDate.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCaseDate.Location = new System.Drawing.Point(638, 13);
            this.labelCaseDate.Name = "labelCaseDate";
            this.labelCaseDate.Size = new System.Drawing.Size(86, 23);
            this.labelCaseDate.TabIndex = 0;
            this.labelCaseDate.Text = "{caseDate}";
            // 
            // buttonPrintResult
            // 
            this.buttonPrintResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintResult.Location = new System.Drawing.Point(522, 411);
            this.buttonPrintResult.Name = "buttonPrintResult";
            this.buttonPrintResult.Size = new System.Drawing.Size(273, 40);
            this.buttonPrintResult.TabIndex = 1;
            this.buttonPrintResult.Text = "Распечатать результат";
            this.buttonPrintResult.UseVisualStyleBackColor = true;
            this.buttonPrintResult.Click += new System.EventHandler(this.ButtonPrintResult_Click);
            // 
            // listBoxMaterials
            // 
            this.listBoxMaterials.FormattingEnabled = true;
            this.listBoxMaterials.Location = new System.Drawing.Point(22, 83);
            this.listBoxMaterials.Name = "listBoxMaterials";
            this.listBoxMaterials.Size = new System.Drawing.Size(483, 368);
            this.listBoxMaterials.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список материалов, приложенных к делу ";
            // 
            // GosOrgComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxMaterials);
            this.Controls.Add(this.buttonPrintResult);
            this.Controls.Add(this.labelCaseDate);
            this.Controls.Add(this.labelCaseAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFullNameExpert);
            this.Name = "GosOrgComponent";
            this.Size = new System.Drawing.Size(844, 535);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFullNameExpert;
        private System.Windows.Forms.Label labelCaseAddress;
        private System.Windows.Forms.Label labelCaseDate;
        private System.Windows.Forms.Button buttonPrintResult;
        private System.Windows.Forms.ListBox listBoxMaterials;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
