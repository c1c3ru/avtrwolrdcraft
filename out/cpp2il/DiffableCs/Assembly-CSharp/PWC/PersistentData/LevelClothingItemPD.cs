namespace PWC.PersistentData;

public class LevelClothingItemPD
{
	public int categoryType; //Field offset: 0x10
	public string skinName; //Field offset: 0x18
	public Color[] colors; //Field offset: 0x20
	public bool hasColors; //Field offset: 0x28
	public Color topColor; //Field offset: 0x2C
	public Color bottomColor; //Field offset: 0x3C

	public LevelClothingItemPD() { }

	public virtual string ToString() { }

}

