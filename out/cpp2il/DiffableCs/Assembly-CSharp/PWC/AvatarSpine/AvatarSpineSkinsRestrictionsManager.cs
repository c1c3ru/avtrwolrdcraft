namespace PWC.AvatarSpine;

public static class AvatarSpineSkinsRestrictionsManager
{
	internal class SkinsRestrictionItem
	{
		public string skinName; //Field offset: 0x10
		public HashSet<AvatarSizeType> characterSizeTypes; //Field offset: 0x18

		public SkinsRestrictionItem() { }

	}

	internal class SkinsRestrictionRawDataItem
	{
		public SpineType spineType; //Field offset: 0x10
		public AvatarSizeType characterSizeType; //Field offset: 0x14
		public HashSet<String> skinNames; //Field offset: 0x18

		public SkinsRestrictionRawDataItem() { }

	}

	private static readonly List<SkinsRestrictionRawDataItem> _skinsRestrictionRawDataItems; //Field offset: 0x0
	private static Dictionary<SpineType, Dictionary`2<String, SkinsRestrictionItem>> _map; //Field offset: 0x8

	private static AvatarSpineSkinsRestrictionsManager() { }

	private static void EnsureMap() { }

	public static bool IsSkinAllowed(SpineType spineType, AvatarSizeType characterSizeType, string skinName) { }

	public static bool IsSkinNotAllowed(SpineType spineType, AvatarSizeType characterSizeType, string skinName) { }

}

