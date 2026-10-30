namespace PWC.AvatarSpine;

[Extension]
public static class SpineTypeExtensionMethods
{

	[Extension]
	public static Type GetCategoryTypeEnumType(SpineType spineType) { }

	[Extension]
	public static AvatarSizeType GetDefaultSizeType(SpineType spineType) { }

	[Extension]
	public static SpineType GetSpineTypeForClothing(SpineType spineType, int categoryType) { }

	[Extension]
	public static bool HasCAPrefixForCAAnimations(SpineType spineType) { }

	[Extension]
	public static bool IsCategoryNameInSkinName(SpineType spineType) { }

	[Extension]
	public static bool IsUsingAvatarSpineSystem(SpineType spineType) { }

	[Extension]
	public static bool ShouldUseScaleFactor(SpineType spineType) { }

	[Extension]
	public static bool TryGetAvatarType(SpineType spineType, out AvatarType avatarType) { }

}

