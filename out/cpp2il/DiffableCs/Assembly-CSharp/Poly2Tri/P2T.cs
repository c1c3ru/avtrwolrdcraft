namespace Poly2Tri;

public static class P2T
{
	private const TriangulationAlgorithm DEFAULT_ALGORITHM = 0; //Field offset: 0x0

	private static TriangulationContext CreateContext(TriangulationAlgorithm algorithm) { }

	public static void Triangulate(IEnumerable<Polygon> polygons) { }

	public static void Triangulate(ITriangulatable t, TriangulationAlgorithm algorithm = 0) { }

	private static void Triangulate(TriangulationContext tcx) { }

}

