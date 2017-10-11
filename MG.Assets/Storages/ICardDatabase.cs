using MG.Assets.Cards;
using MG.Assets.Editions;
using System.Collections.Generic;

namespace MG.Assets.Database
{
	public interface ICardDatabase
	{
		IEnumerable<ICardEdition> Editions { get; }

		ICardEdition GetEditionByCode(string code);

		IEnumerable<IPrintedCard> CardsByEdition(string code);
		IEnumerable<IPrintedCard> CardsByEdition(ICardEdition edition);

		IPrintedCard CardByName(string name, string code = null);
		IPrintedCard CardByName(string name, ICardEdition edition, int index = -1);
	}
}
