using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Play.Actions
{
	public interface IAction
	{
		bool UsesStack { get; }
		/* Actions that don't use stack
			
			removing damage from permanents and ending "until end of turn" and "this turn" effects at the start of the cleanup step (see rule 314);
			exiling a card with suspend using its suspend ability.
		*/
		// An action that does not use the stack is called a "game action".
	}
}
