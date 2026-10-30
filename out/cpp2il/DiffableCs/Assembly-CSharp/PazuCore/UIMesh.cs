namespace PazuCore;

public class UIMesh : MaskableGraphic, ILayoutElement
{
	[SerializeField]
	private Mesh _mesh; //Field offset: 0xD8
	[SerializeField]
	private float _scale; //Field offset: 0xE0
	private List<UIVertex> _uiVertices; //Field offset: 0xE8
	private List<Int32> _indices; //Field offset: 0xF0
	private Color[] _colors; //Field offset: 0xF8
	private Color _graphicColor; //Field offset: 0x100
	private bool _useMeshColors; //Field offset: 0x110
	private float _lastScale; //Field offset: 0x114
	private Mesh _lastMesh; //Field offset: 0x118
	private Vector2 _size; //Field offset: 0x120

	public override float flexibleHeight
	{
		 get { } //Length: 8
	}

	public override float flexibleWidth
	{
		 get { } //Length: 8
	}

	public override int layoutPriority
	{
		 get { } //Length: 8
	}

	public override float minHeight
	{
		 get { } //Length: 8
	}

	public override float minWidth
	{
		 get { } //Length: 8
	}

	public override float preferredHeight
	{
		 get { } //Length: 172
	}

	public override float preferredWidth
	{
		 get { } //Length: 172
	}

	public UIMesh() { }

	public override void CalculateLayoutInputHorizontal() { }

	public override void CalculateLayoutInputVertical() { }

	public override float get_flexibleHeight() { }

	public override float get_flexibleWidth() { }

	public override int get_layoutPriority() { }

	public override float get_minHeight() { }

	public override float get_minWidth() { }

	public override float get_preferredHeight() { }

	public override float get_preferredWidth() { }

	public Mesh GetMesh() { }

	protected virtual void OnPopulateMesh(VertexHelper vh) { }

	public void SetMesh(Mesh mesh) { }

}

