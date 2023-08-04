using System;

namespace BingoApp.Domein 
{
	public class Spel 
	{
        private RandomNummerGenerator nummerGenerator { get; set; }
        private List<IObserver> spelers { get; set; }
        private List<int> nummers { get; set; }

        public Spel()
        {
            spelers = new List<IObserver>();
            nummerGenerator = new RandomNummerGenerator();
        }
        public void SchrijfSpelerIn(string naam)
        {
            Random random = new ();
            nummers = new();
            IObserver speler = new Speler(naam, nummers);

            do
            {
                for (int i = 0; i < 5; i++)
                {
                    nummers.Add(random.Next(1, 100));
                }
            } while (nummers.Distinct().Count() != nummers.Count()); // om dubbele getallen te vermijden

            nummers.Sort();
            spelers.Add(speler);
            nummerGenerator.Attach(speler);
        }
        public bool GeefWinstTerug()
        {
            foreach (IObserver speler in spelers)
            {
                if (((Speler)speler).nummers.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public int GeefGenereerdGetalTerug()
        {
            return nummerGenerator.GenereerNummer();
        }
        public List<int> GeefLijstGetallenTerug()
        {
            return nummerGenerator.GeefGegenereerdeGetallen();
        }
        public List<IObserver> GetSpelers()
        {
            return spelers;
        }
    }
}

