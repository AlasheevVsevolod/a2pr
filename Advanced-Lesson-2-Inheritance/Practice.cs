using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            Console.Write("Введите строку: ");
            string strToPrint = Console.ReadLine();

            Console.WriteLine("Выберите операцию:\n1. В консоль\n2. В файл\n3. В картинку");
            string operation = Console.ReadLine();

            IPrinter newPrinter;

            switch (operation)
            {
                case "1":
                    newPrinter = new ConsolePrinter(ConsoleColor.Magenta);
                    newPrinter.Print(strToPrint);
                    break;

                case "2":
                    newPrinter = new FilePrinter("newFile");
                    newPrinter.Print(strToPrint);
                    break;

                case "3":
                    newPrinter = new ImagePrinter("newImage", 30, 5, 5);
                    newPrinter.Print(strToPrint);
                    break;

                default:
                    Console.WriteLine("Некорректная операция");
                    break;
            }
        }
    }

    public interface IPrinter
    {
        void Print(string str);
    }

    public class ConsolePrinter : IPrinter
    {
        private ConsoleColor _color;
        public ConsolePrinter(ConsoleColor tmpColor)
        {
            _color = tmpColor;
        }
        public void Print(string str)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }

    public class FilePrinter : IPrinter
    {
        private ConsoleColor _color;
        private string _fileName;
        public FilePrinter(string tmpName)
        {
            _fileName = tmpName;
        }
        public void Print(string str)
        {
            System.IO.File.AppendAllText($@"D:\{_fileName}.txt", str);
        }
    }

    public class ImagePrinter : IPrinter
    {
        private string _fileName;
        private int _fontSize, _x, _y;
        private string _imgPath;
        private Brush _fontColor;
        private Font _font;

        public ImagePrinter(string tmpName, int tmpFontSize, int tmpX, int tmpY)
        {
            _fileName = tmpName;
            _imgPath = $@"D:\{_fileName}.bmp";

            _fontSize = tmpFontSize;
            _fontColor = Brushes.Crimson;
            _font = new Font("Calibri", _fontSize);

            _x = tmpX;
            _y = tmpY;
        }
        public void Print(string str)
        {
            Bitmap newFile = new Bitmap(500, 500);

            //Задаю фон изображению
            for (int i = 0; i < newFile.Width; i++)
            {
                for (int y = 0; y < newFile.Height; y++)
                {
                    newFile.SetPixel(i, y, Color.White);
                }
            }

            Graphics tmpG = Graphics.FromImage(newFile);

            tmpG.DrawString(str, _font, _fontColor, _x, _y);
            newFile.Save(_imgPath);
        }
    }
}
