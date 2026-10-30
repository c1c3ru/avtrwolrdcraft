namespace UnityEngine.UI;

public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier
{
	internal class CullStateChangedEvent : UnityEvent<Boolean>
	{

		public CullStateChangedEvent() { }

	}

	protected bool m_ShouldRecalculateStencil; //Field offset: 0xA1
	protected Material m_MaskMaterial; //Field offset: 0xA8
	private RectMask2D m_ParentMask; //Field offset: 0xB0
	[SerializeField]
	private bool m_Maskable; //Field offset: 0xB8
	private bool m_IsMaskingGraphic; //Field offset: 0xB9
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Not used anymore.", True)]
	protected bool m_IncludeForMasking; //Field offset: 0xBA
	[SerializeField]
	private CullStateChangedEvent m_OnCullStateChanged; //Field offset: 0xC0
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Not used anymore", True)]
	protected bool m_ShouldRecalculate; //Field offset: 0xC8
	protected int m_StencilValue; //Field offset: 0xCC
	private readonly Vector3[] m_Corners; //Field offset: 0xD0

	public bool isMaskingGraphic
	{
		 get { } //Length: 8
		 set { } //Length: 24
	}

	public bool maskable
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public CullStateChangedEvent onCullStateChanged
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private Rect rootCanvasRect
	{
		private get { } //Length: 440
	}

	protected MaskableGraphic() { }

	public override void Cull(Rect clipRect, bool validRect) { }

	public bool get_isMaskingGraphic() { }

	public bool get_maskable() { }

	public CullStateChangedEvent get_onCullStateChanged() { }

	private Rect get_rootCanvasRect() { }

	public override Material GetModifiedMaterial(Material baseMaterial) { }

	protected virtual void OnCanvasHierarchyChanged() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnTransformParentChanged() { }

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Not used anymore.", True)]
	public override void ParentMaskStateChanged() { }

	public override void RecalculateClipping() { }

	public override void RecalculateMasking() { }

	public void set_isMaskingGraphic(bool value) { }

	public void set_maskable(bool value) { }

	public void set_onCullStateChanged(CullStateChangedEvent value) { }

	public override void SetClipRect(Rect clipRect, bool validRect) { }

	public override void SetClipSoftness(Vector2 clipSoftness) { }

	private override GameObject UnityEngine.UI.IClippable.get_gameObject() { }

	private void UpdateClipParent() { }

	private void UpdateCull(bool cull) { }

}

