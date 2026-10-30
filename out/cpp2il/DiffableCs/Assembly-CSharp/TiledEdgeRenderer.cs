//Type is in global namespace

public class TiledEdgeRenderer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ExtraDataListEntry, Boolean> <>9__29_0; //Field offset: 0x8
		public static Converter<Vector3, Vector2> <>9__38_4; //Field offset: 0x10
		public static Predicate<ExtraDataListEntry> <>9__38_5; //Field offset: 0x18
		public static Predicate<ExtraDataListEntry> <>9__38_6; //Field offset: 0x20
		public static Func<ExtraDataListEntry, Boolean> <>9__38_7; //Field offset: 0x28
		public static Converter<Vector3, Vector2> <>9__39_0; //Field offset: 0x30
		public static Func<ExtraDataListEntry, Boolean> <>9__39_1; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal Vector2 <GenerateEdgeMesh>b__38_4(Vector3 v) { }

		internal bool <GenerateEdgeMesh>b__38_5(ExtraDataListEntry entry) { }

		internal bool <GenerateEdgeMesh>b__38_6(ExtraDataListEntry entry) { }

		internal bool <GenerateEdgeMesh>b__38_7(ExtraDataListEntry e) { }

		internal bool <GenerateFullMesh>b__29_0(ExtraDataListEntry e) { }

		internal Vector2 <GenerateVertexMesh>b__39_0(Vector3 v) { }

		internal bool <GenerateVertexMesh>b__39_1(ExtraDataListEntry e) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass38_0
	{
		public List<Vector2[]> paths; //Field offset: 0x0
		public List<ExtraDataListEntry> extraDataListEntries; //Field offset: 0x8
		public bool isCollider; //Field offset: 0x10
		public TiledEdgeRenderer <>4__this; //Field offset: 0x18
		public bool isFloat; //Field offset: 0x20
		public List<Vector3> vertices; //Field offset: 0x28
		public List<Int32> triangles; //Field offset: 0x30
		public int vertexOffset; //Field offset: 0x38
		public List<Vector2> uvs; //Field offset: 0x40

	}

	private const int NUMBER_OF_EDGE_TILES = 20; //Field offset: 0x0
	private const int NUMBER_OF_TILES_PER_CORNER = 1; //Field offset: 0x0
	private const int NUMBER_OF_TILES_PER_DIRECTION = 5; //Field offset: 0x0
	private const int NUMBER_OF_QUARTERS = 4; //Field offset: 0x0
	private const string _childName = "TiledEdges"; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Default -1 is for true random.")]
	private int _seed; //Field offset: 0x20
	[SerializeField]
	private bool _activateOnStart; //Field offset: 0x24
	[SerializeField]
	[Tooltip("Sprite to tile along each edge of the polygon.")]
	private Sprite _edgeSprite; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Sprite to tile along each Vertex of the polygon.")]
	private Sprite _vertexSprite; //Field offset: 0x30
	[SerializeField]
	[Tooltip("Height of the strip extending outward from the polygon (in world units).")]
	private float _edgeHeight; //Field offset: 0x38
	[SerializeField]
	[Tooltip("If true, the strip is generated on the inside of the polygon.")]
	private bool _invert; //Field offset: 0x3C
	[SerializeField]
	[Tooltip("Tile size along the edge (X direction in UV space).")]
	private float _edgeTileSize; //Field offset: 0x40
	[SerializeField]
	private float _vertexTileSize; //Field offset: 0x44
	[SerializeField]
	[Tooltip("How far inside the polygon the texture starts (in world units).")]
	private float _edgeInsetAmount; //Field offset: 0x48
	[SerializeField]
	private float _vertexInsetAmount; //Field offset: 0x4C
	[SerializeField]
	[Tooltip("Max stretch factor (multiplier of _tileSize) before splitting into multiple tiles.")]
	private float _maxStretch; //Field offset: 0x50
	[SerializeField]
	private Material _edgeMaterial; //Field offset: 0x58
	[SerializeField]
	private Material _vertexMaterial; //Field offset: 0x60
	[SerializeField]
	[Tooltip("When value is > 0, only create a top edge with this width")]
	private float _xWidth; //Field offset: 0x68
	public Mesh gizmosMesh; //Field offset: 0x70

	public int Seed
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float XWidth
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TiledEdgeRenderer() { }

	[CompilerGenerated]
	private void <GenerateEdgeMesh>g__AddEdgeQuad|38_1(Vector2 a, Vector2 b, Vector2 normal, int quarter, Vector2 edgeDir, int tileIndex, int i, ref <>c__DisplayClass38_0 unnamed_param_7) { }

	[CompilerGenerated]
	private void <GenerateEdgeMesh>g__AddQuad|38_2(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, ref <>c__DisplayClass38_0 unnamed_param_4) { }

	[CompilerGenerated]
	private void <GenerateEdgeMesh>g__AddUVs|38_3(int quarter, float uvLength, float vMin, float vMax, ref <>c__DisplayClass38_0 unnamed_param_4) { }

	[CompilerGenerated]
	private void <GenerateEdgeMesh>g__GenerateEdges|38_0(int passNumber, ref <>c__DisplayClass38_0 unnamed_param_1) { }

	private void Awake() { }

	[ContextMenu("Tiled Edge/Generate Edge From Collider")]
	public void GenerateEdgeFromCollider() { }

	private Mesh GenerateEdgeMesh(object source, List<ExtraDataListEntry> extraDataListEntries = null) { }

	public void GenerateEdgeMeshFromObject(object source, List<ExtraDataListEntry> extraDataListEntries = null) { }

	public void GenerateEdgeMeshFromObject(List<ExtraDataListEntry> extraDataListEntries = null) { }

	[ContextMenu("Tiled Edge/Generate From Collider")]
	public void GenerateFromCollider() { }

	[ContextMenu("Generate")]
	public void GenerateFullMesh() { }

	public void GenerateFullMesh(object source = null) { }

	[ContextMenu("Tiled Edge/Generate Vertex From Collider")]
	public void GenerateVertexFromCollider() { }

	private Mesh GenerateVertexMesh(object source, List<ExtraDataListEntry> extraDataListEntries = null) { }

	public void GenerateVertexMeshFromObject(object source, List<ExtraDataListEntry> extraDataListEntries = null) { }

	public void GenerateVertexMeshFromObject(List<ExtraDataListEntry> extraDataListEntries = null) { }

	public int get_Seed() { }

	public float get_XWidth() { }

	private static bool IsCounterClockwise(Vector2[] vertices) { }

	private static Vector2[] NormalizeVertexOrder(Vector2[] vertices) { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	public void set_Seed(int value) { }

	public void set_XWidth(float value) { }

	private int SnapToCardinal(float angle) { }

}

