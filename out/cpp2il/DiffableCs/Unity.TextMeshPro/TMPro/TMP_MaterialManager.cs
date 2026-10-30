namespace TMPro;

public static class TMP_MaterialManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Material stencilMaterial; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <AddMaskingMaterial>b__0(MaskingMaterial item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Material stencilMaterial; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal bool <RemoveStencilMaterial>b__0(MaskingMaterial item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public Material baseMaterial; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <ReleaseBaseMaterial>b__0(MaskingMaterial item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Material stencilMaterial; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <GetBaseMaterial>b__0(MaskingMaterial item) { }

	}

	private class FallbackMaterial
	{
		public long fallbackID; //Field offset: 0x10
		public Material sourceMaterial; //Field offset: 0x18
		internal int sourceMaterialCRC; //Field offset: 0x20
		public Material fallbackMaterial; //Field offset: 0x28
		public int count; //Field offset: 0x30

		public FallbackMaterial() { }

	}

	private class MaskingMaterial
	{
		public Material baseMaterial; //Field offset: 0x10
		public Material stencilMaterial; //Field offset: 0x18
		public int count; //Field offset: 0x20
		public int stencilID; //Field offset: 0x24

		public MaskingMaterial() { }

	}

	private static List<MaskingMaterial> m_materialList; //Field offset: 0x0
	private static Dictionary<Int64, FallbackMaterial> m_fallbackMaterials; //Field offset: 0x8
	private static Dictionary<Int32, Int64> m_fallbackMaterialLookup; //Field offset: 0x10
	private static List<FallbackMaterial> m_fallbackCleanupList; //Field offset: 0x18
	private static bool isFallbackListDirty; //Field offset: 0x20

	private static TMP_MaterialManager() { }

	public static void AddFallbackMaterialReference(Material targetMaterial) { }

	public static void AddMaskingMaterial(Material baseMaterial, Material stencilMaterial, int stencilID) { }

	public static void CleanupFallbackMaterials() { }

	public static void ClearMaterials() { }

	public static void CopyMaterialPresetProperties(Material source, Material destination) { }

	private static Transform FindRootSortOverrideCanvas(Transform start) { }

	public static Material GetBaseMaterial(Material stencilMaterial) { }

	internal static Material GetFallbackMaterial(TMP_FontAsset fontAsset, Material sourceMaterial, int atlasIndex) { }

	public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial) { }

	public static Material GetMaterialForRendering(MaskableGraphic graphic, Material baseMaterial) { }

	public static int GetStencilID(GameObject obj) { }

	public static Material GetStencilMaterial(Material baseMaterial, int stencilID) { }

	private static void OnPreRender() { }

	public static void ReleaseBaseMaterial(Material baseMaterial) { }

	public static void ReleaseFallbackMaterial(Material fallbackMaterial) { }

	public static void ReleaseStencilMaterial(Material stencilMaterial) { }

	public static void RemoveFallbackMaterialReference(Material targetMaterial) { }

	public static void RemoveStencilMaterial(Material stencilMaterial) { }

	public static Material SetStencil(Material material, int stencilID) { }

}

