using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class VigenereCipher
    {
        static string defaultAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string Text { get; set; }
        public string Pass { get; set; }
       
       
               
        public VigenereCipher(string text, string pass)
        {
            Text = text;
            Pass = pass;
        }

        private string GetRepeatKey(string s, int n)  //генерация повторяющегося пароля
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }

            return p.Substring(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text.Length);
            var retValue = "";
            var q = defaultAlphabet.Length;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    var letterIndex = defaultAlphabet.IndexOf(text[i]);
                    var codeIndex = defaultAlphabet.IndexOf(gamma[j]);
                    if (!defaultAlphabet.Contains(text[i]))
                    {
                        retValue += text[i];  //если буква не найдена, добавляем её в исходном виде
                        j--;
                    }
                    else
                    {

                        retValue += defaultAlphabet[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                    }
                }
               
            }
            return retValue;
        }

        public string Encrypt() => Vigenere(Text, Pass); //шифрование текста

        public string Decrypt() => Vigenere(Text, Pass, false); //дешифрование текста
    }
}

