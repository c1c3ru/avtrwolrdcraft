namespace Spine.Unity;

[CreateAssetMenu(fileName = "New SkeletonDataAsset", menuName = "Spine/SkeletonData Asset")]
public class SkeletonDataAsset : ScriptableObject
{
	public AtlasAssetBase[] atlasAssets; //Field offset: 0x18
	public float scale; //Field offset: 0x20
	public TextAsset skeletonJSON; //Field offset: 0x28
	public bool isUpgradingBlendModeMaterials; //Field offset: 0x30
	public BlendModeMaterials blendModeMaterials; //Field offset: 0x38
	[Tooltip("Use SkeletonDataModifierAssets to apply changes to the SkeletonData after being loaded, such as apply blend mode Materials to Attachments under slots with special blend modes.")]
	public List<SkeletonDataModifierAsset> skeletonDataModifiers; //Field offset: 0x40
	[SpineAnimation(null, null, False, False, False)]
	public String[] fromAnimation; //Field offset: 0x48
	[SpineAnimation(null, null, False, False, False)]
	public String[] toAnimation; //Field offset: 0x50
	public Single[] duration; //Field offset: 0x58
	public float defaultMix; //Field offset: 0x60
	public RuntimeAnimatorController controller; //Field offset: 0x68
	private SkeletonData skeletonData; //Field offset: 0x70
	private AnimationStateData stateData; //Field offset: 0x78

	public bool IsLoaded
	{
		 get { } //Length: 16
	}

	public SkeletonDataAsset() { }

	public void Clear() { }

	public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAssetBase atlasAsset, bool initialize, float scale = 0,01) { }

	public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAssetBase[] atlasAssets, bool initialize, float scale = 0,01) { }

	public void FillStateData(bool quiet = false) { }

	public bool get_IsLoaded() { }

	public AnimationStateData GetAnimationStateData() { }

	internal Atlas[] GetAtlasArray() { }

	public SkeletonData GetSkeletonData(bool quiet) { }

	internal void InitializeWithData(SkeletonData sd) { }

	internal static SkeletonData ReadSkeletonData(Byte[] bytes, AttachmentLoader attachmentLoader, float scale) { }

	internal static SkeletonData ReadSkeletonData(Stream assetStream, AttachmentLoader attachmentLoader, float scale) { }

	internal static SkeletonData ReadSkeletonData(string text, AttachmentLoader attachmentLoader, float scale) { }

	private void Reset() { }

	public void SetupRuntimeBlendModeMaterials(bool applyAdditiveMaterial, TemplateMaterials templateMaterials) { }

}

