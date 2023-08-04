using System;

namespace BingoApp.Domein 
{
	public class RandomNummerGenerator 
	{
        private List<IObserver> observers { get; set; }
		private List<int> gegenereerdeGetallen { get; set; }
		private Random random { get; set; }

        public RandomNummerGenerator() 
		{
			gegenereerdeGetallen = new();
			observers = new();
			random = new();
		}
		public void Attach(IObserver observer) 
		{
			observers.Add(observer); // hierdoor wordt de speler toegevoegd aan de lijst van observers

		}
		public void Detach(IObserver observer) 
		{
			observers.Remove(observer); // hierdoor wordt de speler verwijderd uit de lijst van observers
		}
		public void Notify(int nummer) 
		{
			foreach (var observer in observers)
			{
                observer.Update(gegenereerdeGetallen.Last()); // hierdoor wordt de laatste nummer doorgegeven aan de speler
            }
		}
		public int GenereerNummer()
		{
			int nummer;
			do
			{
				nummer = random.Next(1, 100);

			} while (gegenereerdeGetallen.Contains(nummer));

            gegenereerdeGetallen.Add(nummer);
            Notify(nummer);
            return nummer;
        }
		public List<int> GeefGegenereerdeGetallen()
		{
            return gegenereerdeGetallen;
        }
	}
}
