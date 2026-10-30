namespace TMPro;

public struct TMP_LinkInfo
{
	public TMP_Text textComponent; //Field offset: 0x0
	public int hashCode; //Field offset: 0x8
	public int linkIdFirstCharacterIndex; //Field offset: 0xC
	public int linkIdLength; //Field offset: 0x10
	public int linkTextfirstCharacterIndex; //Field offset: 0x14
	public int linkTextLength; //Field offset: 0x18
	internal Char[] linkID; //Field offset: 0x20

	public string GetLinkID() { }

	public string GetLinkText() { }

	internal void SetLinkID(Char[] text, int startIndex, int length) { }

}

