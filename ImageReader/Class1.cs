using Patagames.Ocr;
using System;

namespace ImageReader
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.convertImageToText();
        }

        public void convertImageToText()
        {
            using(var api = OcrApi.Create())
            {
                api.Init("English");

                string tt = api.GetTextFromImage("C:\\Users\\viren\\OneDrive\\Pictures\\Images");
                Console.WriteLine(tt);
                Console.Read();
            }
        }
    }
}
