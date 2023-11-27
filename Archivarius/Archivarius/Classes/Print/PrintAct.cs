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
    internal class PrintAct
    {
        public static void Print(Act act)
        {
            bool inner = act.Type.Name == "На сдачу";
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
                    "Акт о " + (inner ? "сдаче в архив дела ": "выдаче из архива дела ") + 
                    act.Case.CaseFullNumber.ToString() +
                    " от " + act.Case.Date.ToShortDateString(), 50, 780, 0);
                writer.DirectContent.ShowTextAligned(2 * iTextSharp.text.Element.ALIGN_LEFT,
                    "Данный документ подтверждает, что дело " + act.Case.CaseFullNumber.ToString() +
                    " от " + act.Case.Date.ToShortDateString(),
                    50, 740, 0);
                writer.DirectContent.ShowTextAligned(3 * iTextSharp.text.Element.ALIGN_LEFT,
                    (inner ? "было передано в архив" : "было изъято из архива"),
                    50, 720, 0);
                writer.DirectContent.ShowTextAligned(3 * iTextSharp.text.Element.ALIGN_LEFT,
                    "Дело передал: " + (inner ? act.Case.Worker.WorkerFullName : worker.WorkerFullName),
                    50, 680, 0);
                writer.DirectContent.ShowTextAligned(3 * iTextSharp.text.Element.ALIGN_LEFT,
                    "Дело принял: " + (inner ? worker.WorkerFullName : act.Case.Worker.WorkerFullName),
                50, 640, 0);
                writer.DirectContent.ShowTextAligned(3 * iTextSharp.text.Element.ALIGN_LEFT,
                    act.Date.ToShortTimeString(),
                50, 600, 0);
                writer.DirectContent.EndText();
                document.Close();
                writer.Close();
            }
        }
    }
}
