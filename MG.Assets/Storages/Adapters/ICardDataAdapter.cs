using MG.Assets.Cards;
using MG.Assets.Editions;
using System.Collections.Generic;

namespace MG.Assets.Storages.Adapters
{
	public interface ICardDataAdapter : IEnumerator<ICardEdition>
	{
		IEnumerable<IPrintedCard> CurrentCards { get; }

	}

}
