namespace PWC.SUTSystem;

[Extension]
public static class SUTUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__12_0; //Field offset: 0x8
		public static Func<String, String> <>9__12_1; //Field offset: 0x10
		public static Func<String, String> <>9__12_2; //Field offset: 0x18
		public static Func<Texture2D, String> <>9__13_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <GetAllSkinsNamesFromFolders>b__12_0(string x) { }

		internal string <GetAllSkinsNamesFromFolders>b__12_1(string x) { }

		internal string <GetAllSkinsNamesFromFolders>b__12_2(string x) { }

		internal string <GetSUTsNamesFromSkinName>b__13_0(Texture2D x) { }

	}

	public const string ROOT_FOLDER = "SUTSystem/Skins/"; //Field offset: 0x0
	private static readonly Dictionary<String, Dictionary`2<String, String>> _pathsCache; //Field offset: 0x0
	private static readonly Dictionary<ValueTuple`2<String, String>, Texture2D[]> _texturesCache; //Field offset: 0x8

	private static SUTUtils() { }

	public static void ClearTexturesCache() { }

	[Extension]
	public static int FindBoneIndex(Skeleton skeleton, string boneName) { }

	public static String[] GetAllSkinsNamesFromFolders(string directoryPath) { }

	public static String[] GetAllSkinsNamesFromFoldersBySpineType(SpineType spineType) { }

	public static string GetResourcesPath(string spineKey, string itemKey) { }

	public static string GetSkinNameForSUTSkin(SpineType spineType, string skinName) { }

	public static string GetSkinTypeFromClothingName(string clothingName) { }

	public static String[] GetSUTsNamesFromSkinName(SpineType spineType, string skinName) { }

	public static bool IsColoredSkin(string skinName) { }

	public static bool IsSkinNameValid(string skinName, int categoryType, SpineType spineType) { }

	private static void RefreshSkeletonAnimation(SkeletonAnimation skeletonAnimation) { }

	public static bool SetTextures(string spineKey, string itemKey, Texture2D[] textures) { }

	public static bool TryAddSkin(string spineKey, string itemKey, SkeletonAnimation skeletonAnimation, Action<Material> initMaterial = null, List<Skin> addedSkins = null, List<Material> addedMaterials = null, bool refreshSkeletonAnimation = true, HashSet<String> excludedSkins = null) { }

	public static bool TryGetTextures(string spineKey, string itemKey, out Texture2D[] textures) { }

}

