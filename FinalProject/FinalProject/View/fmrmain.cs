using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.ProjectContext;

namespace FinalProject
{
    public partial class fmrmain : Form
    {
        private Employee loginEmployee { get; }
        
        public fmrmain(Employee loginEmployee)
        { 
            InitializeComponent();
            this.loginEmployee = loginEmployee; 
        }
        
        private void fmrmain_Load(object sender, EventArgs e)
        {
            sspUser.Text = $"Bienvenido {loginEmployee.Name}"; 
        }

        private void btnnewUser_Click(object sender, EventArgs e)
        {
            using (fmrnewuser newWindow = new fmrnewuser(loginEmployee.Id))
            {
                DialogResult answer = newWindow.ShowDialog();
               
            }
        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {
            using (fmrappointment newWindow = new fmrappointment(loginEmployee.Id))
            {
                DialogResult answer = newWindow.ShowDialog();
                
            }
        }


        
    }
}