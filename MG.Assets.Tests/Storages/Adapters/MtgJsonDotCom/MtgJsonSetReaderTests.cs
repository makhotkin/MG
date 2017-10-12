using System;
using System.Configuration;
using System.IO;

namespace MG.Assets.Tests
{
	public class MtgJsonReaderTestBase {
		protected static string GetPathForEdition(string code) => Path.Combine(TestEnviroinment.PathToEditions, code + "-x.json");
	}
}
