namespace BWYW;

public class BWYWGiftData : ScriptableObject
{
	[SerializeField]
	private PDPrefabReference _giftWrapperPDReference; //Field offset: 0x18
	[SerializeField]
	[TasksList(typeof(BWYWGiftBase))]
	private GiftContainer _giftsList; //Field offset: 0x20

	public List<BWYWGiftBase> giftsList
	{
		 get { } //Length: 28
	}

	public PDPrefabReference GiftWrapperPDReference
	{
		 get { } //Length: 8
	}

	public int numOfGifts
	{
		 get { } //Length: 80
	}

	public BWYWGiftData() { }

	public List<BWYWGiftBase> get_giftsList() { }

	public PDPrefabReference get_GiftWrapperPDReference() { }

	public int get_numOfGifts() { }

}

