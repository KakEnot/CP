using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using System.Web;
using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Threading.Tasks;
using System.Text;

namespace CourseProject
{
    public class DocumentService
    {
        public static string PArseWordX()
        {
            using (var doc=WordprocessingDocument.Open(@"C:\Users\Admin\Desktop\Учеба\Result_v5.docx",false))
            {

                var body = doc.MainDocumentPart.Document.Body.InnerText;
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                byte[] ansiiBytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, bodyBytes);
                string result = Encoding.ASCII.GetString(ansiiBytes);
                //string s = doc.MainDocumentPart.Document.Body.InnerText;
                //s = WebUtility.HtmlEncode(s);
                return result;
            }
        }

    }


}
 
