using MG.Play.Cards;
using System.Collections.Generic;

namespace MG.Play.Players.Controllers
{
	public interface IPlayerController
	{
		Task<IEnumerable<T>> ChooseSome<T>(IEnumerable<T> candidates, int cntMin = 0, int max = int.MaxValue);
	}
}