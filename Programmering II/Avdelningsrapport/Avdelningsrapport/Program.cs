using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 // mohamad Abou helal //
namespace Avdelningsrapport
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Bok
    {                                 //deklarera variabler.
        public string Title;
        public string F�rfattare;
        public string Typ;
        public string status;
        public Bok(string Title, string F�rfattare, string status)
        {
            this.Title = Title;
            this.F�rfattare = F�rfattare; // Ger ett v�rde till den �rvda variablen.
            this.status = status;

        }
    }
    public class Roman : Bok
    {
        public Roman(string Title, string F�rfattare, string status) : base(Title, F�rfattare, status)
        {
            Typ = "Roman";
            this.status = status;

        }
        public override string ToString()
        {
            if (status == "true")
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
            else
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
        }
    }
    public class Novellsamling : Bok
    {
        public Novellsamling(string Title, string F�rfattare, string status) : base(Title, F�rfattare, status)
        {
            Typ = "Novellsamling";
            this.status = status;
        }
        public override string ToString()
        {
            if (status == "true")
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
            else
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
        }
    }
    public class Tidskrift : Bok
    {
        public Tidskrift(string Title, string F�rfattare, string status) : base(Title, F�rfattare, status)
        {
            Typ = "Tidskrift";
            this.status = status;
        }
        public override string ToString()
        {
            if (status == "true")
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
            else
            {
                return Title + " en " + Typ + " av " + F�rfattare + ".";
            }
        }
    }
    public class FileLoader
    {
     
            private const string Path = "texter.txt";
            public List<Bok> boklista = new List<Bok>();     //skapa lista.
            public FileLoader()          // importeringsklass.
            {                                              //skapa en klass FileLoader
                List<string> itemSaver = new List<string>();

                if (File.Exists(Path))            // s�k i hela.
                {
                    StreamReader reader = new StreamReader(Path, Encoding.Default, false);// f�r att l�sa read f�r rad skapar en ny StreamReader
                    string item = "";
                    while ((item = reader.ReadLine()) != null)     // while- loop f�r att avbryts n�r det inte l�ngre finns ett v�rde.
                    {
                        itemSaver.Add(item);
                    } 

                    foreach (string a in itemSaver)                   //dela texten.
                    {
                        string[] vektor = a.Split(new string[] { "###" }, StringSplitOptions.None);

                        switch (vektor[2])
                        {
                            case "Roman":

                                Roman nRoman = new Roman(vektor[0], vektor[1], vektor[3]);

                                boklista.Add(nRoman);
                                break;

                            case "Tidskrift":

                                Tidskrift nTidskrift = new Tidskrift(vektor[0], vektor[1], vektor[3]);

                                boklista.Add(nTidskrift);

                                break;

                            case "Novellsamling":

                                Novellsamling nNovellsamling = new Novellsamling(vektor[0], vektor[1], vektor[3]);

                                boklista.Add(nNovellsamling);

                                break;



                        }



                    }

                }
            }
        }

    }
