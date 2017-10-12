using MG.Assets.Cards;
using MG.Assets.Utils;
using System;
using System.Collections.Generic;

namespace MG.Assets.Decks
{

	public class Deck : IDeck
	{
		private static readonly IReadOnlyList<IPrintedCard> EmptySection = new List<IPrintedCard>().AsReadOnly();
		MultiMap<DeckSection, IPrintedCard> Sections = new MultiMap<DeckSection, IPrintedCard>();
		public IList<IPrintedCard> this[DeckSection s] {
			get { return Sections.TryGetValue(s, out List<IPrintedCard> list) ? list : null; }
		}

		public string Name { get; set; }

		public IList<IPrintedCard> EnsureSection(DeckSection s)
		{
			if (!Sections.TryGetValue(s, out List<IPrintedCard> container))
				Sections.Add(s, container = new List<IPrintedCard>());
			return container;
		}
	}
}



