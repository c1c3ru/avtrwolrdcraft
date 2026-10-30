namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRendererCustomMaterials")]
public class SkeletonRendererCustomMaterials : MonoBehaviour
{
	internal struct AtlasMaterialOverride : IEquatable<AtlasMaterialOverride>
	{
		public bool overrideDisabled; //Field offset: 0x0
		public Material originalMaterial; //Field offset: 0x8
		public Material replacementMaterial; //Field offset: 0x10

		public override bool Equals(AtlasMaterialOverride other) { }

	}

	internal struct SlotMaterialOverride : IEquatable<SlotMaterialOverride>
	{
		public bool overrideDisabled; //Field offset: 0x0
		[SpineSlot(null, null, False, True, False)]
		public string slotName; //Field offset: 0x8
		public Material material; //Field offset: 0x10

		public override bool Equals(SlotMaterialOverride other) { }

	}

	public SkeletonRenderer skeletonRenderer; //Field offset: 0x20
	[SerializeField]
	protected List<SlotMaterialOverride> customSlotMaterials; //Field offset: 0x28
	[SerializeField]
	protected List<AtlasMaterialOverride> customMaterialOverrides; //Field offset: 0x30

	public SkeletonRendererCustomMaterials() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void RemoveCustomMaterialOverrides() { }

	private void RemoveCustomSlotMaterials() { }

	private void SetCustomMaterialOverrides() { }

	private void SetCustomSlotMaterials() { }

}

