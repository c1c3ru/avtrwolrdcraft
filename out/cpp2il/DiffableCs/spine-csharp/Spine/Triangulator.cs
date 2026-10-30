namespace Spine;

public class Triangulator
{
	private readonly ExposedList<ExposedList`1<Single>> convexPolygons; //Field offset: 0x10
	private readonly ExposedList<ExposedList`1<Int32>> convexPolygonsIndices; //Field offset: 0x18
	private readonly ExposedList<Int32> indicesArray; //Field offset: 0x20
	private readonly ExposedList<Boolean> isConcaveArray; //Field offset: 0x28
	private readonly ExposedList<Int32> triangles; //Field offset: 0x30
	private readonly Pool<ExposedList`1<Single>> polygonPool; //Field offset: 0x38
	private readonly Pool<ExposedList`1<Int32>> polygonIndicesPool; //Field offset: 0x40

	public Triangulator() { }

	public ExposedList<ExposedList`1<Single>> Decompose(ExposedList<Single> verticesArray, ExposedList<Int32> triangles) { }

	private static bool IsConcave(int index, int vertexCount, Single[] vertices, Int32[] indices) { }

	private static bool PositiveArea(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y) { }

	public ExposedList<Int32> Triangulate(ExposedList<Single> verticesArray) { }

	private static int Winding(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y) { }

}

