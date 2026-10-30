namespace PWC.AvatarSpine;

public static class SpineDefaultBreedDataUtils
{
	private static Dictionary<SpineType, Dictionary`2<String, BreedDefaultData>> _allByName; //Field offset: 0x0
	private static Dictionary<SpineType, Dictionary`2<String, BreedDefaultData>> _defaults; //Field offset: 0x8
	private static Dictionary<SpineType, List`1<BreedDefaultData>> _dict; //Field offset: 0x10

	[CompilerGenerated]
	internal static Color <EnsureData>g__GetColor|3_1(String[] columns, Dictionary<String, Int32> headersIndexes, string headerName) { }

	[CompilerGenerated]
	internal static float <EnsureData>g__GetFloat|3_0(String[] columns, Dictionary<String, Int32> headersIndexes, string headerName) { }

	[CompilerGenerated]
	internal static string <EnsureData>g__GetString|3_2(String[] columns, Dictionary<String, Int32> headersIndexes, string headerName) { }

	private static void EnsureData() { }

	public static bool TryApplyData(SpineType spineType, AvatarSpineSkinsManagerBase skinsManager, BreedDefaultData breedDefaultData) { }

	public static bool TryGetDataByName(SpineType spineType, string name, out BreedDefaultData data) { }

	public static bool TryGetDefaultData(SpineType spineType, string breed, out BreedDefaultData data) { }

	public static bool TryGetSpineTypeData(SpineType spineType, out IReadOnlyList<BreedDefaultData>& dataList) { }

}

