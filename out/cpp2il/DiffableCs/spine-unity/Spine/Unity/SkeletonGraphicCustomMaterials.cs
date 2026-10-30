namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonGraphicCustomMaterials")]
public class SkeletonGraphicCustomMaterials : MonoBehaviour
{
	internal struct AtlasMaterialOverride : IEquatable<AtlasMaterialOverride>
	{
		public bool overrideEnabled; //Field offset: 0x0
		public Texture originalTexture; //Field offset: 0x8
		public Material replacementMaterial; //Field offset: 0x10

		public override bool Equals(AtlasMaterialOverride other) { }

	}

	internal struct AtlasTextureOverride : IEquatable<AtlasTextureOverride>
	{
		public bool overrideEnabled; //Field offset: 0x0
		public Texture originalTexture; //Field offset: 0x8
		public Texture replacementTexture; //Field offset: 0x10

		public override bool Equals(AtlasTextureOverride other) { }

	}

	public SkeletonGraphic skeletonGraphic; //Field offset: 0x20
	[SerializeField]
	protected List<AtlasMaterialOverride> customMaterialOverrides; //Field offset: 0x28
	[SerializeField]
	protected List<AtlasTextureOverride> customTextureOverrides; //Field offset: 0x30

	public SkeletonGraphicCustomMaterials() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void RemoveCustomMaterialOverrides() { }

	private void RemoveCustomTextureOverrides() { }

	private void SetCustomMaterialOverrides() { }

	private void SetCustomTextureOverrides() { }

}

