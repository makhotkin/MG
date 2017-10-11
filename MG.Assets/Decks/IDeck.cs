using MG.Assets.Cards;
using System.Collections.Generic;

namespace MG.Assets.Decks
{
	public interface IDeck
	{
		IEnumerable<IPrintedCard> this[DeckSection s] { get; set; }
	}
}

