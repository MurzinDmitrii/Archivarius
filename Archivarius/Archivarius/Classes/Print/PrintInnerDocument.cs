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
    internal class PrintInnerDocument
    {
        public static void Print(Case innercase)
        {
            var document = new iTextSharp.text.Document();
            using (var writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))
            {
                document.Open();

                // do some work here
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                writer.DirectContent.BeginText();
                writer.DirectContent.SetFontAndSize(baseFont, 13);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, 
                    "Акт о сдаче в архив дела " + innercase.CaseFullNumber.ToString() +
                    " от "+ innercase.Date.ToShortDateString() +"\r\n" + "Данный документ"
                    , 35, 766, 0);
                writer.DirectContent.EndText();

                document.Close();
                writer.Close();
            }
        }
    }
}
