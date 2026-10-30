namespace TMPro;

public struct TMP_WordInfo
{
	public TMP_Text textComponent; //Field offset: 0x0
	public int firstCharacterIndex; //Field offset: 0x8
	public int lastCharacterIndex; //Field offset: 0xC
	public int characterCount; //Field offset: 0x10

	public string GetWord() { }

}

