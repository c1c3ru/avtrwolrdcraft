namespace UnityEngine.U2D;

[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
[NativeType(Header = "Runtime/2D/SpriteAtlas/SpriteAtlas.h")]
public class SpriteAtlas : object
{

	public int spriteCount
	{
		 get { } //Length: 60
	}

	public SpriteAtlas() { }

	public bool CanBindTo(Sprite sprite) { }

	public int get_spriteCount() { }

	public Sprite GetSprite(string name) { }

	public int GetSprites(Sprite[] sprites) { }

	private int GetSpritesScripting(Sprite[] sprites) { }

}

