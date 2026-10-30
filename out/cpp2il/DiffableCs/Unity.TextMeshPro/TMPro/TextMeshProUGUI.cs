namespace TMPro;

[AddComponentMenu("UI/TextMeshPro - Text (UI)", 11)]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]
public class TextMeshProUGUI : TMP_Text, ILayoutElement
{
	[CompilerGenerated]
	private sealed class <DelayedGraphicRebuild>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TextMeshProUGUI <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <DelayedGraphicRebuild>d__18(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <DelayedMaterialRebuild>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TextMeshProUGUI <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <DelayedMaterialRebuild>d__19(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

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
	private bool m_isRebuildingLayout; //Field offset: 0x6C8
	private Coroutine m_DelayedGraphicRebuild; //Field offset: 0x6D0
	private Coroutine m_DelayedMaterialRebuild; //Field offset: 0x6D8
	private Rect m_ClipRect; //Field offset: 0x6E0
	private bool m_ValidRect; //Field offset: 0x6F0
	[CompilerGenerated]
	private Action<TMP_TextInfo> OnPreRenderText; //Field offset: 0x6F8
	[SerializeField]
	private bool m_hasFontAssetChanged; //Field offset: 0x700
	protected TMP_SubMeshUI[] m_subTextObjects; //Field offset: 0x708
	private float m_previousLossyScaleY; //Field offset: 0x710
	private Vector3[] m_RectTransformCorners; //Field offset: 0x718
	private CanvasRenderer m_canvasRenderer; //Field offset: 0x720
	private Canvas m_canvas; //Field offset: 0x728
	private float m_CanvasScaleFactor; //Field offset: 0x730
	private bool m_isFirstAllocation; //Field offset: 0x734
	private int m_max_characters; //Field offset: 0x738
	[SerializeField]
	private Material m_baseMaterial; //Field offset: 0x740
	private bool m_isScrollRegionSet; //Field offset: 0x748
	[SerializeField]
	private Vector4 m_maskOffset; //Field offset: 0x74C
	private Matrix4x4 m_EnvMapMatrix; //Field offset: 0x75C
	private bool m_isRegisteredForEvents; //Field offset: 0x79C

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

	public CanvasRenderer canvasRenderer
	{
		 get { } //Length: 160
	}

	public Vector4 maskOffset
	{
		 get { } //Length: 20
		 set { } //Length: 44
	}

	public virtual Material materialForRendering
	{
		 get { } //Length: 96
	}

	public virtual Mesh mesh
	{
		 get { } //Length: 8
	}

	private static TextMeshProUGUI() { }

	public TextMeshProUGUI() { }

	[CompilerGenerated]
	public virtual void add_OnPreRenderText(Action<TMP_TextInfo> value) { }

	protected virtual void Awake() { }

	public override void CalculateLayoutInputHorizontal() { }

	public override void CalculateLayoutInputVertical() { }

	public virtual void ClearMesh() { }

	public virtual void ComputeMarginSize() { }

	public virtual void Cull(Rect clipRect, bool validRect) { }

	[IteratorStateMachine(typeof(<DelayedGraphicRebuild>d__18))]
	private IEnumerator DelayedGraphicRebuild() { }

	[IteratorStateMachine(typeof(<DelayedMaterialRebuild>d__19))]
	private IEnumerator DelayedMaterialRebuild() { }

	protected virtual void DestroySubMeshObjects() { }

	private void DisableMasking() { }

	private void EnableMasking() { }

	public virtual void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false) { }

	protected override void GenerateTextMesh() { }

	public virtual bool get_autoSizeTextContainer() { }

	public CanvasRenderer get_canvasRenderer() { }

	public Vector4 get_maskOffset() { }

	public virtual Material get_materialForRendering() { }

	public virtual Mesh get_mesh() { }

	private Canvas GetCanvas() { }

	internal virtual Rect GetCanvasSpaceClippingRect() { }

	protected virtual Bounds GetCompoundBounds() { }

	protected virtual Material GetMaterial(Material mat) { }

	protected virtual Material[] GetMaterials(Material[] mats) { }

	public virtual Material GetModifiedMaterial(Material baseMaterial) { }

	protected virtual Material[] GetSharedMaterials() { }

	protected virtual Vector3[] GetTextContainerLocalCorners() { }

	public virtual TMP_TextInfo GetTextInfo(string text) { }

	protected virtual void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }

	protected virtual void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }

	internal virtual void InternalUpdate() { }

	protected virtual void LoadFontAsset() { }

	protected virtual void OnCanvasHierarchyChanged() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDidApplyAnimationProperties() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private void OnPreRenderCanvas() { }

	protected virtual void OnRectTransformDimensionsChange() { }

	protected virtual void OnTransformParentChanged() { }

	public virtual void Rebuild(CanvasUpdate update) { }

	public virtual void RecalculateClipping() { }

	[CompilerGenerated]
	public virtual void remove_OnPreRenderText(Action<TMP_TextInfo> value) { }

	public virtual void set_autoSizeTextContainer(bool value) { }

	public void set_maskOffset(Vector4 value) { }

	protected virtual void SetActiveSubMeshes(bool state) { }

	public virtual void SetAllDirty() { }

	internal virtual int SetArraySizes(UnicodeChar[] unicodeChars) { }

	protected virtual void SetCulling() { }

	protected virtual void SetFaceColor(Color32 color) { }

	public virtual void SetLayoutDirty() { }

	public virtual void SetMaterialDirty() { }

	private void SetMeshArrays(int size) { }

	protected virtual void SetOutlineColor(Color32 color) { }

	protected virtual void SetOutlineThickness(float thickness) { }

	private void SetPerspectiveCorrection() { }

	protected virtual void SetShaderDepth() { }

	protected virtual void SetSharedMaterial(Material mat) { }

	protected virtual void SetSharedMaterials(Material[] materials) { }

	public virtual void SetVerticesDirty() { }

	internal virtual void UpdateCulling() { }

	private void UpdateEnvMapMatrix() { }

	public void UpdateFontAsset() { }

	public virtual void UpdateGeometry(Mesh mesh, int index) { }

	private void UpdateMask() { }

	protected virtual void UpdateMaterial() { }

	public virtual void UpdateMeshPadding() { }

	private void UpdateSDFScale(float scaleDelta) { }

	private void UpdateSubObjectPivot() { }

	public virtual void UpdateVertexData() { }

	public virtual void UpdateVertexData(TMP_VertexDataUpdateFlags flags) { }

}

