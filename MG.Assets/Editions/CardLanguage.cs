using System.Collections.Generic;

namespace MG.Assets.Editions
{
	public class CardLanguage
	{
		public string IsoLanguageName { get; private set; }
		public string NativeName { get; private set; }
		public string Code { get; private set; }        // ISO_639-1 (mostly)

		public CardLanguage(string isoCode, string name, string native)
		{
			IsoLanguageName = name;
			Code = isoCode;
		}

		public static readonly CardLanguage English = new CardLanguage("en", "English", "English");
		public static readonly CardLanguage French = new CardLanguage("fr", "French", "Français");
		public static readonly CardLanguage Italian = new CardLanguage("it", "Italian", "Italiano");
		public static readonly CardLanguage German = new CardLanguage("de", "German", "Deutsch");
		public static readonly CardLanguage Japanese = new CardLanguage("jp", "Japanese", "日本語");
		public static readonly CardLanguage Korean = new CardLanguage("ko", "Korean", "한국어");
		public static readonly CardLanguage ChineseSimplified = new CardLanguage("cn", "Chinese Simplified", "汉语");
		public static readonly CardLanguage ChineseTraditional = new CardLanguage("zh", "Chinese Traditional", "漢語");
		public static readonly CardLanguage Portuguese = new CardLanguage("pt", "Portuguese", "Português");
		public static readonly CardLanguage Russian = new CardLanguage("ru", "Russian", "Русский");
		public static readonly CardLanguage Spanish = new CardLanguage("es", "Spanish", "Español");

		public override bool Equals(object obj)
		{
			var otherObj = obj as CardLanguage;
			return otherObj != null && this.Equals(otherObj);
		}

		public bool Equals(CardLanguage other)
		{
			return other.Code.Equals(this.Code);
		}

		public override int GetHashCode()
		{
			return -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);
		}
	}
}
