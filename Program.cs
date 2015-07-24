using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace Alien_on_earth
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Heloo Aliens...\n Welcome TO The Earth...:-) \n\n REGISTER HERE\n");

            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            // inputing datas
            System.Console.WriteLine("Enter The Code Name");
            var name = Console.ReadLine();

            System.Console.WriteLine("Enter The Blood Color");
            string blood = Console.ReadLine();
            while (!name_val(blood))
            {
                blood= Console.ReadLine();
            }

            System.Console.WriteLine("Enter The Number of Antennas");
            string antennas = Console.ReadLine();
            while (!digit_val(antennas))
            {
                antennas = Console.ReadLine();
            }

            System.Console.WriteLine("Enter The Number No. of Legs");
            string legs = Console.ReadLine();
            while (!digit_val(legs))
            {
                legs = Console.ReadLine();
            }

            System.Console.WriteLine("Enter The Home Planet");
            var planet = Console.ReadLine();
            while (!name_val(planet))
            {
                planet = Console.ReadLine();
            }

            Console.WriteLine("\n Registered Alien Data \n");
            Console.WriteLine("Name             : " + name);
            Console.WriteLine("Blood Color      : " + blood);
            Console.WriteLine("No of Antennas   : " + antennas);
            Console.WriteLine("No. of Legs      : " + legs);
            Console.WriteLine("Home Planet      : " + planet);

            Console.WriteLine("\nChoose any one of the format to export ");
            System.Console.WriteLine(" 1. Plain Text\n 2. PDF \n");
            var format = int.Parse(Console.ReadLine());
            if (format == 1)
            {
                try
                {
                    if (File.Exists(@"../PDF & Txt/Text.txt"))
                    {
                        File.Delete(@"../PDF & Txt/Text.txt");
                    }
                    ostrm = new FileStream("../PDF & Txt/Text.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter(ostrm);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot open Text.txt for writing");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.SetOut(writer);
                Console.WriteLine("\t Alien Data \n");
                Console.WriteLine("Name             : " + name);
                Console.WriteLine("Blood Color      : " + blood);
                Console.WriteLine("No of Antennas   : " + antennas);
                Console.WriteLine("No. of Legs      : " + legs);
                Console.WriteLine("Home Planet      : " + planet);
                Console.SetOut(oldOut);
                writer.Close();
                ostrm.Close();
                Console.WriteLine("Plain Text Created Succesfully \nFile Location    : bin/PDF & Txt/Text.txt");
            }
            else if(format==2)
            {
                if (File.Exists(@"../PDF & Txt/Text.pdf"))
                {
                    File.Delete(@"../PDF & Txt/Text.pdf");
                }
                
                string str = " Alien Data \n Name:  "+ name+ "\n Blood Color      : " + blood+"\n No of Antennas   : " + antennas+"\nNo. of Legs      : " + legs+ "\n Home Planet      : " + planet;
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Alien Registeration";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
                XTextFormatter tf = new XTextFormatter(graph);
                tf.DrawString(str, font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                string pdfFilename = "../PDF & Txt/Text.pdf";
                pdf.Save(pdfFilename);
                //Process.Start(pdfFilename);
            }
            Console.WriteLine("\nPress enter key to exit");
            Console.ReadLine();
        }

        public static bool name_val(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                System.Console.WriteLine("Dont Let it as Empty...Type Again..");
                return false;
            }
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                {
                    System.Console.WriteLine("Only Alphabets...Type Again..");
                    return false;
                }
            }
            return true;
        }

        public static bool digit_val(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                System.Console.WriteLine("Dont Let it as Empty...Type Again..");
                return false;
            }
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                {
                    System.Console.WriteLine("Only Digits...Type Again..");
                    return false;
                    break;
                }
            }
            return true;
        }

    }
}