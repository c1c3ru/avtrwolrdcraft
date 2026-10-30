namespace PazuCore;

public class SupportedLanguage
{
	public SystemLanguage systemLanguage; //Field offset: 0x10
	public string textAssetName; //Field offset: 0x18
	public bool isLocalaized; //Field offset: 0x20
	public FontType fontType; //Field offset: 0x24
	public string languageKey; //Field offset: 0x28
	public bool isRTL; //Field offset: 0x30

	public SupportedLanguage() { }

}

