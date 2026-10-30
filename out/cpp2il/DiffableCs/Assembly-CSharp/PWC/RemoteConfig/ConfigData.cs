namespace PWC.RemoteConfig;

public class ConfigData
{
	internal enum AvatarIdAvailabilityType
	{
		None = 0,
		Disabled = 1,
		Enabled = 2,
		ComingSoon = 3,
	}

	internal class PackCurrencyRefundable
	{
		public string refundableId; //Field offset: 0x10
		public string packName; //Field offset: 0x18
		public int price; //Field offset: 0x20

		public PackCurrencyRefundable() { }

	}

	internal class ZoneBuildingItem
	{
		internal enum Type
		{
			None = 0,
			Playable = 1,
			UnderConstruction = 2,
			UpdateAvailable = 3,
			EarlyAccess = 4,
		}

		public int id; //Field offset: 0x10
		public string iconUrl; //Field offset: 0x18
		public string coverUrl; //Field offset: 0x20
		public string videoUrl; //Field offset: 0x28
		public Type type; //Field offset: 0x30
		public bool isFree; //Field offset: 0x34

		public ZoneBuildingItem() { }

		public bool IsReady(bool checkIcon) { }

		private bool IsTextrueReady(string url) { }

	}

	public bool isMultiplayerEnabled; //Field offset: 0x10
	public ZoneBuildingItem[] zoneBuildingItems; //Field offset: 0x18
	private Dictionary<Int32, ZoneBuildingItem> _hashedZoneBuildingItems; //Field offset: 0x20
	public int liveBuildNumber; //Field offset: 0x28
	public AvatarIdAvailabilityType avatarIdAvailabilityType; //Field offset: 0x2C
	public bool shouldShowAvatarPassConsentPopup; //Field offset: 0x30
	public bool shouldShowBirthdayWidget; //Field offset: 0x31
	public bool isRTAEnabled; //Field offset: 0x32
	public string homeWidgetSecretsCollectionId; //Field offset: 0x38
	public List<PackCurrencyRefundable> packCurrencyRefundables; //Field offset: 0x40
	public String[] activeSecretsCollectionsIds; //Field offset: 0x48
	[CompilerGenerated]
	private bool <IsValid>k__BackingField; //Field offset: 0x50

	public bool IsValid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public ConfigData() { }

	[CompilerGenerated]
	public bool get_IsValid() { }

	[CompilerGenerated]
	public void set_IsValid(bool value) { }

	public bool TryGetBuildingData(int buildId, out ZoneBuildingItem item) { }

}

