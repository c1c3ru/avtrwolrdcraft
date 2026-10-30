namespace PWC.AvatarSpine;

public class TextureData
{
	public Texture2D Texture; //Field offset: 0x10
	public string TextureName; //Field offset: 0x18
	public int Counter; //Field offset: 0x20

	public TextureData(Texture2D texture, string textureName, int counter) { }

}

