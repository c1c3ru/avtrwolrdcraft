namespace PWC.AvatarSpine;

[Extension]
public static class AvatarSizeTypeExtensionMethods
{
	private static readonly Dictionary<SpineType, Dictionary`2<String, Dictionary`2<AvatarSizeType, Single>>> _petsSizes; //Field offset: 0x0

	private static AvatarSizeTypeExtensionMethods() { }

	[Extension]
	public static float GetScaleFactor(AvatarSizeType avatarSizeType, SpineType spineType, string breed = null) { }

}

