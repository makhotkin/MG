using MG.Assets.Cards;
using MG.Play.Objects;

namespace MG.Play.Cards
{
	public interface ICard : IGameObject
	{
		IPrintedCard PrintedCard { get; }
		T GetValue<T>(CardProperty<T> property);
	}
}
