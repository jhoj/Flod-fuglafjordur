using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

/**
 * 
 * @Rithøvundur: Jákup Høj
 * @Gjørt tann 07.07.2015
 * @Seinasta dagføring: 05.05.2016
 * 
 * *********************************************************************
 * **** DAGFØRING 05.05.2016 Same shit different day *************
 * Roynd at fáa pop up frá einari exception at stedga vid at koma framm
 * á skermin.
 * 
 * Havi broytt workbook.open ( til at brúka Extract data mode. og so 
 * eisini onnur true false virdir.
 * 
 * *********************************************************************
 * **** DAGFØRING 29.10.2015****
 * Kill process er skrátta, og ístaðin blívur Marshal.release brúkt,
 * so eisini eitt call til Garbage Collector, alt hetta er gjørt í einum
 * finally blokki.
 * 
 * *********************************************************************
 * 
 * **** DAGFØRING 19.10.2015****
 *  Koyrt allan logik í eina metodu, fyri at fáa scope at sleppa so nógvum resursum sum gjørligt,
 *  Excel hevur spælt mær eitt puss!
 *  flutt excel book open í eitt try catch.
 *  Broytingin er gjørd á reglu uml. 113-120.
 * 
 *
 * ***********************************************************************
 *  ***    Soleiðis riggar forritið!   ***
 * Hendan app'in vísir tídirnar tá tad er flód í Fuglafirdi.
´* Eina tíd fyri fyrrapart, tvs. 00:00 - 11:59.
 * Eina tíd seinna part, tvs. 12:00 - 23:59.
 * 
 * Programmid fær tídirnar úr einum excel fíli.
 * Fílurin inniheldur 12 sheets, eitt fyri hvønn mána. 1 merkir Jan, 2 Feb osv.
 * Programmid brúkar dato, til at vísa tídirnar. Tá tad er tann 02.05.2015, 
 * so finnur programmi adru rekkju í talvuni (dagur = 02), og velur fimta sheet í fílinum (máni = 05)
 * 
 * Programmid brúkar ein timara til at sikra at programmid er 'up to date',
 * timarin verdur uppdateradur hvønn minutt.
 * ***********************************************************************************
 */

namespace Flóð
{
    public partial class Flóð : Form
    {
        private static Flóð instance;
        private String fyrrapart, seinnapart;

        private Flóð()
        {
            InitializeComponent();
        }

        public static Flóð getInstance()
        {
            //this is not thread safe.
            if (instance == null)
            {
                instance = new Flóð();
            }

            return instance;
        }
       

        private void log(String message)
        {
            Console.WriteLine(message + " " + DateTime.Now);
        }

        private void Flóð_Load(object sender, EventArgs e)
        {
            log("Form load");
            repaintForm();
        }

        private void getTheWholeThingDone() 
        {           

            //Declare excel
            Excel.Application excel = null;
            Excel.Workbook book = null;
            Excel.Worksheet sheet = null;

            try
            {
                //find excel file
                String[] files = Directory.GetFiles(@"C:\Flóð\", "*.xlsx");
                
                excel = new Excel.Application();
                excel.Visible = false;

                Object missing = Type.Missing;
                Boolean readOnly = true;
                Boolean ignoreReadOnly = true;
                Boolean editable = false;
                Boolean localeOfExcel = true;
                
                //2 == Opening in extract data mode.
                book = excel.Workbooks.Open(files[0], missing, readOnly, missing, missing, missing, ignoreReadOnly, missing, missing, editable, false, false, false, localeOfExcel, 2);
                sheet = book.Sheets[DateTime.Now.Month];
                
                //read file
                Excel.Range range = sheet.get_Range(findCorrectCell("G"), Type.Missing);
                fyrrapart = range.Text;
                range = sheet.get_Range(findCorrectCell("H"), Type.Missing);
                seinnapart = range.Text;
            }
            catch (Exception) { }
            finally
            {
                //'false' fyri ikki at goyma bókina.
                book.Close(false, Type.Missing, Type.Missing);
                // close excel
                excel.Quit();

                //release all memory - stop EXCEL.exe from hanging around.
                if (book != null) { Marshal.ReleaseComObject(book); } 

                if (sheet != null) { Marshal.ReleaseComObject(sheet); }

                if (excel != null) { Marshal.ReleaseComObject(excel); }
                
                book = null; //set each memory reference to null.
                sheet = null;
                excel = null;
                GC.Collect();
            }
            
        }
       
        private void repaintForm()
        {
            getTheWholeThingDone();

            log("repaint form");

            DatoLbl.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            
            fyrrapartLbl.Text = fyrrapart;
            seinnapartLbl.Text = seinnapart;
        }

        /*
         * Funka sum finnur framm til hvør cella skal brúkast.
         * Cellan verður funnin við at brúka dagsdato. 
         * Tvs. cellu 1 tá tað er 01.01.2015
         * Excel arki hevur fyrsta viðri í cellu 4, tí verður hvør dagur plussaður við 3.
         * */
        private String findCorrectCell(String columnLetter)
        {
            log("calculate cell");
            int cellRow = DateTime.Now.Day + 3;
            return columnLetter + cellRow;   // i.e. 'H4'
        }

        /*
         * Hendan methodan uppdaterar tíðirnar, fyrrapart og seinnapart, hvønn 5 min.
         * */
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            log("Timer tick");
            repaintForm();
        }
      
    }
}