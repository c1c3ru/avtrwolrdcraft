namespace Spine.Unity;

[CreateAssetMenu(menuName = "Spine/SkeletonData Modifiers/Blend Mode Materials", order = 200)]
public class BlendModeMaterialsAsset : SkeletonDataModifierAsset
{
	private class AtlasMaterialCache : IDisposable
	{
		private readonly Dictionary<KeyValuePair`2<AtlasPage, Material>, AtlasPage> cache; //Field offset: 0x10

		public AtlasMaterialCache() { }

		public AtlasRegion CloneAtlasRegionWithMaterial(AtlasRegion originalRegion, Material materialTemplate) { }

		public override void Dispose() { }

		private AtlasPage GetAtlasPageWithMaterial(AtlasPage originalPage, Material materialTemplate) { }

	}

	public Material multiplyMaterialTemplate; //Field offset: 0x18
	public Material screenMaterialTemplate; //Field offset: 0x20
	public Material additiveMaterialTemplate; //Field offset: 0x28
	public bool applyAdditiveMaterial; //Field offset: 0x30

	public BlendModeMaterialsAsset() { }

	public virtual void Apply(SkeletonData skeletonData) { }

	public static void ApplyMaterials(SkeletonData skeletonData, Material multiplyTemplate, Material screenTemplate, Material additiveTemplate, bool includeAdditiveSlots) { }

}

