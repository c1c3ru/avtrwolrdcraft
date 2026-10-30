namespace Spine.Unity;

public class BlendModeMaterials
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<SkeletonDataAsset> <>9__16_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <CreateAndAssignMaterials>b__16_0(SkeletonDataAsset asset) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public AtlasRegion originalRegion; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <CreateForRegion>b__0(ReplacementMaterial replacement) { }

	}

	internal sealed class CreateForRegionDelegate : MulticastDelegate
	{

		public CreateForRegionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref List<ReplacementMaterial>& replacementMaterials, ref bool anyReplacementMaterialsChanged, AtlasRegion originalRegion, Material materialTemplate, string materialSuffix, SkeletonDataAsset skeletonDataAsset, AsyncCallback callback, object object) { }

		public override bool EndInvoke(ref List<ReplacementMaterial>& replacementMaterials, ref bool anyReplacementMaterialsChanged, IAsyncResult result) { }

		public override bool Invoke(ref List<ReplacementMaterial>& replacementMaterials, ref bool anyReplacementMaterialsChanged, AtlasRegion originalRegion, Material materialTemplate, string materialSuffix, SkeletonDataAsset skeletonDataAsset) { }

	}

	internal class ReplacementMaterial
	{
		public string pageName; //Field offset: 0x10
		public Material material; //Field offset: 0x18

		public ReplacementMaterial() { }

	}

	internal class TemplateMaterials
	{
		public Material additiveTemplate; //Field offset: 0x10
		public Material multiplyTemplate; //Field offset: 0x18
		public Material screenTemplate; //Field offset: 0x20

		public TemplateMaterials() { }

	}

	public const string MATERIAL_SUFFIX_MULTIPLY = "-Multiply"; //Field offset: 0x0
	public const string MATERIAL_SUFFIX_SCREEN = "-Screen"; //Field offset: 0x0
	public const string MATERIAL_SUFFIX_ADDITIVE = "-Additive"; //Field offset: 0x0
	[HideInInspector]
	[SerializeField]
	protected bool requiresBlendModeMaterials; //Field offset: 0x10
	public bool applyAdditiveMaterial; //Field offset: 0x11
	public List<ReplacementMaterial> additiveMaterials; //Field offset: 0x18
	public List<ReplacementMaterial> multiplyMaterials; //Field offset: 0x20
	public List<ReplacementMaterial> screenMaterials; //Field offset: 0x28

	public bool RequiresBlendModeMaterials
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public BlendModeMaterials() { }

	public void ApplyMaterials(SkeletonData skeletonData) { }

	public BlendMode BlendModeForMaterial(Material material) { }

	protected AtlasRegion CloneAtlasRegionWithMaterial(AtlasRegion originalRegion, List<ReplacementMaterial> replacementMaterials) { }

	public static bool CreateAndAssignMaterials(SkeletonDataAsset skeletonDataAsset, TemplateMaterials templateMaterials, ref bool anyReplacementMaterialsChanged) { }

	public static bool CreateAndAssignMaterials(SkeletonDataAsset skeletonDataAsset, TemplateMaterials templateMaterials, ref bool anyReplacementMaterialsChanged, Action<SkeletonDataAsset> clearSkeletonDataAssetFunc, Action<SkeletonDataAsset> afterAssetModifiedFunc, CreateForRegionDelegate createForRegionFunc) { }

	protected static bool CreateForRegion(ref List<ReplacementMaterial>& replacementMaterials, ref bool anyReplacementMaterialsChanged, AtlasRegion originalRegion, Material materialTemplate, string materialSuffix, SkeletonDataAsset skeletonDataAsset) { }

	protected static ReplacementMaterial CreateReplacementMaterial(AtlasRegion originalRegion, Material materialTemplate, string materialSuffix) { }

	public bool get_RequiresBlendModeMaterials() { }

	public void set_RequiresBlendModeMaterials(bool value) { }

	public bool UpdateBlendmodeMaterialsRequiredState(SkeletonData skeletonData) { }

}

