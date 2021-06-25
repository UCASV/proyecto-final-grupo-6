using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FinalProject.ProjectContext;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using PdfFont = iTextSharp.text.pdf.PdfFont;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;


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
            createPDF();

        }

        private void createPDF()
        {
            PdfWriter pdfAppo = new PdfWriter("Reporte_cita.pdf");
            PdfDocument pdf = new PdfDocument(pdfAppo);
            Document document = new Document(pdf, PageSize.LETTER);

            document.SetMargins(40,20,40,20);

            PdfFont fontCols = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontCont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] cols = {"N° cita", "Nombre", "Fecha de cita", "Hora de la cita", "Direccion de cabina"};
            float[] tam = {2, 5, 4, 4, 5};
    
            Table table = new Table(UnitValue.CreatePercentArray(tam));
            table.SetWidth(UnitValue.CreatePercentValue(100));
    
            var db = new < nombre>();
    
            var list = db.Appointments
                .Include(i => i.DuiPatientNavigation)
                .Include(i=> i.IdCabinNavigation)
                .Where(i=> i.DuiPatientNavigation.Dui.Equals(txtDUI.Text))
                .Select(x => new
                {
                    Numero_de_cita = x.Id,
                    Nombre = x.DuiPatientNavigation.NamePatient,
                    Fecha_cita = x.DateAppointment,
                    Hora_cita = x.HourAppointment,
                    Direccion = x.IdCabinNavigation.AddressCabin,
                })
                .ToList();


            //string dateOne = list[0].Fecha_cita.ToString();
            //string date = dateOne.Substring(0, 10);
    
    
            foreach (string col in cols)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(col).SetFont(fontCols)));
            }
    
            table.AddCell(new Cell().Add(new Paragraph(list[0].Numero_de_cita.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].Nombre.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(date.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].Hora_cita.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].Direccion.ToString()).SetFont(fontCols)));
    
            document.Add(table);
            document.Close();
            

        }
        


    }
}
