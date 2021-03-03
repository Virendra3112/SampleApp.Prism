using IronOcr;
using System;

namespace ImageReader
{
    public class Class1
    {
        static void Main(string[] args)
        {


        }

        public string ReadData(string path)
        {
            string result = null;
            OcrResult Result = null;
            try
            {
                Result = new IronTesseract().Read(path);//("C:\\test.png");
                Console.WriteLine(Result.Text);
            }
            catch (Exception)
            {
            }

            result = Result.Text;
            return result;
        }


    }
}
