using MG.Assets.Cards;
using System.Collections.Generic;

namespace MG.Assets.Decks
{
	public interface IDeck
	{
		string Name { get; }
		IList<IPrintedCard> this[DeckSection s] { get; }
		IList<IPrintedCard> EnsureSection(DeckSection s);
	}
}

