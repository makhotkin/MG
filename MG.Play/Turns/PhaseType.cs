using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Turns
{
	public enum PhaseType : byte
	{
		Undefined = 0,
		Untap = 0x10,
		Upkeep = 0x20,
		Draw = 0x30,
		MainPrecombat = 0x40,
		CombatBegin = 0x51,
		CombatDeclareAttackers = 0x52,
		CombatDeclareBlockers = 0x53,
		CombatFirstStrikeDamage = 0x58,
		CombatDamage = 0x59,
		CombatEnd = 0x5F,
		MainPostCombat = 0x80,
		EndOfTurn = 0xC0,
		Cleanup = 0xF0
	}
}
