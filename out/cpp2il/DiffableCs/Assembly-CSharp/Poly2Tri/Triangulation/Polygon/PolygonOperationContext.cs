namespace Poly2Tri.Triangulation.Polygon;

public class PolygonOperationContext
{
	public PolyOperation Operations; //Field offset: 0x10
	public Point2DList OriginalPolygon2; //Field offset: 0x18
	public Point2DList Poly1; //Field offset: 0x20
	public Point2DList Poly2; //Field offset: 0x28
	public List<EdgeIntersectInfo> Intersections; //Field offset: 0x30
	public int StartingIndex; //Field offset: 0x38
	public PolyUnionError Error; //Field offset: 0x3C
	public List<Int32> Poly1VectorAngles; //Field offset: 0x40
	public List<Int32> Poly2VectorAngles; //Field offset: 0x48
	public Dictionary<UInt32, Point2DList> Output; //Field offset: 0x50

	public Point2DList Intersect
	{
		 get { } //Length: 192
	}

	public Point2DList Subtract
	{
		 get { } //Length: 192
	}

	public Point2DList Union
	{
		 get { } //Length: 192
	}

	public PolygonOperationContext() { }

	public void Clear() { }

	public Point2DList get_Intersect() { }

	public Point2DList get_Subtract() { }

	public Point2DList get_Union() { }

	public bool Init(PolyOperation operations, Point2DList polygon1, Point2DList polygon2) { }

	public static bool PointInPolygonAngle(Point2D point, Point2DList polygon) { }

	public static double VectorAngle(Point2D p1, Point2D p2) { }

	private static bool VerticesIntersect(Point2DList polygon1, Point2DList polygon2, out List<EdgeIntersectInfo>& intersections) { }

}

