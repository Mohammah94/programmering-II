using System;
using System.Collections.Generic;
// Mohamad Abou Helal // 
namespace Bokhyllan
{
        public class Bok
        {                    // Deklerar variabler
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
        }
        public class Tidskrift : Bok
        {
            public Tidskrift(string Title, string Författare) : base(Title, Författare)
            {
                Typ = "Tidskrift";
            }
        }
        public class Novellsamling : Bok
        {
            public Novellsamling(string Title, string Författare) : base(Title, Författare)
            {
                Typ = "Novellsamling";
            }
        }

        public class program
        {
            static void Main(string[] args)
            {
                List<Bok> mylist = new List<Bok>(); // Skapar en lista. 
                bool Run = true;
                
                while (Run) // skapa loop.
                {
                    Console.WriteLine(" Hej och välkommen till biblioteket ");
                    Console.WriteLine("[1] regestera ny bok ");
                    Console.WriteLine("[2] visa böcker "); // Skriv ut meny.
                    Console.WriteLine("[3] Avsluta ");

                int bokval;
                bool v = Int32.TryParse(Console.ReadLine(),out bokval); // vi behöver använda TryParse för att undvika inmatning fel för användaren.
                if (!v)
                {
                    Console.WriteLine("Inmatning fel");
                }
                else
                {

                    switch (bokval)
                    {

                        case 1:
                            Console.WriteLine("skriv en title");
                            string title = Console.ReadLine();


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
                                        mylist.Add(roman);
                                        break;
                                    case 2:
                                        
                                        Tidskrift tidskrift = new Tidskrift(title, förfttare);
                                        mylist.Add(tidskrift);
                                        break;
                                    case 3:
                                        
                                        Novellsamling novell = new Novellsamling(title, förfttare);
                                        mylist.Add(novell);
                                        break;
                                }
                            }
                            break;
                           
                        case 2:
                            foreach (Bok bok in mylist)

                            {

                                Console.WriteLine(bok.Title + " av " + bok.Författare + " (" + bok.Typ + ")");

                            }

                            break;

                        case 3: // Avsluta
                            Run = false;
                            break;
                    }
                }






                }
            }





        }
    }