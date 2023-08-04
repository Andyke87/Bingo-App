using System;

namespace BingoApp.Domein 
{
    public class SpelController
    {
        private Spel spel { get; set; }

        public SpelController()
        {
            spel = new Spel();
        }
        public void SchrijfSpelerIn(string naam)
        {
            spel.SchrijfSpelerIn(naam);
        }
        public bool GeefWinstTerug()
        {
            return spel.GeefWinstTerug();
        }
        public int GeefGegenereerdGetalTerug()
        {
            return spel.GeefGenereerdGetalTerug();
        }
        public List<int> GeefLijstGetallenTerug()
        {
            return spel.GeefLijstGetallenTerug();
        }
        public List<string> GeefLijstSpelersTerug()
        {
            List<string> spelersInfo = new();
            foreach (IObserver speler in spel.GetSpelers())
            {
                string info = ((Speler)speler).naam + ": ";

                foreach (int getal in ((Speler)speler).nummers)
                {
                    info += getal + " ";
                }
                spelersInfo.Add(info);
            }
            return spelersInfo;
        }
        public List<string> GeefLijstWinnaarsTerug()
        {
            List<string> winnaars = new();
            foreach (IObserver speler in spel.GetSpelers())
            {
                if (((Speler)speler).nummers.Count == 0)
                {
                    winnaars.Add(((Speler)speler).naam);
                }
            }
            return winnaars;
        }
    }
}
