using System;
using System.Linq;
using System.Windows.Forms;
using FinalProject.ProjectContext;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;


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
            PdfWriter pdfAppo = new PdfWriter("ReporteCita.pdf");
            PdfDocument pdf = new PdfDocument(pdfAppo);
            Document document = new Document(pdf, PageSize.LETTER);

            document.SetMargins(40,20,40,20);

            PdfFont fontCols = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontCont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] cols = {"Id cita", "Nombre", "Fecha de cita", "Hora de la cita"};
            float[] tam = {2, 5, 4, 4, 5};
    
            Table table = new Table(UnitValue.CreatePercentArray(tam));
            table.SetWidth(UnitValue.CreatePercentValue(100));
    
            var db = new ProjectFinalV2Context();
    
            var list = db.Appointments
                .Where(i=> i.DuiCitizen.Equals(duiCitizen))
                .ToList();


            //string dateOne = list[0].Fecha_cita.ToString();
            //string date = dateOne.Substring(0, 10);
    
    
            foreach (string col in cols)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(col).SetFont(fontCols)));
            }
    
            table.AddCell(new Cell().Add(new Paragraph(list[0].Id.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].DuiCitizen)).SetFont(fontCols));
            table.AddCell(new Cell().Add(new Paragraph(list[0].Datetime.Day.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].Datetime.Hour.ToString()).SetFont(fontCols)));
            table.AddCell(new Cell().Add(new Paragraph(list[0].IdPlace.ToString()).SetFont(fontCols)));
    
            document.Add(table);
            document.Close();
            

        }
        


    }
}
