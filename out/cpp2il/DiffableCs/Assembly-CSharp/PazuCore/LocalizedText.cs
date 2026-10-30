namespace PazuCore;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
	public bool ignoreRTL; //Field offset: 0x20
	public string key; //Field offset: 0x28
	public RTLData rtlData; //Field offset: 0x30
	private Text text; //Field offset: 0x38
	private FontStyle defaultFontStyle; //Field offset: 0x40
	private FontType fontType; //Field offset: 0x44

	public LocalizedText() { }

	private void Awake() { }

	public void ChangeText(string txt, FontType requestFontType) { }

	public void ChangeText(LocalizedSentence sentence) { }

}

