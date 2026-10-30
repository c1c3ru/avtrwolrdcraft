namespace BWYW;

public class ItemGift : BWYWGiftBase
{
	[SerializeField]
	private PDPrefabReference _giftItemReference; //Field offset: 0x28
	[SerializeField]
	private LevelType _levelToSpawn; //Field offset: 0x30

	public PDPrefabReference GiftItemReference
	{
		 get { } //Length: 8
	}

	public LevelType LevelToSpawn
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ItemGift() { }

	public PDPrefabReference get_GiftItemReference() { }

	public LevelType get_LevelToSpawn() { }

	public void set_LevelToSpawn(LevelType value) { }

}

