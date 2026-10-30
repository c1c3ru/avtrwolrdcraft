namespace TMPro;

[ExecuteAlways]
[RequireComponent(typeof(CanvasRenderer))]
public class TMP_SubMeshUI : MaskableGraphic
{
	[SerializeField]
	private TMP_FontAsset m_fontAsset; //Field offset: 0xD8
	[SerializeField]
	private TMP_SpriteAsset m_spriteAsset; //Field offset: 0xE0
	[SerializeField]
	private Material m_material; //Field offset: 0xE8
	[SerializeField]
	private Material m_sharedMaterial; //Field offset: 0xF0
	private Material m_fallbackMaterial; //Field offset: 0xF8
	private Material m_fallbackSourceMaterial; //Field offset: 0x100
	[SerializeField]
	private bool m_isDefaultMaterial; //Field offset: 0x108
	[SerializeField]
	private float m_padding; //Field offset: 0x10C
	private Mesh m_mesh; //Field offset: 0x110
	[SerializeField]
	private TextMeshProUGUI m_TextComponent; //Field offset: 0x118
	private bool m_isRegisteredForEvents; //Field offset: 0x120
	private bool m_materialDirty; //Field offset: 0x121
	[SerializeField]
	private int m_materialReferenceIndex; //Field offset: 0x124
	private Transform m_RootCanvasTransform; //Field offset: 0x128

	public Material fallbackMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 328
	}

	public Material fallbackSourceMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public TMP_FontAsset fontAsset
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool isDefaultMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public virtual Texture mainTexture
	{
		 get { } //Length: 188
	}

	public virtual Material material
	{
		 get { } //Length: 8
		 set { } //Length: 264
	}

	public virtual Material materialForRendering
	{
		 get { } //Length: 92
	}

	public Mesh mesh
	{
		 get { } //Length: 192
		 set { } //Length: 16
	}

	public float padding
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Material sharedMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public TMP_SpriteAsset spriteAsset
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_Text textComponent
	{
		 get { } //Length: 160
	}

	public TMP_SubMeshUI() { }

	public static TMP_SubMeshUI AddSubTextObject(TextMeshProUGUI textComponent, MaterialReference materialReference) { }

	private Material CreateMaterialInstance(Material source) { }

	public virtual void Cull(Rect clipRect, bool validRect) { }

	public Material get_fallbackMaterial() { }

	public Material get_fallbackSourceMaterial() { }

	public TMP_FontAsset get_fontAsset() { }

	public bool get_isDefaultMaterial() { }

	public virtual Texture get_mainTexture() { }

	public virtual Material get_material() { }

	public virtual Material get_materialForRendering() { }

	public Mesh get_mesh() { }

	public float get_padding() { }

	public Material get_sharedMaterial() { }

	public TMP_SpriteAsset get_spriteAsset() { }

	public TMP_Text get_textComponent() { }

	private Material GetMaterial(Material mat) { }

	private Material GetMaterial() { }

	public virtual Material GetModifiedMaterial(Material baseMaterial) { }

	public float GetPaddingForMaterial(Material mat) { }

	public float GetPaddingForMaterial() { }

	private Transform GetRootCanvasTransform() { }

	private Material GetSharedMaterial() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnTransformParentChanged() { }

	public virtual void Rebuild(CanvasUpdate update) { }

	public virtual void RecalculateClipping() { }

	public void RefreshMaterial() { }

	public void set_fallbackMaterial(Material value) { }

	public void set_fallbackSourceMaterial(Material value) { }

	public void set_fontAsset(TMP_FontAsset value) { }

	public void set_isDefaultMaterial(bool value) { }

	public virtual void set_material(Material value) { }

	public void set_mesh(Mesh value) { }

	public void set_padding(float value) { }

	public void set_sharedMaterial(Material value) { }

	public void set_spriteAsset(TMP_SpriteAsset value) { }

	public virtual void SetAllDirty() { }

	public virtual void SetLayoutDirty() { }

	public virtual void SetMaterialDirty() { }

	public void SetPivotDirty() { }

	private void SetSharedMaterial(Material mat) { }

	public virtual void SetVerticesDirty() { }

	protected virtual void UpdateGeometry() { }

	protected virtual void UpdateMaterial() { }

	public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold) { }

}

