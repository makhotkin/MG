using MG.Assets.Cards;

namespace MG.Play.Cards
{
	public interface ICard
	{
		IPrintedCard PrintedCard { get; }
		T GetValue<T>(CardProperty<T> property);
	}
}
