namespace PWC.AvatarMaker;

public class CategoryData
{
	public int categoryType; //Field offset: 0x10
	public Sprite unpressedSprite; //Field offset: 0x18
	public Sprite pressedSprite; //Field offset: 0x20
	public bool isHiddenOnDefault; //Field offset: 0x28

	public CategoryData() { }

}

