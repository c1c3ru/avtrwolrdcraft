namespace PazuCore.PazuCloud;

public class UserDataResponse : Response
{
	internal class ProfileData
	{
		public string id; //Field offset: 0x10
		public long lastSaveDate; //Field offset: 0x18

		public ProfileData() { }

	}

	public readonly bool isActiveSubscription; //Field offset: 0x58
	public readonly bool isActiveDevice; //Field offset: 0x59
	public readonly UserType userType; //Field offset: 0x5C
	public readonly bool isAvatarPassSubscriptionActive; //Field offset: 0x60
	public readonly bool isAvatarPassSubscriber; //Field offset: 0x61
	public readonly bool didRegisterToAvatarId; //Field offset: 0x62
	public readonly InventoryData inventoryData; //Field offset: 0x68
	public readonly List<ProfileData> avatarIdProfiles; //Field offset: 0x70
	public readonly bool isGoogleIntegrityTokenRequired; //Field offset: 0x78
	public readonly int pazuCurrency; //Field offset: 0x7C
	public readonly int loyaltyPoints; //Field offset: 0x80

	public UserDataResponse(string responseText) { }

}

