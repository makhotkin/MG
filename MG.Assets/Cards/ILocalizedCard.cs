using MG.Assets.Editions;
using System.Collections.Generic;

namespace MG.Assets.Cards
{
	public interface ILocalizedCard
	{
		IPrintedCard Prototype { get; }
		string Name { get; }
		CardLanguage Language { get; }
		int MultiverseId { get; }
		string InscribedText { get; }       // Event Date in most cases
		IEnumerable<string> RulesTranslated { get; }
		string FlavorText { get; }
	}
}

