using System;
using System.Collections.Generic;
// Mohamad Abou helal //
namespace Bibliotekarien
{
    public class Bok
    {  //deklarera variabler.
        public string Title;
        public string Författare;
        public string Typ;
        public Bok(string Title, string Författare)
        {
            this.Title = Title;
            this.Författare = Författare; // Ger ett värde till den ärvda variablen.

        }
    }
    public class Roman : Bok
    {
        public Roman(string Title, string Författare) : base(Title, Författare)
        {
            Typ = "Roman";
        }
        public override string ToString()  
        {
            return " boktitle " + Title + " skriven av " + Författare + " boksort " + Typ ;
        }
    }
    public class Novellsamling : Bok
    {
        public Novellsamling(string Title, string Författare) : base(Title, Författare)
        {
            Typ = "Novellsamling";
        }
        public override string ToString()
        {
            return " boktitle " + Title + " skriven av " + Författare + " boksort " + Typ ;
        }
    }
    public class Tidskrift : Bok
    {
        public Tidskrift(string Title, string Författare) : base(Title, Författare)
        {
            Typ = "Tidskrift";
        }
        public override string ToString()
        {
            return " boktitle " + Title + " skriven av " + Författare + " boksort " + Typ ;
        }
    }

    class Bibliotekarie 
    {       //skapa en private lista 
        private List<Bok> boklista = new List<Bok>();

        public void Hämtalista()
        {
            foreach (Bok bok in boklista)
            {
                Console.WriteLine(bok);
            }
        }
        public void skapabok()
        { // skriv ut 
            Console.WriteLine("skriv en title");
            string title = Console.ReadLine();

            // skriv ut
            Console.WriteLine("skriv en författare");
            string förfttare = Console.ReadLine();



            Console.WriteLine(" Är boken Roman[1], Tidskrift[2] eller Novellsamlnig[3]?");



            int choice; // vi behöver använda TryParse för att undvika inmatning fel för användaren.
            bool s = Int32.TryParse(Console.ReadLine(), out choice);
            if (!s)
            {
                Console.WriteLine("inmatning fel");
            }
            else
            {



                switch (choice)
                {
                    // add boken ( Roman , Tidskrift eller Novellsmanling) användaren matar in title och skribent och sparar.
                    case 1:


                        Roman roman = new Roman(title, förfttare);
                        boklista.Add(roman);
                        break;
                    case 2:

                        Tidskrift tidskrift = new Tidskrift(title, förfttare);
                        boklista.Add(tidskrift);
                        break;
                    case 3:

                        Novellsamling novell = new Novellsamling(title, förfttare);
                        boklista.Add(novell);
                        break;
                }
            }

        }
        public void sökbok()
        { // söka om variabler i biblioteket 
            Console.WriteLine("vill du söka med bokens [1]title eller [2] författare  ");
            int sökAlternativ;
            
            bool found = false; // deklarera.
            bool x = Int32.TryParse(Console.ReadLine(), out sökAlternativ); // använd tryparse för att undvikainmatning fel för användaren.
            if (!x)
            {
                Console.WriteLine("inmatning fel");
            }
            else
            {
                switch(sökAlternativ)    // switch satsen 
                {
                    case 1:

                        Console.WriteLine("Skriv bokens namn : ");
                        string bokTitle = Console.ReadLine();
                        foreach (Bok item in boklista)
                            if (bokTitle== item.Title)
                            {
                                Console.WriteLine("Bocken hittades!!");
                                Console.WriteLine(item);

                                found = true;
                                
                            }
                if (!found)
                {
                            // skrv ut om användaren inte har hittat som letar efter.
                            Console.WriteLine("Det finns ej ");
                }
              
                break;
                    case 2:
                        Console.WriteLine("Skriv författarens namn : ");
                        string namn = Console.ReadLine();
                        
                        foreach (Bok item in boklista)
                        {
                            if (namn == item.Författare)
                            {
                                found = true;
                                Console.WriteLine("Bocken hittades!!");
                                Console.WriteLine(item);
                            }
                          

                        }
                        if (!found)
                        {
                            Console.WriteLine("Det finns ej böcker för denna författare");


                        }
               
                        break;
                    

                }
            
            
            
            
            }

        }
    }

    public class program
    { // class börjar .
        static void Main(string[] args)
        {   // lista
            Bibliotekarie bibliotekarie = new Bibliotekarie();
            bool Run = true;

            while (Run) // skapa loop.
            {
                Console.WriteLine(" Hej och välkommen till biblioteket ");
                Console.WriteLine("[1] regestera ny bok ");
                Console.WriteLine("[2] visa böcker ");                            // Skriv ut meny.
                Console.WriteLine("[3] söka en bok ");
                Console.WriteLine("[4] Avsluta ");

                int bokval;
                bool v = Int32.TryParse(Console.ReadLine(), out bokval); // användning TryParse. 
                if (!v)
                {
                    Console.WriteLine("Inmatning fel");
                }
                else
                {
                    switch (bokval)
                    {

                        case 1:

                            bibliotekarie.skapabok();

                            break;
                        case 2:
                            bibliotekarie.Hämtalista();
                            break;
                        case 3:
                            bibliotekarie.sökbok();
                            break;

                        case 4:
                            Run = false;
                            break;
                    }

                }
            }
        }
    }
}