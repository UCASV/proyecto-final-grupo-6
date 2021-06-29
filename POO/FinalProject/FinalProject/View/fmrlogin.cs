using System;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;

namespace FinalProject
{
    public partial class fmrlogin : Form
    {
         
        public fmrlogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string employee = txtUser.Text;
            string password = txtPassword.Text;
            var validation = false; 
            
            var db = new ProjectFinalV2Context();
            var employeelist = db.Employees
                .ToList();

            var employeeref = new Employee();
            foreach (var em in employeelist)
            {
                if (em.User.Equals(employee) && em.Password.Equals(password))
                {
                    validation = true;
                    employeeref.Id = em.Id;
                }
            }



            if (!validation)
            {
                MessageBox.Show("El usuario ingresado no existe", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var employeeFound = db.Set<Employee>()
                    .SingleOrDefault(em => em.Id == employeeref.Id);

                if (employeeFound.IdType == 2||employeeFound.IdType == 3)
                {
                    MessageBox.Show("No cuenta con permiso de gestor", "Permiso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    
                    using (fmrmain newWindow = new fmrmain(employeeFound))
                    {
                        DialogResult answer = newWindow.ShowDialog(); 
                        
                    }
                }
                    
            }
            
           

            
           
        }
    }
}