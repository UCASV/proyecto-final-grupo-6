using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;
using iTextSharp.text;
using Microsoft.VisualBasic;

namespace FinalProject
{
    public partial class fmrappointment : Form
    {  
       private ProjectFinalV2Context db;
       private  List<AppointmentRef> appointToShow ;
       private List<Appointment> appointList; 
       private int idEmployee { get; }
       
       
        public fmrappointment(int idEmployee)
        {
            InitializeComponent();
            db = new ProjectFinalV2Context();
            
            appointToShow = new List<AppointmentRef>();
            
            appointList = db.Appointments
                .ToList();
            this.idEmployee = idEmployee;
        }

        private void fmrappointment_Load(object sender, EventArgs e)
        {
            //Cleaning textboxes
            appointToShow.Clear(); 
            dgvcitas.DataSource = null;
            txtDui.Text = "";
            txtDay.Text = "";
            txtName.Text = "";
            txtSearch.Text = "";
            
            //Showing data in data griew view
            foreach (Appointment appo in appointList)
            {
                var placeref = db.Set<Place>()
                    .SingleOrDefault(app => app.Id == appo.IdPlace);
                    
               var newAppoin= new AppointmentRef()
                {
                   Id = appo.Id,
                   Date = appo.Datetime,
                   DuiCitizen = appo.DuiCitizen,
                   Place = placeref.Place1
                }; 
                appointToShow.Add(newAppoin);
              
            }
            dgvcitas.DataSource = appointToShow;
        }


        private void picLens_Click(object sender, EventArgs e)
        {
            dgvcitas.DataSource = null;
            appointToShow.Clear(); 
            var duiCitizen = txtSearch.Text;

            
            var result = appointList.Where(app => app.DuiCitizen.Equals(duiCitizen))
                .ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("Ciudadano no registrado", "Ciudadano no encontrado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
                return; 
            }
            else 
                foreach (Appointment appo in appointList)
                {
                    var placeref = db.Set<Place>()
                        .SingleOrDefault(app => app.Id == appo.IdPlace);
                    
                    var newAppoin= new AppointmentRef()
                    {
                        Id = appo.Id,
                        Date = appo.Datetime,
                        DuiCitizen = appo.DuiCitizen,
                        Place = placeref.Place1
                    };

                    if (duiCitizen == newAppoin.DuiCitizen)
                        appointToShow.Add(newAppoin);
                }

            dgvcitas.DataSource = appointToShow; 
        }


        private void dgvcitas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    var refPick = dgvcitas.SelectedRows[0].DataBoundItem as AppointmentRef;
                    var appdb = db.Set<Appointment>()
                        .SingleOrDefault(app => app.Id == refPick.Id);
                    var citizendb = db.Set<Citizen>()
                        .SingleOrDefault(cit => cit.Dui == appdb.DuiCitizen); 

                    txtDui.Text = appdb.DuiCitizen;
                    txtName.Text = citizendb.Name;
                    txtDay.Text = $"{appdb.Datetime.Day}/{appdb.Datetime.Month}/{appdb.Datetime.Year}";

                }
            }
            catch (Exception exception)
            {
                this.Close();
                throw;
            }
           
            
        }

        private void btncontinue_Click(object sender, EventArgs e)
        {
            var refPick = dgvcitas.SelectedRows[0].DataBoundItem as AppointmentRef;
            
            if (txtDui.Text == "")
            {
                MessageBox.Show("Debe selccionara una cita", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return; 
            }

            var result = appointList.Where(app => app.DuiCitizen.Equals(txtDui.Text))
                .ToList();
            
            //Each citizen can only have 2 appointments
            var appoOne = result[0];
            



            if (result.Count == 1)
            {
                var message = MessageBox.Show($"Desea continuar proceso de vacunacion de {txtDui.Text}", "Continuar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (message == DialogResult.Yes)
                {
                    using (var newWindow = new fmrsideeffects(txtDui.Text, appoOne))
                    {
                        DialogResult answer = newWindow.ShowDialog();
                    }

                    using (var newWindow = new fmrinformation(txtDui.Text, idEmployee))
                    {
                        DialogResult answer = newWindow.ShowDialog();
                    }
                }
                else 
                    this.Close();

            }
            else if (result.Count == 2)
            {
                var appoTwo = result[1];
                var processCitizenList = db.Processxcitizens
                    .Where(proc => proc.IdCitizen == txtDui.Text)
                    .ToList();

                if (refPick.Id == appoOne.Id)
                {
                    MessageBox.Show("Primera Cita ya ha sido procesada", "Cita", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return; 
                }
                else if (processCitizenList.Count == 2)
                {
                    MessageBox.Show("Proceso de vacunacion ha finalizado", "Proceso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var message = MessageBox.Show($"Desea terminar proceso de vacunacion de {txtDui.Text}",
                        "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                    if (message == DialogResult.Yes)
                    {
                        using (var newWindow = new fmrsideeffects(txtDui.Text, appoTwo))
                        {
                            DialogResult answer = newWindow.ShowDialog();
                        }
                        this.Close();
                    }
                    else 
                        this.Close();
                    
                }
                
            }
            else 
                this.Close();
            
        }
    }
}