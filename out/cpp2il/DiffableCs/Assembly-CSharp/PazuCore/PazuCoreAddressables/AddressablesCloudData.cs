namespace PazuCore.PazuCoreAddressables;

public class AddressablesCloudData
{
	private readonly Dictionary<String, ValueTuple`2<String, String>> _localizationTexts; //Field offset: 0x10
	private readonly Dictionary<String, String> _localizationAudioUrls; //Field offset: 0x18

	public AddressablesCloudData() { }

	public AddressablesCloudData(Dictionary<String, Object> data, bool textsOnly = false) { }

	private void FillDictionaryOfStringValues(Dictionary<String, Object> data, string key, Dictionary<String, ValueTuple`2<String, String>> dictToFill) { }

	private void FillDictionaryOfStringValues(Dictionary<String, Object> data, string key, Dictionary<String, String> dictToFill) { }

	public string GetLocalizedAudioUrl(string key) { }

	public string GetLocalizedText(string key, out string languageCode) { }

	private string GetStringValueFromDictionary(Dictionary<String, ValueTuple`2<String, String>> dict, string key, out string item2) { }

	private string GetStringValueFromDictionary(Dictionary<String, String> dict, string key) { }

}

