using MG.Assets.Cards;
using MG.Game.Players;

namespace MG.Game.Cards
{
	public class Card : ICard
	{
		private IPrintedCard printedCard;
		private IPlayer owner;

		public Card(IPrintedCard printed, IPlayer owner)
		{
			this.printedCard = printed;
			this.owner = owner;
		}

		public IPrintedCard PrintedCard => printedCard;


		public T GetValue<T>(CardProperty<T> property)
		{
			throw new System.NotImplementedException();
		}


	}
}