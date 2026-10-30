namespace PWC;

public static class PWCAvatarsUtils
{
	public const int HUMAN_MIN_NUM_OF_AVATARS = 3; //Field offset: 0x0
	public const int CAR_MIN_NUM_OF_AVATARS = 1; //Field offset: 0x0
	public const int CAR_SLOTS_PER_BREED_PACK = 1; //Field offset: 0x0
	public const int PREMADE_CAR_MIN_ID = 100000; //Field offset: 0x0

	[CompilerGenerated]
	internal static bool <GetNumberOfUnlockedAvatars>g__ContainsFlag|6_0(InventoryFlagType flag) { }

	public static int GetNumberOfUnlockedAvatars(AvatarType avatarType) { }

	public static bool HasAvatarsPackOrSubscription() { }

	public static bool IsPremadeCar(int carId) { }

	public static bool TryGetAvatarTypeFromAvatarID(int avatarId, out AvatarType avatarType) { }

	public static bool TryGetCarSlotsPackToOffer(out InventoryFlagType flagType) { }

}

