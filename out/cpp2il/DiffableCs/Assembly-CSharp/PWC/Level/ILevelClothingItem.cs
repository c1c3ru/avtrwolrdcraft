namespace PWC.Level;

public interface ILevelClothingItem
{

	public Item ClothingMapItem
	{
		 get { } //Length: 0
	}

	public AvatarSpineColoringConfig ColoringConfig
	{
		 get { } //Length: 0
	}

	public Color[] Colors
	{
		 get { } //Length: 0
	}

	public bool IsRestoredClothingItem
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Item get_ClothingMapItem() { }

	public AvatarSpineColoringConfig get_ColoringConfig() { }

	public Color[] get_Colors() { }

	public bool get_IsRestoredClothingItem() { }

	public int GetCategoryType() { }

	public string GetConventionItemName() { }

	public LevelItem GetLevelItem() { }

	public string GetSkinName() { }

	public SpineType GetSpineType() { }

	public bool IsCompatibleWithSpineType(SpineType spineType) { }

	public void set_IsRestoredClothingItem(bool value) { }

}

