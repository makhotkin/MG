﻿namespace MG.Play.Actions
{
	public abstract class ActionBase : IAction
	{
		public abstract bool UsesStack { get; }
	}
}