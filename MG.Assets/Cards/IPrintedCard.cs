using MG.Assets.Cards.Properties;
using MG.Assets.Editions;

namespace MG.Assets.Cards
{
	// Meaning object designed by edition release team 
	public interface IPrintedCard 
	{
		string Name { get; }
		ICardRules Rules { get; }
		ICardEdition Edition { get; }
		CardRarity Rarity { get; }
		string CollectorsNumber { get; }	// cannot bear with plain int here, for some cards have letters 
		string WaterMark { get; }			// Such as Guild, Mirran or Phyrexian mark
		
	}
}

