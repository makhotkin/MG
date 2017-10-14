using System.Collections.Generic;

namespace MG.Play.Players.Controllers
{
	public class PlayerControllerNetwork : PlayerContollerBase
	{
		public override async IEnumerable<T> ChooseSome<T>(IEnumerable<T> candidates, int cntMin = 0, int max = int.MaxValue)
		{
			// send objects to player

			throw new System.NotImplementedException();

			// wait for their reply
			await 
		}
	}
}