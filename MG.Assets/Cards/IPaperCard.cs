namespace MG.Assets.Cards
{
	public interface IPaperCard
	{
		ILocalizedCard Prototype { get; }
		bool Foil { get; }

		// add scratches, signatures and other effects
	}
}
