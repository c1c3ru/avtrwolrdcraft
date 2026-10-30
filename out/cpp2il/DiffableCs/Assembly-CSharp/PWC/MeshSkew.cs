namespace PWC;

public class MeshSkew : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Vector3, Vector2> <>9__67_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Vector2 <Sync>b__67_0(Vector3 x) { }

	}

	internal enum MeshSkewType
	{
		None = 0,
		Floor = 1,
		Wall = 2,
	}

	internal enum SkewShapeType
	{
		None = 0,
		Bottom = 1,
		Side = 2,
	}

	internal enum SplitDirection
	{
		Horizontal = 0,
		Vertical = 1,
		Both = 2,
		HorizontalWithDeg = 3,
	}

	public static readonly List<MeshSkew> MeshesList; //Field offset: 0x0
	[SerializeField]
	private float _angle; //Field offset: 0x20
	[SerializeField]
	private Vector2 _pivot; //Field offset: 0x24
	[SerializeField]
	private Vector2 _size; //Field offset: 0x2C
	[SerializeField]
	private Vector2 _textureOffset; //Field offset: 0x34
	[SerializeField]
	private Vector2 _textureScale; //Field offset: 0x3C
	[SerializeField]
	private MeshFilter _meshFilter; //Field offset: 0x48
	[SerializeField]
	private MeshRenderer _meshRenderer; //Field offset: 0x50
	[SerializeField]
	private bool _flipUVX; //Field offset: 0x58
	[SerializeField]
	private bool _flipUVY; //Field offset: 0x59
	[SerializeField]
	private bool _moveUVWithPositions; //Field offset: 0x5A
	[SerializeField]
	private bool _preventColliderSync; //Field offset: 0x5B
	[SerializeField]
	private SkewShapeType _skewType; //Field offset: 0x5C
	[SerializeField]
	private bool _shouldAdjustUVScaleToAngle; //Field offset: 0x60
	[SerializeField]
	private MeshSkewType _meshSkewType; //Field offset: 0x64
	private readonly Int32[] _triangles; //Field offset: 0x68
	private readonly Vector3[] _vertices; //Field offset: 0x70
	private readonly Vector2[] _uv; //Field offset: 0x78
	private LevelMakerPanelBase _rightBorder; //Field offset: 0x80
	private LevelMakerPanelBase _leftBorder; //Field offset: 0x88
	private Nullable<Vector2> _lastPivot; //Field offset: 0x90
	private CShape _cshape; //Field offset: 0xA0

	public float Angle
	{
		 get { } //Length: 8
	}

	public CShape CShape
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool FlipUVX
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool FlipUVY
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelMakerPanelBase LeftBorder
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public MeshFilter MeshFilter
	{
		 get { } //Length: 8
	}

	public bool MoveUVWithPositions
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public Vector2 Pivot
	{
		 get { } //Length: 8
	}

	public bool PreventColliderSync
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelMakerPanelBase RightBorder
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public MeshSkewType SkewType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Vector2 TextureOffset
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Vector2 TextureScale
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static MeshSkew() { }

	public MeshSkew() { }

	private void Awake() { }

	public float get_Angle() { }

	public CShape get_CShape() { }

	public bool get_FlipUVX() { }

	public bool get_FlipUVY() { }

	public LevelMakerPanelBase get_LeftBorder() { }

	public MeshFilter get_MeshFilter() { }

	public bool get_MoveUVWithPositions() { }

	public Vector2 get_Pivot() { }

	public bool get_PreventColliderSync() { }

	public LevelMakerPanelBase get_RightBorder() { }

	public MeshSkewType get_SkewType() { }

	public Vector2 get_TextureOffset() { }

	public Vector2 get_TextureScale() { }

	public Vector2 GetSize() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void set_CShape(CShape value) { }

	public void set_FlipUVX(bool value) { }

	public void set_FlipUVY(bool value) { }

	public void set_LeftBorder(LevelMakerPanelBase value) { }

	public void set_MoveUVWithPositions(bool value) { }

	public void set_PreventColliderSync(bool value) { }

	public void set_RightBorder(LevelMakerPanelBase value) { }

	public void set_SkewType(MeshSkewType value) { }

	public void set_TextureOffset(Vector2 value) { }

	public void set_TextureScale(Vector2 value) { }

	public void SetAngle(float angle) { }

	public void SetPivot(Vector2 pivot) { }

	public void SetSize(Vector2 size) { }

	public void Sync(bool syncPositions = false, bool syncUV = false, bool syncCollider = false) { }

	public void UpdateMesh(Vector3 worldPoint, float width) { }

}

