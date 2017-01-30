using System;
using System.Globalization;
using System.IO;
using System.Linq;

using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace ListaStudenti
{
    /// <summary>
    /// Lista Studenți
    /// 
    /// Construire raport bazat pe o listă de studenți primită ca parametru
    /// în linia de comandă.
    /// 
    /// Pentru lansare din Visual Studio -> se adaugă paramentrul în fereastra
    /// de proprietăți a proiescului (Debug -> Command line arguments:
    /// "c:\...\ExempleOffice\ListaStudenti\bin\Debug\Materiale\students.txt"
    /// 
    /// Word - construire document raport de la 0
    /// Excel - construire document raport pe bază de template
    /// </summary>
    class Program
    {
        class Persoana
        {
            public string Nume { get; private set; }
            public decimal Medie { get; private set; }

            public Persoana(string linie)
            {
                this.Nume = linie.Split(',')[0].Trim();
                this.Medie = decimal.Parse(
                    linie.Split(',')[1],
                    CultureInfo.InvariantCulture);
            }

            public override string ToString()
            {
                return string.Format(
                    "{0,-20} - {1,4:0.00}",
                    this.Nume,
                    this.Medie);
            }
        }

        static void Main(string[] args)
        {
            string dataFilePath = new FileInfo(args[0]).FullName;
            string baseFileName = Path.Combine(
                Path.GetDirectoryName(dataFilePath),
                Path.GetFileNameWithoutExtension(dataFilePath));

            string wordFilePath = baseFileName + ".docx";

            string excelFilePath = baseFileName + ".xlsx";
            string excelTemplateFilePath = Path.Combine(
                Path.GetDirectoryName(dataFilePath),
                "StudentsTemplate.xlsx");

            // I. Citire date
            var students = File.ReadAllLines(dataFilePath)
                .Select(linie => new Persoana(linie))
                .OrderByDescending(p => p.Medie).ThenBy(p => p.Nume)
                .ToList();

            students.ForEach(persoana => Console.WriteLine(persoana));

            // II. Generare document Word
            var wordApp = new Word.Application() as Word._Application;
            var document = wordApp.Documents.Add();

            document.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;

            var headerRange = document.Sections[1].
                Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            headerRange.InlineShapes.AddPicture(Path.Combine(
                Path.GetDirectoryName(dataFilePath),
                "sigla.jpg"));
            headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            var footerRange = document.Sections[1].
                Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            footerRange.Text = string.Format(
                "Tipărit la data de {0}",
                DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("ro-ro")));
            footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            var docRange = document.Range();
            docRange.Text = "Lista studenți";
            docRange.set_Style("Heading 1");
            docRange.Font.Color = Word.WdColor.wdColorBlack;
            // sau (Word.WdColor)ColorTranslator.ToOle(Color.Black);
            docRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            docRange.InsertParagraphAfter();
            docRange.InsertParagraphAfter();

            docRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            var table = document.Tables.Add(docRange, NumRows: students.Count + 1, NumColumns: 3);

            table.Cell(1, 1).Range.Text = "Nr.";
            table.Cell(1, 2).Range.Text = "Nume";
            table.Cell(1, 3).Range.Text = "Medie";
            for (int i = 0; i < students.Count; i++)
            {
                table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                table.Cell(i + 2, 1).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;

                table.Cell(i + 2, 2).Range.Text = students[i].Nume;

                table.Cell(i + 2, 3).Range.Text = students[i].Medie.ToString("0.00");
                table.Cell(i + 2, 3).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;
            }
            table.set_Style("Table Professional");
            table.Columns.AutoFit();
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

            document.SaveAs(wordFilePath);
            wordApp.Quit();

            // III. Generare document Excel (pe bază de șablon)
            var excelApp = new Excel.Application() as Excel._Application;
            var workbook = excelApp.Workbooks.Open(excelTemplateFilePath);

            Excel.Worksheet sheetData = workbook.Sheets[2];
            var dataRange = sheetData.get_Range("A2");
            dataRange.Value2 = 1;
            dataRange.AutoFill(
                sheetData.get_Range("A2", "A" + (students.Count + 1).ToString()),
                Excel.XlAutoFillType.xlFillSeries);
            for (int i = 0; i < students.Count; i++)
            {
                (sheetData.Cells[i + 2, 2] as Excel.Range).Value2 = students[i].Nume;
                (sheetData.Cells[i + 2, 3] as Excel.Range).Value2 = students[i].Medie;
            }

            sheetData.get_Range("C2", "C" + (students.Count + 1)).Name = "Valori";

            excelApp.DisplayAlerts = false;
            workbook.Close(SaveChanges: true, Filename: excelFilePath);
            excelApp.Quit();

            System.Diagnostics.Process.Start(wordFilePath);
            System.Diagnostics.Process.Start(excelFilePath);
        }
    }
}
