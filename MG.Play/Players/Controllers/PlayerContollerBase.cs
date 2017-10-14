using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Play.Players.Controllers
{
	public abstract class PlayerContollerBase : IPlayerController
	{
		public abstract Task<IEnumerable<T>> ChooseSome<T>(IEnumerable<T> candidates, int cntMin = 0, int max = int.MaxValue);
	}
}