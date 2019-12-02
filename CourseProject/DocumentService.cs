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
            using (var doc=WordprocessingDocument.Open(@"C:\Users\Пушистая булка\Desktop\Учеба\Result_v5.docx", false))
            {
                var body = doc.MainDocumentPart.Document.Body.InnerText;
                return body;
            }
        }

        public static string DefaultToUTF(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            s = Encoding.UTF8.GetString(bytes);
            return s;
        }


        public static string UTF8ToWin1251(string sourceStr) // Конвертирует строку из UTF-8 в Windows-1251
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("Windows - 1251");
            byte[] utf8Bytes = utf8.GetBytes(sourceStr);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }
        public static string Win1251ToUTF8(string source)//Конвертирует строку из Windows-1251 в UTF-8
        {
            Encoding utf8 = Encoding.GetEncoding("utf - 8");
            Encoding win1251 = Encoding.GetEncoding("windows - 1251");
            byte[] utf8Bytes = win1251.GetBytes(source);
            byte[] win1251Bytes = Encoding.Convert(win1251, utf8, utf8Bytes);
            source = win1251.GetString(win1251Bytes);
            return source;
        }


    }


}
 
