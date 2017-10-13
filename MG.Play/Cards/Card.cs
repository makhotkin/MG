using MG.Assets.Cards;
using MG.Play.Players;

namespace MG.Play.Cards
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