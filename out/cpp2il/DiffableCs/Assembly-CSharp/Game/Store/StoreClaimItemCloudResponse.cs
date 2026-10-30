namespace Game.Store;

public class StoreClaimItemCloudResponse : Response
{
	internal class PackInBundle
	{
		public string prefabGuid; //Field offset: 0x10
		public string itemGuid; //Field offset: 0x18
		public Dictionary<String, Int32> flags; //Field offset: 0x20

		public PackInBundle() { }

	}

	internal enum StoreClaimErrorType
	{
		None = 0,
		NoItemGuid = 1,
		PrefabNotFound = 2,
	}

	public readonly string packName; //Field offset: 0x58
	public readonly string itemGuid; //Field offset: 0x60
	public readonly string prefabGuid; //Field offset: 0x68
	public readonly Dictionary<String, Int32> flags; //Field offset: 0x70
	public readonly bool useInventory; //Field offset: 0x78
	public readonly PDPrefab prefab; //Field offset: 0x80
	public readonly bool isCoupon; //Field offset: 0x88
	public readonly bool isBundle; //Field offset: 0x89
	public readonly bool isAvatarPass; //Field offset: 0x8A
	public readonly StoreClaimErrorType storeClaimErrorType; //Field offset: 0x8C
	public readonly string transactionId; //Field offset: 0x90
	public readonly bool isCurrency; //Field offset: 0x98
	public readonly Nullable<Int32> currencyBalance; //Field offset: 0x9C
	public readonly Nullable<Int32> loyaltyPointsBalance; //Field offset: 0xA4
	public readonly bool hasReachedMaxClaims; //Field offset: 0xAC
	public readonly Item itemToClaimNext; //Field offset: 0xB0
	public readonly bool isOneTimeClaim; //Field offset: 0xB8
	public readonly List<PackInBundle> packsInBundle; //Field offset: 0xC0

	public StoreClaimItemCloudResponse(string responseText) { }

}

