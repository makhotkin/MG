using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.Assets.Cards.Properties.ManaCosts;

namespace MG.Assets.Tests.Cards.Properties.ManaCosts
{
	[TestClass]
	public class ManaCostTests
	{
		[TestMethod]
		public void ManaCost_NoCost()
		{
			ManaCost mc = ManaCost.Parse("");
			Assert.IsTrue(mc.HasNoCost);
			Assert.AreEqual("(no cost)", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_Zero()
		{
			ManaCost mc = ManaCost.Parse("{0}");
			Assert.AreEqual(0, mc.ConvertedManaCost);
			Assert.AreEqual("0", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_1W()
		{
			ManaCost mc = ManaCost.Parse("{1}{W}");

			Assert.AreEqual(mc.ConvertedManaCost, 2);
			Assert.AreEqual("1W", mc.ToString());
		}


		[TestMethod]
		public void ManaCost_GenericTen()
		{
			ManaCost mc = ManaCost.Parse("10");
			Assert.IsFalse(mc.HasNoCost);
			Assert.AreEqual(mc.ConvertedManaCost, 10);
			Assert.AreEqual("{10}", mc.ToString(true));
		}

		[TestMethod]
		public void ManaCost_GenericTwelve()
		{
			ManaCost mc = ManaCost.Parse("{12}");

			Assert.AreEqual(mc.ConvertedManaCost, 12);
			Assert.AreEqual("12", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_XUU_NoBrackets()
		{
			ManaCost mc = ManaCost.Parse("{X}{U}{U}");

			Assert.AreEqual(mc.ConvertedManaCost, 2);
			Assert.AreEqual("XUU", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_TwoGenericOrColored() 
		{
			ManaCost mc = ManaCost.Parse("{2/W}{2/U}{2/B}{2/R}{2/G}");

			Assert.AreEqual(mc.ConvertedManaCost, 10);
			Assert.AreEqual("{2/W}{2/U}{2/B}{2/R}{2/G}", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_HybridGW() // Dawnglow Infusion 
		{
			ManaCost mc = ManaCost.Parse("{X}{G/W}");

			Assert.AreEqual(mc.ConvertedManaCost, 1);
			Assert.AreEqual("{X}{G/W}", mc.ToString(true));
		}

		[TestMethod]
		public void ManaCost_FiveColors_InconsistentBraces() // Progenitus
		{
			ManaCost mc = ManaCost.Parse("WWUU{B}BR{R}{G}G");

			Assert.AreEqual(mc.ConvertedManaCost, 10);
			Assert.AreEqual("WWUUBBRRGG", mc.ToString());
		}

		[TestMethod]
		public void ManaCost_PhyrexianGreenWithX() // Corrosive Gale
		{
			ManaCost mc = ManaCost.Parse("X{GP}");

			Assert.AreEqual(mc.ConvertedManaCost, 1);
			Assert.AreEqual("X{P/G}", mc.ToString());
		}


		[TestMethod]
		public void ManaCost_Colorless_Generic() // Kozilek, the Great Distortion
		{
			ManaCost mc = ManaCost.Parse("8CC");

			Assert.AreEqual(mc.ConvertedManaCost, 10);
			Assert.AreEqual("{8}{C}{C}", mc.ToString(true));
		}

	}
}
