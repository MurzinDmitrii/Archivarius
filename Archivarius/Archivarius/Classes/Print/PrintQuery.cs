using Archivarius.Model;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivarius.Classes.Print
{
    internal class PrintQuery
    {
        public static void Print(Query query)
        {
            var worker = DB.entities.Worker.FirstOrDefault(c => c.ID == Properties.Settings.Default.WorkerID);
            var document = new iTextSharp.text.Document();
            using (var writer = PdfWriter.GetInstance(document, new FileStream("InnerPDF.pdf", FileMode.Create)))
            {
                document.Open();

                // do some work here
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                writer.DirectContent.BeginText();
                writer.DirectContent.SetFontAndSize(baseFont, 13);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT,
                    "Запрос на выдачу из архива дела " +
                    query.Case.CaseFullNumber.ToString() +
                    " от " + query.Case.Date.ToShortDateString(), 50, 780, 0);
                writer.DirectContent.ShowTextAligned(2 * iTextSharp.text.Element.ALIGN_LEFT,
                    "Причина запроса:  " + query.Description, 50, 740, 0);
                writer.DirectContent.ShowTextAligned(3 * iTextSharp.text.Element.ALIGN_LEFT,
                    "Запрашивающее лицо: " + query.Case.Worker.WorkerFullName,
                    50, 680, 0);
                writer.DirectContent.EndText();
                document.Close();
                writer.Close();
            }
        }
    }
}
