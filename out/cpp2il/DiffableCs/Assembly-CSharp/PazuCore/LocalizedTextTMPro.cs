namespace PazuCore;

public class LocalizedTextTMPro : MonoBehaviour
{
	public bool ignoreRTL; //Field offset: 0x20
	public string key; //Field offset: 0x28
	public List<String> formats; //Field offset: 0x30
	public RTLData rtlData; //Field offset: 0x38
	public bool changeFontToLangauge; //Field offset: 0x40
	public bool isInputField; //Field offset: 0x41
	public bool ignoreCurrentFont; //Field offset: 0x42

	public LocalizedTextTMPro() { }

	protected override void Awake() { }

	public void ChangeText(string txt, FontType requestFontType) { }

	public void ChangeText(LocalizedSentence sentence) { }

}

