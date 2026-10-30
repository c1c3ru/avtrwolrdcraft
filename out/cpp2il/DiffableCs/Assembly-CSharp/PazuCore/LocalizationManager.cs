namespace PazuCore;

public class LocalizationManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<Country, SupportedLanguages>, IEnumerable`1<SupportedLanguage>> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal IEnumerable<SupportedLanguage> <GetSupportedLanguages>b__26_0(KeyValuePair<Country, SupportedLanguages> country) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass21_0
	{
		public LocalizationManager <>4__this; //Field offset: 0x0
		public SupportedLanguage language; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public FontType key; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal bool <GetLocalizationFont>b__0(LocalizationFont font) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public string countryName; //Field offset: 0x10
		public SystemLanguage systemLanguage; //Field offset: 0x18

		public <>c__DisplayClass28_0() { }

		internal bool <GetSupportedLanguage>b__0(KeyValuePair<Country, SupportedLanguages> country) { }

		internal bool <GetSupportedLanguage>b__1(SupportedLanguage lang) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public string countryCode; //Field offset: 0x10
		public SystemLanguage systemLanguage; //Field offset: 0x18

		public <>c__DisplayClass29_0() { }

		internal bool <FindLanguage>b__0(KeyValuePair<Country, SupportedLanguages> country) { }

		internal bool <FindLanguage>b__1(SupportedLanguage lang) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public SystemLanguage systemLanguage; //Field offset: 0x10
		public Func<SupportedLanguage, Boolean> <>9__1; //Field offset: 0x18

		public <>c__DisplayClass30_0() { }

		internal IEnumerable<SupportedLanguage> <FindLaungaugesBySystem>b__0(KeyValuePair<Country, SupportedLanguages> country) { }

		internal bool <FindLaungaugesBySystem>b__1(SupportedLanguage supportedLanguage) { }

	}

	internal enum FontType
	{
		English = 0,
		Hebrew = 1,
		Russian = 2,
		Japanese = 3,
		Chinese_Simplified = 4,
		Chinese_Traditional = 5,
		Thai = 6,
	}

	internal class LocalizationFont
	{
		public FontType key; //Field offset: 0x10
		public Font defaultFont; //Field offset: 0x18
		public FontStyle defaultFontStyle; //Field offset: 0x20

		public LocalizationFont() { }

	}

	public static LocalizationManager instance; //Field offset: 0x0
	private Dictionary<String, LocalizedSentence> localizedText; //Field offset: 0x20
	[CompilerGenerated]
	private List<LocalizationFont> <localizationFonts>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private List<Font> <Fonts>k__BackingField; //Field offset: 0x30
	[HideInInspector]
	public Country currentCountry; //Field offset: 0x38
	[HideInInspector]
	public SupportedLanguage currentLanguage; //Field offset: 0x40
	private Country projectDefaultCountry; //Field offset: 0x48
	private SupportedLanguage projectDefaultLanguage; //Field offset: 0x50
	public Country_SupportedLanguages supportedCountries; //Field offset: 0x58

	public private List<Font> Fonts
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private List<LocalizationFont> localizationFonts
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LocalizationManager() { }

	[CompilerGenerated]
	private void <LoadLocalizedText>g__Load|21_0(TextAsset textAsset, ref <>c__DisplayClass21_0 unnamed_param_1) { }

	private void Awake() { }

	public void ChangeFont(Text text, FontType fontType) { }

	public KeyValuePair<Country, SupportedLanguage> FindLanguage(SystemLanguage systemLanguage) { }

	public List<SupportedLanguage> FindLaungaugesBySystem(SystemLanguage systemLanguage) { }

	[CompilerGenerated]
	public List<Font> get_Fonts() { }

	[CompilerGenerated]
	public List<LocalizationFont> get_localizationFonts() { }

	public string GetCountryCode() { }

	private string GetCountryCodeAndroid() { }

	private LocalizationFont GetLocalizationFont(FontType key) { }

	public LocalizedSentence GetLocalizedSentence(string key) { }

	public Dictionary<String, LocalizedSentence> GetLocalizedTextDic() { }

	public Country_SupportedLanguages GetSupportedCountries() { }

	public KeyValuePair<Country, SupportedLanguage> GetSupportedLanguage(string countryName, SystemLanguage systemLanguage) { }

	public List<SupportedLanguage> GetSupportedLanguages() { }

	public void InitSettings(GameLocalizationSettings settings) { }

	public void LoadLocalizedText(SupportedLanguage language) { }

	[CompilerGenerated]
	private void set_Fonts(List<Font> value) { }

	[CompilerGenerated]
	private void set_localizationFonts(List<LocalizationFont> value) { }

	public void SetLanguage(Country country, SupportedLanguage language) { }

	private void Start() { }

	public void ValidateCoreEnglish() { }

	public void ValidateCoreLanguages() { }

	public void ValidateEnglish(string resourcesPath) { }

	public void ValidateGameEnglish() { }

	public void ValidateGameLanguages() { }

	public void ValidateLanguages(string resourcesPath) { }

}

