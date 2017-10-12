using System;
using System.Configuration;
using System.IO;

namespace MG.Assets.Tests
{
	public class MtgJsonReaderTestBase {

		protected static readonly string editionsPath = ConfigurationManager.AppSettings["EditionsFolder"];
		protected static readonly string projectPath = ConfigurationManager.AppSettings["HardcodedProjectFolder"];

		protected static string GetPathForEdition(string code) => Path.Combine(projectPath, editionsPath, code + "-x.json");
	}
}
