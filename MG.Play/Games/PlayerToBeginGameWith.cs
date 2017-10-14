using MG.Assets.Decks;
using MG.Play.Players.Controllers;

namespace MG.Play.Games
{
	public class PlayerToBeginGameWith
	{
		public IPlayerController Controller;
		public string Name;
		public IDeck Deck;
	}
}