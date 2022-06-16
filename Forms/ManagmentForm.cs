using SudExpertSU.Components;
using SudExpertSU.Models.Components;
using SudExpertSU.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudExpertSU.Forms
{
    public partial class ManagmentForm : Form
    {
        public IRole Role;
        public ManagmentForm(IRole role)
        {
            InitializeComponent();
            Role = role;
            
            if (Role.Name != "prev_gos_ru")
                this.Controls.Add(new TableData(Role));
            else {
                this.Controls.Add(new GosOrgComponent());
            }
        }
    }
}
