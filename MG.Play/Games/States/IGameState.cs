using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Games.States
{
	public interface IGameState
	{
		Task<(bool popCurrent, IGameState nextState)> Execute();
	}
}
