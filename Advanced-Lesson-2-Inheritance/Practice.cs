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

            Printer newPrinter;

            switch (operation)
            {
                case "1":
                    newPrinter = new ConsolePrinter(strToPrint, ConsoleColor.Magenta);
                    newPrinter.Print();
                    break;

                case "2":
                    newPrinter = new FilePrinter(strToPrint, "newFile");
                    newPrinter.Print();
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Некорректная операция");
                    break;
            }
        }
    }

    public abstract class Printer
    {
        public string strToPrint { get; set; }

        public Printer(string tmpstr)
        {
            strToPrint = tmpstr;
        }
        public abstract void Print();
    }

    public class ConsolePrinter : Printer
    {
        private ConsoleColor _color;
        public ConsolePrinter(string tmpStr, ConsoleColor tmpColor) :base(tmpStr)
        {
            _color = tmpColor;
        }
        public override void Print()
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(strToPrint);
            Console.ResetColor();
        }
    }

    public class FilePrinter : Printer
    {
        private ConsoleColor _color;
        private string fileName;
        public FilePrinter(string tmpStr, string tmpName) : base(tmpStr)
        {
            fileName = tmpName;
        }
        public override void Print()
        {
            Console.ForegroundColor = _color;
            System.IO.File.AppendAllText($@"D:\{fileName}.txt", strToPrint);
            Console.ResetColor();
        }
    }
}
