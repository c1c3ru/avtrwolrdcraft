namespace TMPro;

[AddComponentMenu("Mesh/TextMeshPro - Text")]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
[RequireComponent(typeof(MeshRenderer))]
public class TextMeshPro : TMP_Text, ILayoutElement
{
	private static ProfilerMarker k_GenerateTextMarker; //Field offset: 0x0
	private static ProfilerMarker k_SetArraySizesMarker; //Field offset: 0x8
	private static ProfilerMarker k_GenerateTextPhaseIMarker; //Field offset: 0x10
	private static ProfilerMarker k_ParseMarkupTextMarker; //Field offset: 0x18
	private static ProfilerMarker k_CharacterLookupMarker; //Field offset: 0x20
	private static ProfilerMarker k_HandleGPOSFeaturesMarker; //Field offset: 0x28
	private static ProfilerMarker k_CalculateVerticesPositionMarker; //Field offset: 0x30
	private static ProfilerMarker k_ComputeTextMetricsMarker; //Field offset: 0x38
	private static ProfilerMarker k_HandleVisibleCharacterMarker; //Field offset: 0x40
	private static ProfilerMarker k_HandleWhiteSpacesMarker; //Field offset: 0x48
	private static ProfilerMarker k_HandleHorizontalLineBreakingMarker; //Field offset: 0x50
	private static ProfilerMarker k_HandleVerticalLineBreakingMarker; //Field offset: 0x58
	private static ProfilerMarker k_SaveGlyphVertexDataMarker; //Field offset: 0x60
	private static ProfilerMarker k_ComputeCharacterAdvanceMarker; //Field offset: 0x68
	private static ProfilerMarker k_HandleCarriageReturnMarker; //Field offset: 0x70
	private static ProfilerMarker k_HandleLineTerminationMarker; //Field offset: 0x78
	private static ProfilerMarker k_SavePageInfoMarker; //Field offset: 0x80
	private static ProfilerMarker k_SaveProcessingStatesMarker; //Field offset: 0x88
	private static ProfilerMarker k_GenerateTextPhaseIIMarker; //Field offset: 0x90
	private static ProfilerMarker k_GenerateTextPhaseIIIMarker; //Field offset: 0x98
	[SerializeField]
	internal int _SortingLayer; //Field offset: 0x6C8
	[SerializeField]
	internal int _SortingLayerID; //Field offset: 0x6CC
	[SerializeField]
	internal int _SortingOrder; //Field offset: 0x6D0
	[CompilerGenerated]
	private Action<TMP_TextInfo> OnPreRenderText; //Field offset: 0x6D8
	private bool m_currentAutoSizeMode; //Field offset: 0x6E0
	[SerializeField]
	private bool m_hasFontAssetChanged; //Field offset: 0x6E1
	private float m_previousLossyScaleY; //Field offset: 0x6E4
	[SerializeField]
	private Renderer m_renderer; //Field offset: 0x6E8
	private MeshFilter m_meshFilter; //Field offset: 0x6F0
	private bool m_isFirstAllocation; //Field offset: 0x6F8
	private int m_max_characters; //Field offset: 0x6FC
	private int m_max_numberOfLines; //Field offset: 0x700
	private TMP_SubMesh[] m_subTextObjects; //Field offset: 0x708
	[SerializeField]
	private MaskingTypes m_maskType; //Field offset: 0x710
	private Matrix4x4 m_EnvMapMatrix; //Field offset: 0x714
	private Vector3[] m_RectTransformCorners; //Field offset: 0x758
	private bool m_isRegisteredForEvents; //Field offset: 0x760

	public virtual event Action<TMP_TextInfo> OnPreRenderText
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public virtual bool autoSizeTextContainer
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	public MaskingTypes maskType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public virtual Mesh mesh
	{
		 get { } //Length: 192
	}

	public MeshFilter meshFilter
	{
		 get { } //Length: 292
	}

	public Renderer renderer
	{
		 get { } //Length: 160
	}

	public int sortingLayerID
	{
		 get { } //Length: 148
		 set { } //Length: 180
	}

	public int sortingOrder
	{
		 get { } //Length: 148
		 set { } //Length: 180
	}

