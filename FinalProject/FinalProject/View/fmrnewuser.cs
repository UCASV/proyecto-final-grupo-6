using System;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;

namespace FinalProject
{
    public partial class fmrnewuser : Form
    {
         private int idEmployee { get;  }
        public fmrnewuser(int idEmployee)
        {
            InitializeComponent();
            this.idEmployee = idEmployee; 
        }
        
        private void fmrnewuser_Load(object sender, EventArgs e)
        {
            var db = new ProjectFinalV2Context();
            
            //COMBO BOX INSTITUTIONS
            var institutionList = db.Institutions
                .ToList();
            cmbInstitution.DataSource = institutionList;
            cmbInstitution.DisplayMember = "Institution1";
            cmbInstitution.ValueMember = "Id";
            
            //COMBO BOX GROUP
            var groupList = db.Groups
                .ToList();
            cmbGroup.DataSource = groupList;
            cmbGroup.DisplayMember = "Group1";
            cmbGroup.ValueMember = "Id";
            

        }


        private void btncreate_Click(object sender, EventArgs e)
        {
            var db = new ProjectFinalV2Context();
            var citizenList = db.Citizens
                .ToList();
            var duiCitizen = txtDUI.Text;

            var resultado = citizenList.Where(ci => ci.Dui.Equals(duiCitizen))
                .ToList();

            if (txtDUI.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Completar campos requeridos", "Campos requeridos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            else if (((Group)cmbGroup.SelectedItem).Id==6)
            {
                MessageBox.Show("Debe pertenecer a un grupo de prioridad", "Grupo no valido", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
             
            else if (resultado.Count != 0)
            {
                MessageBox.Show("El usuario ingresado ya ha comenzado su proceso de vacunacion", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
                
            }
            else
            {
                var newCitizen = new Citizen()
                {
                    Dui = txtDUI.Text,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    IdInstitution = ((Institution)cmbInstitution.SelectedItem).Id,
                    IdGroup = ((Group)cmbGroup.SelectedItem).Id
                };
                
                db.Add(newCitizen);
                db.SaveChanges();

                using (var newWindow = new fmrinformation(newCitizen.Dui,idEmployee))
                {
                    DialogResult respuesta = newWindow.ShowDialog();
                }
                
                this.Close();
            }
                

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
