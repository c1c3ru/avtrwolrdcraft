namespace PWC.AvatarSpine;

public abstract class AvatarSpineMaterialsManager : MonoBehaviour
{
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	private Skin _skin; //Field offset: 0x28
	private Material[] _materialsBeforeAddSkin; //Field offset: 0x30
	private Shader _singleColorShader; //Field offset: 0x38
	private Shader _gradientShader; //Field offset: 0x40
	private Shader _multiColorShader; //Field offset: 0x48
	private bool _isMaskedInLevel; //Field offset: 0x50
	private bool _isVisibleInsideMaskInLevel; //Field offset: 0x51

	protected AvatarSpineMaterialsManager() { }

	public void AddSkinImplement(Skin skin, AvatarSpineColoringConfig coloringConfig, SpineType spineType) { }

	public static void ColorMaterial(Material material, AvatarSpineColoringConfig coloringConfig, Color[] colors, object context) { }

	public void ColorSkinImplement(AvatarSpineColoringConfig coloringConfig, Skin skin, Color[] colors) { }

	private void CreateCustomMaterialsIfNeeded(List<Material> materials, AvatarSpineColoringConfig coloringConfig, SpineType spineType) { }

	public void EnsureSpine() { }

	protected List<Material> GetOriginalSkinMaterials(Skin skin) { }

	public SkeletonAnimation GetSkeletonAnimation() { }

	protected Color[] GetSkinColorImplement(AvatarSpineColoringType avatarSpineColoringType, Skin skin) { }

	protected void InitImplement() { }

	public void PrepareToAddSkin() { }

	private void RefreshSkeletonAnimation() { }

	public void RemoveSkinImplement(SpineType spineType, Skin skin, bool refreshSkeletonAnimation = true) { }

	public void ResetCurrentMaterialsStencilValues() { }

	public void SetMaskedInLevel(bool value, bool isVisibleInsideMask) { }

	public void SetMaskedInPhone(int stencilRefBuffer) { }

	protected void SUTColorSkinImplement(AvatarSpineColoringConfig coloringConfig, List<Material> materials, Color[] colors) { }

	protected void SUTInitMaterial(Material material, AvatarSpineColoringType avatarSpineColoringType) { }

	public void SUTRemoveSkinsImplement(List<Skin> skins, bool refreshSkeletonAnimation = true) { }

}

