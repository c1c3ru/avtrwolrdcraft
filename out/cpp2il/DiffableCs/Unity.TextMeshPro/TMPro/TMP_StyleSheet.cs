namespace TMPro;

[ExcludeFromPreset]
public class TMP_StyleSheet : ScriptableObject
{
	[SerializeField]
	private List<TMP_Style> m_StyleList; //Field offset: 0x18
	private Dictionary<Int32, TMP_Style> m_StyleLookupDictionary; //Field offset: 0x20

	internal List<TMP_Style> styles
	{
		internal get { } //Length: 8
	}

	public TMP_StyleSheet() { }

	internal List<TMP_Style> get_styles() { }

	public TMP_Style GetStyle(int hashCode) { }

	public TMP_Style GetStyle(string name) { }

	private void LoadStyleDictionaryInternal() { }

	public void RefreshStyles() { }

	private void Reset() { }

}

