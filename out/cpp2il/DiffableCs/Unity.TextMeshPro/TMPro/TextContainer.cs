namespace TMPro;

[RequireComponent(typeof(RectTransform))]
public class TextContainer : UIBehaviour
{
	private static Vector2 k_defaultSize; //Field offset: 0x0
	private bool m_hasChanged; //Field offset: 0x20
	[SerializeField]
	private Vector2 m_pivot; //Field offset: 0x24
	[SerializeField]
	private TextContainerAnchors m_anchorPosition; //Field offset: 0x2C
	[SerializeField]
	private Rect m_rect; //Field offset: 0x30
	private bool m_isDefaultWidth; //Field offset: 0x40
	private bool m_isDefaultHeight; //Field offset: 0x41
	private bool m_isAutoFitting; //Field offset: 0x42
	private Vector3[] m_corners; //Field offset: 0x48
	private Vector3[] m_worldCorners; //Field offset: 0x50
	[SerializeField]
	private Vector4 m_margins; //Field offset: 0x58
	private RectTransform m_rectTransform; //Field offset: 0x68
	private TextMeshPro m_textMeshPro; //Field offset: 0x70

	public TextContainerAnchors anchorPosition
	{
		 get { } //Length: 8
		 set { } //Length: 60
	}

	public Vector3[] corners
	{
		 get { } //Length: 8
	}

	public bool hasChanged
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float height
	{
		 get { } //Length: 8
		 set { } //Length: 20
	}

	public bool isAutoFitting
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool isDefaultHeight
	{
		 get { } //Length: 8
	}

	public bool isDefaultWidth
	{
		 get { } //Length: 8
	}

	public Vector4 margins
	{
		 get { } //Length: 12
		 set { } //Length: 92
	}

	public Vector2 pivot
	{
		 get { } //Length: 8
		 set { } //Length: 88
	}

	public Rect rect
	{
		 get { } //Length: 12
		 set { } //Length: 72
	}

	public RectTransform rectTransform
	{
		 get { } //Length: 168
	}

	public Vector2 size
	{
		 get { } //Length: 8
		 set { } //Length: 64
	}

	public TextMeshPro textMeshPro
	{
		 get { } //Length: 168
	}

	public float width
	{
		 get { } //Length: 8
		 set { } //Length: 20
	}

	public Vector3[] worldCorners
	{
		 get { } //Length: 8
	}

	private static TextContainer() { }

	public TextContainer() { }

	protected virtual void Awake() { }

	public TextContainerAnchors get_anchorPosition() { }

	public Vector3[] get_corners() { }

	public bool get_hasChanged() { }

	public float get_height() { }

	public bool get_isAutoFitting() { }

	public bool get_isDefaultHeight() { }

	public bool get_isDefaultWidth() { }

	public Vector4 get_margins() { }

	public Vector2 get_pivot() { }

	public Rect get_rect() { }

	public RectTransform get_rectTransform() { }

	public Vector2 get_size() { }

	public TextMeshPro get_textMeshPro() { }

	public float get_width() { }

	public Vector3[] get_worldCorners() { }

	private TextContainerAnchors GetAnchorPosition(Vector2 pivot) { }

	private Vector2 GetPivot(TextContainerAnchors anchor) { }

	private void OnContainerChanged() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnRectTransformDimensionsChange() { }

	public void set_anchorPosition(TextContainerAnchors value) { }

	public void set_hasChanged(bool value) { }

	public void set_height(float value) { }

	public void set_isAutoFitting(bool value) { }

	public void set_margins(Vector4 value) { }

	public void set_pivot(Vector2 value) { }

	public void set_rect(Rect value) { }

	public void set_size(Vector2 value) { }

	public void set_width(float value) { }

	private void SetRect(Vector2 size) { }

	private void UpdateCorners() { }

}

