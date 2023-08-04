using System;

namespace BingoApp.Domein 
{
	public class Speler : IObserver  
	{
		public string naam { get; set; }
		public List<int> nummers { get; set; }

		public Speler(string naam, List<int> nummers)
		{
            this.naam = naam;
			this.nummers = nummers;
		}
		public void Update(int nummer) 
		{
			if (nummers.Contains(nummer))
			{
                nummers.Remove(nummer);
            }
		}
	}
}
