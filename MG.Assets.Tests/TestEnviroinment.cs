using System.Configuration;
using System.IO;

namespace MG.Assets.Tests
{
	public static class TestEnviroinment
	{
		private static readonly string editionsPath = ConfigurationManager.AppSettings["EditionsFolder"];
		private static readonly string decksPath = ConfigurationManager.AppSettings["DecksFolder"];
		private static readonly string projectPath = ConfigurationManager.AppSettings["HardcodedProjectFolder"];

		public static readonly string PathToEditions = Path.Combine(projectPath, editionsPath);
		public static readonly string PathToDecks = Path.Combine(projectPath, decksPath);
	}
}
