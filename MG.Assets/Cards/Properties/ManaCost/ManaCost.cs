using System.Collections.Generic;
using System.Linq;

namespace MG.Assets.Cards.Properties.ManaCost
{
	public class ManaCost
	{
		private readonly List<ManaCostAtom> _shards = new List<ManaCostAtom>();
		private int _generic = 0;

		public void Add(int amount)
		{
			Add(ManaCostShards.ColorLess, amount);
		}
		public void Add(ManaCostAtom type, int amount = 1)
		{
			if (type == ManaCostAtom.Generic)
				_generic += amount;
			else
				for (int t = 0; t < amount; t++)
					_shards.Add(type);
		}

		public int ConvertedManaCost { get => _generic + _shards.Sum(s => s.Cmc()); }
	}
}

