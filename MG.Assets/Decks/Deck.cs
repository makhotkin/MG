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
		public IEnumerable<IPrintedCard> this[DeckSection s] {
			get { return Sections.TryGetValueOrEmptyEnumerable(s); }
			set => throw new NotImplementedException();
		}
	}
}



