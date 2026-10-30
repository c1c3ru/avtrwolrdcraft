namespace TMPro;

public class TMP_SpriteCharacter : TMP_TextElement
{
	[SerializeField]
	private string m_Name; //Field offset: 0x30
	[SerializeField]
	private int m_HashCode; //Field offset: 0x38

	public int hashCode
	{
		 get { } //Length: 8
	}

	public string name
	{
		 get { } //Length: 8
		 set { } //Length: 148
	}

	public TMP_SpriteCharacter() { }

	public TMP_SpriteCharacter(uint unicode, TMP_SpriteGlyph glyph) { }

	public TMP_SpriteCharacter(uint unicode, TMP_SpriteAsset spriteAsset, TMP_SpriteGlyph glyph) { }

	internal TMP_SpriteCharacter(uint unicode, uint glyphIndex) { }

	public int get_hashCode() { }

	public string get_name() { }

	public void set_name(string value) { }

}

