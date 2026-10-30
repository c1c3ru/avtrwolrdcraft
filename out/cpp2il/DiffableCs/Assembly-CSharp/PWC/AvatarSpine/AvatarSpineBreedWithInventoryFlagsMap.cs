namespace PWC.AvatarSpine;

public static class AvatarSpineBreedWithInventoryFlagsMap
{
	private static readonly Dictionary<SpineType, Dictionary`2<String, InventoryFlagType>> _dict; //Field offset: 0x0

	private static AvatarSpineBreedWithInventoryFlagsMap() { }

	public static bool CanUseBreed(SpineType spineType, string breed) { }

	public static string GetFirstValidBreed(SpineType spineType) { }

	public static bool TryGetBreedForFlag(SpineType spineType, InventoryFlagType flagType, out string breed) { }

}

