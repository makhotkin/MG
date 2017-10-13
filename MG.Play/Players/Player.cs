using MG.Assets.Cards;
using MG.Assets.Decks;
using MG.Assets.Utils;
using MG.Play.Cards;
using MG.Play.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Players
{
	public class Player : IPlayer
	{
		private PlayerId id;
		private string name;

		MultiMap<ZoneType, ICard> zones = new MultiMap<ZoneType, ICard>();

		public PlayerId Id => id;

		public Player(PlayerId id, string name)
		{
			this.id = id;
			this.name = name;
		}

		[RulesReference("103.1")]
		internal void DeckBecomesLibrary(IDeck deck, Func<IPrintedCard, IPlayer, ICard> fnMaterializeCard)
		{
			foreach(var cp in deck[DeckSection.Main])
			{
				zones.Add(ZoneType.Library, fnMaterializeCard(cp, this));
			}

			var sCom = deck[DeckSection.Commander];
			if (sCom != null)
			{
				throw new NotImplementedException("103.1b In a Commander game, each player puts his or her commander from his or her deck face up into the command zone before shuffling. See rule 903.6.");
			}
		}

		internal void ShuffleLibrary()
		{
			Shuffle(zones[ZoneType.Library]);
		}

		private static readonly Random rng = new Random();
		private static void Shuffle<T>(List<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}