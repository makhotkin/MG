using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Assets.Utils
{
	// This is to mark references to Comprehensive rules in an uniform way
	[System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
	public sealed class RulesReferenceAttribute : Attribute
	{
		// See the attribute guidelines at 
		//  http://go.microsoft.com/fwlink/?LinkId=85236
		readonly string rulesReference;

		public RulesReferenceAttribute(string rulesPoint)
		{
			this.rulesReference = rulesPoint;
		}

		public string RulesReference
		{
			get { return rulesReference; }
		}

		// This is a named argument
		//public int NamedInt { get; set; }
	}
}
