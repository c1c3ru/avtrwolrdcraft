namespace Poly2Tri.Triangulation.Polygon;

public static class PolygonUtil
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Point2D, SplitComplexPolygonNode> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal SplitComplexPolygonNode <SplitComplexPolygon>b__17_0(Point2D t) { }

	}

	[Flags]
	internal enum PolyOperation
	{
		None = 0,
		Union = 1,
		Intersect = 2,
		Subtract = 4,
	}

	internal enum PolyUnionError
	{
		None = 0,
		NoIntersections = 1,
		Poly1InsidePoly2 = 2,
		InfiniteLoop = 3,
	}


	public static WindingOrderType CalculateWindingOrder(IList<Point2D> l) { }

	private static void ClipPolygonToEdge2D(Point2D edgeBegin, Point2D edgeEnd, IList<Point2D> poly, out List<Point2D>& outPoly) { }

	public static void ClipPolygonToPolygon(IList<Point2D> poly, IList<Point2D> clipPoly, out List<Point2D>& outPoly) { }

	public static bool PointInPolygon2D(IList<Point2D> polygon, Point2D p) { }

	public static bool PolygonContainsPolygon(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2, bool runIntersectionTest = true) { }

	public static PolyUnionError PolygonIntersect(Point2DList polygon1, Point2DList polygon2, out Point2DList intersectOut) { }

	private static void PolygonIntersectInternal(PolygonOperationContext ctx) { }

	public static PolyUnionError PolygonOperation(PolygonOperationContext ctx) { }

	public static PolyUnionError PolygonOperation(PolyOperation operations, Point2DList polygon1, Point2DList polygon2, out Dictionary<UInt32, Point2DList>& results) { }

	public static bool PolygonsAreSame2D(IList<Point2D> poly1, IList<Point2D> poly2) { }

	public static bool PolygonsIntersect2D(IList<Point2D> poly1, Rect2D boundRect1, IList<Point2D> poly2, Rect2D boundRect2) { }

	public static PolyUnionError PolygonSubtract(Point2DList polygon1, Point2DList polygon2, out Point2DList subtract) { }

	private static void PolygonSubtractInternal(PolygonOperationContext ctx) { }

	public static PolyUnionError PolygonUnion(Point2DList polygon1, Point2DList polygon2, out Point2DList union) { }

	private static void PolygonUnionInternal(PolygonOperationContext ctx) { }

	public static IEnumerable<Point2DList> SplitComplexPolygon(Point2DList verts, double epsilon) { }

	private static IEnumerable<Point2DList> SplitComplexPolygonCleanup(IEnumerable<Point2D> orig) { }

}

