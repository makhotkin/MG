using MG.Assets.Decks;
using System.Collections.Generic;

namespace MG.Game.State
{
	public class GameToBeStarted
	{
		public readonly List<PlayerToBeginGameWith> Players = new List<PlayerToBeginGameWith>();
		public GameFormat Format;
		public GameRulesAmmendments RuleChanges;
	}
}