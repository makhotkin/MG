using MG.Assets.Cards;

namespace MG.Game.Cards
{
	public interface ICard
	{
		IPrintedCard PrintedCard { get; }
		T GetValue<T>(CardProperty<T> property);
	}
}
