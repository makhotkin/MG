﻿using MG.Assets.Cards;
using MG.Assets.Utils;
using System;
using System.Collections.Generic;

namespace MG.Assets.Decks
{

	public class Deck : IDeck
	{
		private static readonly IList<IPrintedCard> EmptySection = new List<IPrintedCard>().AsReadOnly();
		private MultiMap<DeckSection, IPrintedCard> sections = new MultiMap<DeckSection, IPrintedCard>();
		public IList<IPrintedCard> this[DeckSection s] => sections.TryGetValue(s, out List<IPrintedCard> list) ? list : EmptySection;
		public string Name { get; set; }

		IEnumerable<DeckSection> IDeck.Sections => sections.Keys;
		public bool HasSection(DeckSection section) => sections.ContainsKey(section);

		public IList<IPrintedCard> EnsureSection(DeckSection s)
		{
			if (!sections.TryGetValue(s, out List<IPrintedCard> container))
				sections.Add(s, container = new List<IPrintedCard>());
			return container;
		}
	}
}



