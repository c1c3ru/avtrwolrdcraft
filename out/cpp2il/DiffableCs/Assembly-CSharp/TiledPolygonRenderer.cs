//Type is in global namespace

public class TiledPolygonRenderer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Vector3, Vector2> <>9__27_0; //Field offset: 0x8
		public static Func<Vector2, Vector3> <>9__28_1; //Field offset: 0x10
		public static Func<Vector2, Vector3> <>9__28_4; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal Vector3 <GenerateFlavorOverlayMesh>b__28_1(Vector2 v) { }

		internal Vector3 <GenerateFlavorOverlayMesh>b__28_4(Vector2 v) { }

		internal Vector2 <GenerateMeshFromPoints>b__27_0(Vector3 v) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public TiledPolygonRenderer <>4__this; //Field offset: 0x10
		public Mesh baseMesh; //Field offset: 0x18
		public Func<Vector2, Boolean> <>9__0; //Field offset: 0x20
		public Func<Vector2, Boolean> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass28_0() { }

		internal bool <GenerateFlavorOverlayMesh>b__0(Vector2 corner) { }

		internal bool <GenerateFlavorOverlayMesh>b__2(Vector2 corner) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_1
	{
		public Rect newTileRect; //Field offset: 0x10

		public <>c__DisplayClass28_1() { }

		internal bool <GenerateFlavorOverlayMesh>b__3(Rect rect) { }

	}

	private const string _childName = "TiledMesh"; //Field offset: 0x0
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x20
	[SerializeField]
	private float _tileSize; //Field offset: 0x28
	[SerializeField]
	private float _offsetAmount; //Field offset: 0x2C
	[SerializeField]
	private Material _meshMaterial; //Field offset: 0x30
	[SerializeField]
	private Material _flavorMaterial; //Field offset: 0x38
	[SerializeField]
	private int _flavorCount; //Field offset: 0x40
	[SerializeField]
	private float _flavorTileWorldSize; //Field offset: 0x44
	[SerializeField]
	private int _maxFlavorTiles; //Field offset: 0x48
	[SerializeField]
	private bool _isFillingAllFlavor; //Field offset: 0x4C
	[Range(0, 1)]
	[SerializeField]
	private float _rowOffsetChance; //Field offset: 0x50
	[Range(0, 1)]
	[SerializeField]
	private float _colOffsetChance; //Field offset: 0x54
	[Range(0, 1)]
	[SerializeField]
	private float _offsetStrength; //Field offset: 0x58
	[Range(0, 1)]
	[SerializeField]
	private float _partialOffsetChance; //Field offset: 0x5C
	[Range(0, 1)]
	[SerializeField]
	private float _emptyTileChance; //Field offset: 0x60
	private float _seed; //Field offset: 0x64

	public bool IsFillingAllFlavor
	{
		 get { } //Length: 8
	}

	public TiledPolygonRenderer() { }

	private float Area(Vector2[] poly) { }

	private void CreateFlavorMeshObject(Mesh mesh, Material material) { }

	private Material CreateMaterial() { }

	private void CreateMeshObject(Mesh mesh, Material material) { }

	private Mesh GenerateFlavorOverlayMesh(Mesh baseMesh, bool fullTilingMode = false) { }

	private Vector2[] GenerateFlavorUVQuad(int index, int flavorCount) { }

	private Mesh GenerateMeshFromPoints(PolygonCollider2D collider) { }

	private Mesh GenerateMeshFromPoints(Vector2[] points) { }

	private Mesh GenerateMeshFromPoints(CShape cShape) { }

	public void GeneratePolygonFromObject() { }

	public void GeneratePolygonFromObject(object source) { }

	private Vector2[] GenerateUVs(Vector3[] vertices) { }

	public bool get_IsFillingAllFlavor() { }

	private Vector3[] InflateVertices(Vector3[] originalVertices) { }

	private bool IsPointInsideMesh(Vector2 point, Mesh mesh) { }

	private bool PointInTriangle(Vector2 P, Vector2 A, Vector2 B, Vector2 C) { }

	private bool PointInTriangle2D(Vector2 p, Vector2 a, Vector2 b, Vector2 c) { }

	private void RemoveOldMeshObject() { }

	private bool Snip(Vector2[] poly, int u, int v, int w, int n, Int32[] V) { }

	private Int32[] Triangulate(Vector2[] poly) { }

}

