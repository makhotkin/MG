using System.Collections.Generic;
using MG.Assets.Cards;
using MG.Assets.Editions;
using System.Linq;
using System;

namespace MG.Assets.Storages.Adapters.MtgJsonDotCom
{
	public class MtgJsonDotComAdapter : CardDataAdapter
	{
		private readonly string[] FileNames;
		private int ixFile;

		public MtgJsonDotComAdapter(string folder)
		{
			FileNames = System.IO.Directory.EnumerateFiles(folder, "*.json").ToArray();
			Reset();
		}

		ICardEdition currentEdition;
		IEnumerable<IPrintedCard> currentCards;

		public override IEnumerable<IPrintedCard> CurrentCards => currentCards;

		public override ICardEdition Current => currentEdition;

		public override void Dispose()
		{
			// no resources allocated
		}

		public override bool MoveNext()
		{
			// lock here?
			while(++ixFile < FileNames.Length)
			{
				string fileName = FileNames[ixFile];
				if (!shouldReadFile(fileName))
					continue;
				(ICardEdition currentEdition, IEnumerable<IPrintedCard> currentCards) = readFile(fileName);
				return true;
			}
			return false;
		}

		private bool shouldReadFile(string fileName)
		{
			return true;
		}

		private (ICardEdition, IEnumerable<IPrintedCard>) readFile(string fileName)
		{
			var reader = new MtgJsonSetReader(fileName);
			return (reader.Edition, reader.Cards);
		}

		public override void Reset()
		{
			ixFile = -1;
		}
	}

}
