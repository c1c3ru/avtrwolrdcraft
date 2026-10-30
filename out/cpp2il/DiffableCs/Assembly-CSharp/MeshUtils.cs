//Type is in global namespace

public static class MeshUtils
{
	private const float PRECISION = 100000; //Field offset: 0x0

	public static Polygon ConvertIntPointListToPolygon(List<IntPoint> list) { }

	public static Vector2 ConvertIntPointToVector(IntPoint intPoint) { }

	public static Vector2 ConvertPointToVector(TriangulationPoint point) { }

	public static IntPoint ConvertVectorToIntPoint(Vector2 vector) { }

	public static void GenerateMesh(List<List`1<IntPoint>> polys, out Vector3[] outVertices, out Int32[] outTriangles) { }

	public static void GenerateMesh(List<DelaunayTriangle> triangles, out Vector3[] outVertices, out Int32[] outTriangles) { }

	public static List<DelaunayTriangle> GenerateTriangles(PolyTree polyTree) { }

	public static void SubtractMesh(List<List`1<IntPoint>> mainMesh, List<List`1<IntPoint>> flavorMesh, out Vector3[] outVertices, out Int32[] outTriangles) { }

	public static void SubtractMesh(List<List`1<Vector2>> mainMesh, List<List`1<Vector2>> flavorMesh, out Vector3[] outVertices, out Int32[] outTriangles) { }

	public static Mesh SubtractMesh(Mesh mainMesh, Mesh flavorMesh) { }

}

