using MG.Assets.Cards;
using MG.Assets.Decks;
using MG.Assets.Utils;
using MG.Play.Cards;
using MG.Play.Objects;
using MG.Play.Players.Controllers;
using MG.Play.Zones;
using System;
using System.Collections.Generic;

namespace MG.Play.Players
{
	public class Player : IPlayer
	{
		private PlayerId id;
		private string name;

		MultiMap<ZoneType, IGameObject> zones = new MultiMap<ZoneType, IGameObject>();
		public IList<IGameObject> GetZone(ZoneType zone) => zones[zone];

		public IPlayerController Controller => throw new NotImplementedException();
		private IPlayerController controller;

		public Player(IPlayerController controller, string name)
		{
			this.controller = controller;
			this.name = name;
		}

		[RulesReference("103.1")]
		internal void DeckBecomesLibrary(IDeck deck, Func<IPrintedCard, IPlayer, ICard> fnMaterializeCard)
		{
			foreach(var cp in deck[DeckSection.Main])
				zones.Add(ZoneType.Library, fnMaterializeCard(cp, this));

			foreach(var cp in deck[DeckSection.SideBoard])
				zones.Add(ZoneType.Sideboard, fnMaterializeCard(cp, this));

			if (deck.HasSection(DeckSection.Commander))
				throw new NotImplementedException("103.1b In a Commander game, each player puts his or her commander from his or her deck face up into the command zone before shuffling. See rule 903.6.");
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