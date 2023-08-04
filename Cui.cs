using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoApp.Domein;

namespace BingoApp.Cui
{
    public class CuiBingoApp
    {
        private SpelController spelController { get; set; }

        public CuiBingoApp()
        {
            spelController = new SpelController();
        }

        public void Run()
        {
            Console.WriteLine("Welkom bij Bingo!");

            while (!spelController.GeefWinstTerug())
            {
                Console.WriteLine("\n1. Schrijf speler in");
                Console.WriteLine("2. Start spel");
                Console.Write("Keuze: ");
                string keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        Console.Write("Voer de naam van de speler in: ");
                        string naam = Console.ReadLine();
                        spelController.SchrijfSpelerIn(naam);
                        Console.WriteLine("Speler '" + naam + "' ingeschreven.\n");
                        ToonSpelers();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Het spel gaat beginnen!");
                        do
                        {
                            int nummer = spelController.GeefGegenereerdGetalTerug();
                            Console.WriteLine("Nieuw getal gegenereerd: " + nummer);
                            ToonSpelers();
                            Console.WriteLine("Druk op Enter voor een nieuw getal...");
                            Console.ReadLine();
                            Console.Clear();
                        } while (!spelController.GeefWinstTerug());
                        ToonWinnaars();
                        ToonGegenereerdeGetallen();
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
        }

        private void ToonGegenereerdeGetallen()
        {
            Console.WriteLine("Gegenereerde getallen:");

            List<int> gegenereerdeGetallen = spelController.GeefLijstGetallenTerug();
            gegenereerdeGetallen.Sort();

            foreach (int nummer in gegenereerdeGetallen)
            {
                Console.Write(nummer + " ");
            }
            Console.WriteLine();
        }
        private void ToonWinnaars()
        {
            Console.WriteLine("Spel afgelopen! Winnaars:");
            List<string> winnaars = spelController.GeefLijstWinnaarsTerug();
            foreach (string winnaar in winnaars)
            {
                Console.WriteLine(winnaar);
            }
            Console.WriteLine();
        }
        private void ToonSpelers()
        {
            Console.WriteLine("Spelers en hun resterende getallen:");

            List<string> spelersInfo = spelController.GeefLijstSpelersTerug();
            foreach (string info in spelersInfo)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine();
        }
    }
}
