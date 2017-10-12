using MG.Assets.Storages.Adapters;
using MG.Assets.Storages.Adapters.MtgJsonDotCom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Assets.Tests
{
	public static class TestEnviroinment
	{
		private static readonly string editionsPath = ConfigurationManager.AppSettings["EditionsFolder"];
		private static readonly string projectPath = ConfigurationManager.AppSettings["HardcodedProjectFolder"];

		public static readonly string PathToEditions = Path.Combine(projectPath, editionsPath);
	}
}
