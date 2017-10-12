using MG.Assets.Editions;

namespace MG.Assets.Cards
{
	public interface IPaperCard
	{
		IPrintedCard Prototype { get; }
		bool Foil { get; }
		CardLanguage Language { get; }
		string Name { get; } // localized one
		int MultiverseId { get; }			// for main face (when it flips)
		string InscribedText { get; }       // Event Date in most cases


		// add scratches, signatures and other effects
	}
}
