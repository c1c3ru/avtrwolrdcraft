namespace PWC.AvatarSpine;

public static class AvatarSpineUtils
{
	public const string ORIGINAL_TEXTURES_RESOURCES_PATH = "AvatarSpine/OriginalTextures"; //Field offset: 0x0
	public const float STENCIL_REF_FOR_UI_MASK = 1; //Field offset: 0x0
	private static int _currentEyeStencilRef; //Field offset: 0x0

	private static AvatarSpineUtils() { }

	public static void EnsureColorsArray(ref Color[] colors, int requiredCount, SpineType spineType, string skinName) { }

	public static void EnsureColorsArray(ref Color[] colors, AvatarSpineColoringConfig coloringConfig, SpineType spineType, string skinName) { }

	public static void EnsureColorsArray(ref Color[] colors, SpineType spineType, int categoryType, string skinName) { }

	public static void EnsureColorsArray(ref Color[] colors, int requiredCount, Color[] defaultColors = null) { }

	public static Material[] GetCustomMaterials(SkeletonAnimation skeletonAnimation) { }

	public static void InitEyesStencilValues(SkeletonAnimation skeletonAnimation, Skin eyesBaseSkin, Skin eyesPupilsSkin, bool isMaskedInUI) { }

	public static void ResetEyeStencilRefCount() { }

	public static void SetMaterialsUnused(SkeletonAnimation skeletonAnimation, bool isOriginalMaterials, List<Material> materials, SpineType spineType) { }

	public static void SetOriginalTextureToCustomMaterial(Material customMaterial, SpineType spineType) { }

	private static void SetStencilValues(SkeletonAnimation skeletonAnimation, Skin skin, float stencilRef, CompareFunction compareFunction, StencilOp stencilOp) { }

	public static bool TryAddMaskedEyesToAvatar(AvatarSpineSkinsManagerBase skinsManager, string skinName, AvatarSpineColoringConfig coloringConfig, Color[] colors, String[] extraSkinNameFormats) { }

	public static bool TryGetBreedFromSkinName(string skinName, out string breed) { }

	public static bool TryGetDefaultBreed(SpineType spineType, out string breed) { }

	public static bool TryGetFirstBreed(SkeletonAnimation skeletonAnimation, out string breed) { }

	public static bool TryOverrideAddSkinParameters(AvatarSpineSkinsManagerBase skinsManager, SpineType spineType, ref int categoryType, ref string skinName) { }

	public static bool TryOverrideEyesAddSkinParameters(AvatarSpineSkinsManagerBase skinsManager, SpineType spineType, ref int categoryType, ref string skinName) { }

}

