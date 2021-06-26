using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Image = System.Drawing.Image;
using iTextSharp.text.pdf;  
using System.IO;
using Microsoft.EntityFrameworkCore;


/*using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;*/



namespace FinalProject
{
    public partial class fmrinformation : Form
    {
        private string duiCitizen { get; }
        private int employeeId { get; }

        public fmrinformation(string duiCitizen, int employeeId)
        {
            InitializeComponent();
            this.duiCitizen = duiCitizen;
            this.employeeId = employeeId;
        }


        private void fmrinformation_Load(object sender, EventArgs e)
        {
            DateTime dayGenerated = DateTime.Today;
            DateTime timeGenerated = DateTime.Today;

            //db Context
            var dbcontext = new ProjectFinalV2Context();
            var placeList = dbcontext.Places
                .ToList();
            var appointmentList = dbcontext.Appointments
                .ToList();

            var idPlace = RandomGenerator.GetRandomElement(placeList);
            var placepick = dbcontext.Set<Place>()
                .SingleOrDefault(pla => pla.Id == idPlace);



            var result = appointmentList.Where(app => app.DuiCitizen.Equals(duiCitizen))
                .ToList();
            if (result.Count == 0)
            {
                do
                {
                    dayGenerated = RandomGenerator.GetRandomDate();
                    timeGenerated = RandomGenerator.GetRandomTime();
                } while (dayGenerated.Year != 2021);
            }
            else if (result.Count == 1)
            {
                var appointDB = dbcontext.Set<Appointment>()
                    .SingleOrDefault(appo => appo.DuiCitizen == duiCitizen);
                dayGenerated = dayGenerated.AddDays(49); 
                timeGenerated = RandomGenerator.GetRandomTime();
                
            }
            else if (result.Count == 2)
            {
                MessageBox.Show($"El ciudadano con DUI {duiCitizen} ha finalizado su proceso de vacunación", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //Showing elements 
            txtduishow.Text = duiCitizen;
            txtdate.Text = $"{dayGenerated.Day}/{dayGenerated.Month}/{dayGenerated.Year}";

            if (timeGenerated.Hour < 12)
                txttime.Text = $"{timeGenerated.Hour}:{timeGenerated.Minute} AM";
            else
                txttime.Text = $"{timeGenerated.Hour}:{timeGenerated.Minute} PM";

            txtplaceshow.Text = placepick.Place1;

            //Date and Time 
            var dateGenerated = new DateTime(dayGenerated.Year, dayGenerated.Month, dayGenerated.Day,
                timeGenerated.Hour, timeGenerated.Minute, 0);
            

            //New Appointment 
            var newApp = new Appointment()
            {
                Datetime = dateGenerated,
                DuiCitizen = duiCitizen,
                IdPlace = idPlace,
                IdEmployee = employeeId,

            };
            dbcontext.Add(newApp);
            dbcontext.SaveChanges();


        }


        private void btnAcept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
            private void btnPDF_Click(object sender, EventArgs e)
        {
            var db = new ProjectFinalV2Context();
            var appoinList = db.Appointments
                .Where(app => app.DuiCitizen.Equals(duiCitizen))
                .ToList();
            
            Document documento = new Document();
            PdfWriter.GetInstance(documento, new FileStream("ReservaCita.pdf", FileMode.OpenOrCreate));
            documento.Open();
            
            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES,18f,BaseColor.BLUE);
            title.Add("Detalles de Cita");
            title.Alignment = Element.ALIGN_CENTER;
            documento.Add(title);
            documento.Add(Chunk.NEWLINE); ;
            
            iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance("VACUNA-COVID-19.png");
            Logo.Alignment = Element.ALIGN_MIDDLE;
            Logo.ScalePercent(50f);
            Logo.ScaleAbsoluteWidth(110);
            Logo.ScaleAbsoluteHeight(105);
            documento.Add(Logo);
            documento.Add(Chunk.NEWLINE); 
            
            
            
            PdfPTable table = new PdfPTable(5);
            table.AddCell("Numero de Cita");
            table.AddCell("DUI");
            table.AddCell("Fecha");
            table.AddCell("Hora");
            table.AddCell("Lugar");
            
            
            foreach (Appointment appo in appoinList)
            {
                var placePick = db.Set<Place>()
                    .SingleOrDefault(pla => pla.Id == appo.IdPlace);

                /*Paragraph p = new Paragraph(
                    $"\nNueva Cita {appo.Id}\nDUI : {appo.DuiCitizen}\nFecha: {appo.Datetime.Day}/{appo.Datetime.Month}/{appo.Datetime.Year}" +
                    $"\nHora: {appo.Datetime.Hour}:{appo.Datetime.Minute}\nLugar: {placePick.Place1}");

                document.Add(p);*/
                
                table.AddCell(appo.Id.ToString());
                table.AddCell(appo.DuiCitizen);
                table.AddCell($"{appo.Datetime.Day}/{appo.Datetime.Month}/{appo.Datetime.Year}");
                table.AddCell($"{appo.Datetime.Hour}:{appo.Datetime.Minute}");
                table.AddCell(placePick.Place1);


            }
            
            documento.Add(table);
            documento.Close();
            MessageBox.Show("El archivo ha sido creado", "creado", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
            this.Close();
        }

        
    }
}
