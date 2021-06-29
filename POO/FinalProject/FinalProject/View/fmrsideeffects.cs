using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public partial class fmrsideeffects : Form
    {
        private ProjectFinalV2Context db { get; }
        private string duiCitizen { get;  }
        private Appointment appoPick { get; }
        private ProcessVaccination vaccination { get; set; }
        
        
        public fmrsideeffects(string duiCitizen,Appointment appoPick)
        {
            InitializeComponent();
            db = new ProjectFinalV2Context();
            this.duiCitizen = duiCitizen;
            this.appoPick = appoPick;
        }


        private void fmrsideeffects_Load(object sender, EventArgs e)
        {
            txtDay.Text = $"{appoPick.Datetime.Day}/{appoPick.Datetime.Month}/{appoPick.Datetime.Year}";
            txtHour.Text = $"{appoPick.Datetime.Hour}:{appoPick.Datetime.Minute}";
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            newProcess();

        }
        
        private void newProcess()
        {
            if (txtminutes.Text == "" || dtpStar.Value.Hour < 8 || dtpVaccine.Value.Hour > 18||dtpStar.Value>dtpVaccine.Value)
                MessageBox.Show("Campos Invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var dateStar = new DateTime(appoPick.Datetime.Year, appoPick.Datetime.Month, appoPick.Datetime.Day,
                    dtpStar.Value.Hour, dtpStar.Value.Minute, 0);
                var dateVaccine = new DateTime(appoPick.Datetime.Year, appoPick.Datetime.Month, appoPick.Datetime.Day,
                    dtpVaccine.Value.Hour, dtpVaccine.Value.Minute, 0);

                vaccination = new ProcessVaccination()
                {
                    DatetimeRegistered = appoPick.Datetime,
                    DatetimeInitiation = dateStar,
                    DatetimeVaccine = dateVaccine,
                    TimeEffect = Convert.ToInt32(txtminutes.Text)
                };

                db.Add(vaccination);
                db.SaveChanges();
                
                //Creating new ProcessxCitizen
                SavingProcesCitizen();

                MessageBox.Show("Proceso Terminado Exitosamente", "Proceso", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                this.Close();

            }

        }

        
        private void SavingProcesCitizen()
        {
            var processDB = db.Set<ProcessVaccination>()
                .SingleOrDefault(vaccine => vaccine.Id == vaccination.Id);
            
            
            var newProcessCitizen = new Processxcitizen()
            {
                IdCitizen = appoPick.DuiCitizen,
                IdProcess = processDB.Id
            };
            db.Add(newProcessCitizen);
            db.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}