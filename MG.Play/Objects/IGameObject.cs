using MG.Assets.Cards.Properties;
using MG.Assets.Cards.Properties.ManaCosts;
using MG.Assets.Cards.Properties.Types;
using MG.Assets.Utils;
using MG.Play.Abilities;
using MG.Play.Players;
using System;
using System.Collections.Generic;

namespace MG.Play.Objects
{
	[RulesReference("109")] // An object is an ability on the stack, a card, a copy of a card, a token, a spell, a permanent, or an emblem.
	public interface IGameObject
	{
		string Name { get; }
		ManaCost ManaCost { get; }

		Color Color { get; }
		Color ColorIndicator { get; }

		SuperType SuperType { get; }
		CardType CardType { get; }
		SubType SubType { get; }

		IEnumerable<String> RulesText { get; }
		IEnumerable<IAbility> Abilities { get; }

		int? Power { get; }
		int? Toughness { get; }
		int? Loyalty { get; }
		/* Won't use these until Vanguard is needed
		int HandModifier,
		int	LifeModifier.
		*/
		IPlayer Controller { get; }
		IPlayer Owner { get; }
	}
}
