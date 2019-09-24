using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using aplikimi.AplikimiClasses;
namespace aplikimi
{
   

    public partial class MainWindow : Window
    {
        public object textBoxProperties { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ComboBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
        //krijimi i metodes per gjenerimin e totalit te pikeve
        private double TotaliPikeve()
        {
            double totali;
            int viti1=int.Parse(txtSuksesi1.Text);
            int viti2 =int.Parse(txtSuksesi2.Text);
            int viti3 = int.Parse(txtSuksesi3.Text);
            int piket=int.Parse(txtPiket.Text);

            totali = (viti1 + viti2 + viti3 + (piket) / 4);
            return totali;
        }
        //metoda gjinia
        private string gjinia()
        {
            string gjinia="";
            if (chkM.IsChecked == true)
            {
                gjinia = "Mashkull";
            }
            else if(chkF.IsChecked==true)
            {
                gjinia = "Femer";
            }
            return gjinia;
        }
        //metoda e datelindjes
        public DateTime datelindja()
        {
            DateTime t;
            string a = txtDatelindja.Text.ToString();
            t = DateTime.Parse(a);
            return t;
        }
        //metoda : export to pdf
        private void ExportToPdf()
        {
            try
            {
                var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                
                string path = $"C:\\Users\\HP\\Desktop\\Aplikimi\\" + txtEmri.Text+".pdf";
                PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                pdfDoc.Open();

                var headerTable = new PdfPTable(new[] { .75f, 2f })
                {
                   // HorizontalAlignment = Left.ToString,
                    WidthPercentage = 75,
                    DefaultCell = { MinimumHeight = 22f }
                };
                headerTable.AddCell("Emri");
                headerTable.AddCell(txtEmri.Text);
                
                headerTable.AddCell("Emri i prindit");
                headerTable.AddCell(txtEmriPrindit.Text);

                headerTable.AddCell("Mbiemri");
                headerTable.AddCell(txtMbiemri.Text);

                headerTable.AddCell("Nr Personal");
                headerTable.AddCell(txtNumriPersonal.Text);

                headerTable.AddCell("Datelindja");
                headerTable.AddCell(txtDatelindja.Text);

                headerTable.AddCell("Nr telefonit");
                headerTable.AddCell(txtTelefoni.Text);

                headerTable.AddCell("Fakulteti qe aplikoni");
                headerTable.AddCell(comboFakulteti.Text);

                headerTable.AddCell("Drejtimi:");
                headerTable.AddCell(txtDrejtimi.Text);

                headerTable.AddCell("Notat: \n Viti 1 \n Viti 2 \n Viti 3 \n Piket ne test te Matures");
                headerTable.AddCell("\n" + txtSuksesi1.Text + "\n" + txtSuksesi2.Text + "\n" + txtSuksesi3.Text + "\n" + txtPiket.Text);


                headerTable.AddCell("Totali i pikeve te llogaritura: ");
                headerTable.AddCell(TotaliPikeve().ToString());

                pdfDoc.Add(headerTable);

                pdfDoc.Close();

         }
            catch (Exception ex)
            {

            }
        }
        //metoda CLEAR
        public void clear()
        {
            txtEmri.Text = "";
            txtEmriPrindit.Text = "";
            txtMbiemri.Text="";
            txtNumriPersonal.Text="";
            txtKomunaBanimit.Text="";
            txtAdresa.Text="";
            txtTelefoni.Text="";
            txtEmail.Text="";
            txtShkolla.Text="";
            txtDrejtimi.Text="";
            
            txtSuksesi1.Text="";
            txtSuksesi2.Text="";
            txtSuksesi3.Text="";
            txtPiket.Text="";
            
            txtDepartamenti.Text="";
            
        }

        //butoni per insertim ne databaze
        private void BtnApliko_Click(object sender, RoutedEventArgs e)
        {


            AplikimiClasses.aplikimi p = new AplikimiClasses.aplikimi();
            p.emri = txtEmri.Text;
            p.emri_prindit = txtEmriPrindit.Text;
            p.mbiemri = txtMbiemri.Text;
            p.numri_personal = int.Parse(txtNumriPersonal.Text);
            //perdorimi i metodes datelindja
            p.datelindja = datelindja();
            //perdorimi i metodes gjinia
            p.gjinia = gjinia();
            p.shteti_lindjes = comboShtetiLindjes.Text.ToString();
            p.shteti_vendbanimit = comboShtetiVendbanimit.Text.ToString();
            p.komuna_vendbanimit = txtKomunaBanimit.Text;
            p.adresa = txtAdresa.Text;
            p.nr_telefonit = txtTelefoni.Text;
            p.email = txtEmail.Text;
            p.shkolla_mesme =  txtShkolla.Text;
            p.drejtimi = txtDrejtimi.Text;
            p.vendi_shkollimit = comboVendiShkollimit.Text.ToString();
            p.suksesi_1 =  int.Parse(txtSuksesi1.Text);
            p.suksesi_2 =  int.Parse(txtSuksesi2.Text);
            p.suksesi_3 =  int.Parse(txtSuksesi3.Text);
            p.piket_matures =  int.Parse(txtPiket.Text);
            p.fakulteti = comboFakulteti.Text.ToString();
            p.departamenti =  txtDepartamenti.Text;
            p.statusi = comboStatusi.Text.ToString();


            bool sukses = p.Insert(p);
            if (sukses == true)
            {
                MessageBox.Show("Insertimi u krye me sukses");
               
            }
            else
            {
                MessageBox.Show("Ju lutem mbushni te gjitha te dhenat!!");
            }
           
            
        }
        //buttoni per PDF
        private void BtnPdf_Click(object sender, RoutedEventArgs e)
        {

            ExportToPdf();
            MessageBox.Show("PDF aplikacioni gjendet ne : C:\\Users\\HP\\Desktop\\Aplikimi\\ ");
        }
        //butoni per clear
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
