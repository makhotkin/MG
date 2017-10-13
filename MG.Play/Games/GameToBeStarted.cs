using MG.Assets.Decks;
using System.Collections.Generic;

namespace MG.Play.Games
{
	public class GameToBeStarted
	{
		public readonly List<PlayerToBeginGameWith> Players = new List<PlayerToBeginGameWith>();
		public GameFormat Format;
		public GameRulesAmmendments RuleChanges;
	}
}