	[Obsolete("The TextContainer is now obsolete. Use the RectTransform instead.")]
	public TextContainer textContainer
	{
		 get { } //Length: 8
	}

	public Transform transform
	{
		 get { } //Length: 160
	}

	private static TextMeshPro() { }

	public TextMeshPro() { }

	[CompilerGenerated]
	public virtual void add_OnPreRenderText(Action<TMP_TextInfo> value) { }

	protected virtual void Awake() { }

	public override void CalculateLayoutInputHorizontal() { }

	public override void CalculateLayoutInputVertical() { }

	public virtual void ClearMesh(bool updateMesh) { }

	public virtual void ComputeMarginSize() { }

	private void CreateMaterialInstance() { }

	protected virtual void DestroySubMeshObjects() { }

	private void DisableMasking() { }

	private void EnableMasking() { }

	public virtual void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false) { }

	protected override void GenerateTextMesh() { }

	public virtual bool get_autoSizeTextContainer() { }

	public MaskingTypes get_maskType() { }

	public virtual Mesh get_mesh() { }

	public MeshFilter get_meshFilter() { }

	public Renderer get_renderer() { }

	public int get_sortingLayerID() { }

	public int get_sortingOrder() { }

	public TextContainer get_textContainer() { }

	public Transform get_transform() { }

	protected virtual Bounds GetCompoundBounds() { }

	protected virtual Material GetMaterial(Material mat) { }

	protected virtual Material[] GetMaterials(Material[] mats) { }

	protected virtual Material[] GetSharedMaterials() { }

	protected virtual Vector3[] GetTextContainerLocalCorners() { }

	public virtual TMP_TextInfo GetTextInfo(string text) { }

	internal virtual void InternalUpdate() { }

	protected virtual void LoadFontAsset() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDidApplyAnimationProperties() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private void OnPreRenderObject() { }

	protected virtual void OnRectTransformDimensionsChange() { }

	protected virtual void OnTransformParentChanged() { }

	public virtual void Rebuild(CanvasUpdate update) { }

	[CompilerGenerated]
	public virtual void remove_OnPreRenderText(Action<TMP_TextInfo> value) { }

	public virtual void set_autoSizeTextContainer(bool value) { }

	public void set_maskType(MaskingTypes value) { }

	public void set_sortingLayerID(int value) { }

	public void set_sortingOrder(int value) { }

	protected virtual void SetActiveSubMeshes(bool state) { }

	protected void SetActiveSubTextObjectRenderers(bool state) { }

	public virtual void SetAllDirty() { }

	internal virtual int SetArraySizes(UnicodeChar[] unicodeChars) { }

	protected virtual void SetCulling() { }

	protected virtual void SetFaceColor(Color32 color) { }

	public virtual void SetLayoutDirty() { }

	private void SetMask(MaskingTypes maskType) { }

	public void SetMask(MaskingTypes type, Vector4 maskCoords, float softnessX, float softnessY) { }

	public void SetMask(MaskingTypes type, Vector4 maskCoords) { }

	private void SetMaskCoordinates(Vector4 coords) { }

	private void SetMaskCoordinates(Vector4 coords, float softX, float softY) { }

	public virtual void SetMaterialDirty() { }

	private void SetMeshFilters(bool state) { }

	protected virtual void SetOutlineColor(Color32 color) { }

	protected virtual void SetOutlineThickness(float thickness) { }

	private void SetPerspectiveCorrection() { }

	protected virtual void SetShaderDepth() { }

	protected virtual void SetSharedMaterial(Material mat) { }

	protected virtual void SetSharedMaterials(Material[] materials) { }

	public virtual void SetVerticesDirty() { }

	private void UpdateEnvMapMatrix() { }

	public void UpdateFontAsset() { }

	public virtual void UpdateGeometry(Mesh mesh, int index) { }

	private void UpdateMask() { }

	protected virtual void UpdateMaterial() { }

	public virtual void UpdateMeshPadding() { }

	private void UpdateSDFScale(float scaleDelta) { }

	internal void UpdateSubMeshSortingLayerID(int id) { }

	internal void UpdateSubMeshSortingOrder(int order) { }

	public virtual void UpdateVertexData() { }

	public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags) { }

}

