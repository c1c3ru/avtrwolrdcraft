namespace Spine;

public class SkeletonClipping
{
	internal readonly Triangulator triangulator; //Field offset: 0x10
	internal readonly ExposedList<Single> clippingPolygon; //Field offset: 0x18
	internal readonly ExposedList<Single> clipOutput; //Field offset: 0x20
	internal readonly ExposedList<Single> clippedVertices; //Field offset: 0x28
	internal readonly ExposedList<Int32> clippedTriangles; //Field offset: 0x30
	internal readonly ExposedList<Single> clippedUVs; //Field offset: 0x38
	internal readonly ExposedList<Single> scratch; //Field offset: 0x40
	internal ClippingAttachment clipAttachment; //Field offset: 0x48
	internal ExposedList<ExposedList`1<Single>> clippingPolygons; //Field offset: 0x50

	public ExposedList<Int32> ClippedTriangles
	{
		 get { } //Length: 8
	}

	public ExposedList<Single> ClippedUVs
	{
		 get { } //Length: 8
	}

	public ExposedList<Single> ClippedVertices
	{
		 get { } //Length: 8
	}

	public bool IsClipping
	{
		 get { } //Length: 16
	}

	public SkeletonClipping() { }

	internal bool Clip(float x1, float y1, float x2, float y2, float x3, float y3, ExposedList<Single> clippingArea, ExposedList<Single> output) { }

	public void ClipEnd(Slot slot) { }

	public void ClipEnd() { }

	public int ClipStart(Slot slot, ClippingAttachment clip) { }

	public void ClipTriangles(Single[] vertices, Int32[] triangles, int trianglesLength) { }

	public void ClipTriangles(Single[] vertices, Int32[] triangles, int trianglesLength, Single[] uvs) { }

	public ExposedList<Int32> get_ClippedTriangles() { }

	public ExposedList<Single> get_ClippedUVs() { }

	public ExposedList<Single> get_ClippedVertices() { }

	public bool get_IsClipping() { }

	public static void MakeClockwise(ExposedList<Single> polygon) { }

}

