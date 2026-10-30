namespace PazuCore.EndSession;

public class EndSessionBaseData
{
	internal class LocalizationText
	{
		public string key; //Field offset: 0x10
		public string value; //Field offset: 0x18

		public LocalizationText() { }

	}

	public int snapshotVersion; //Field offset: 0x10
	public string dateModified; //Field offset: 0x18
	public List<LocalizationText> localizationTexts; //Field offset: 0x20
	public string languageCode; //Field offset: 0x28
	public string requestedLanguageCode; //Field offset: 0x30
	private Dictionary<String, String> _hashedLocalizationTexts; //Field offset: 0x38

	public EndSessionBaseData() { }

	public string GetLocalizationText(string key, string fallBackText = null) { }

}

