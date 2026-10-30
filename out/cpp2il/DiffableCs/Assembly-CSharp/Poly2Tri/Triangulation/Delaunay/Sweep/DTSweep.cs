namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public static class DTSweep
{
	private const double PI_DIV2 = 1,5707963267948966; //Field offset: 0x0
	private const double PI_3_DIV4 = 2,356194490192345; //Field offset: 0x0

	private static double BasinAngle(AdvancingFrontNode node) { }

	private static void EdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle triangle, TriangulationPoint point) { }

	private static void EdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node) { }

	private static void Fill(DTSweepContext tcx, AdvancingFrontNode node) { }

	private static void FillAdvancingFront(DTSweepContext tcx, AdvancingFrontNode n) { }

	private static void FillBasin(DTSweepContext tcx, AdvancingFrontNode node) { }

	private static void FillBasinReq(DTSweepContext tcx, AdvancingFrontNode node) { }

	private static void FillEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillLeftAboveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillLeftBelowEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillLeftConcaveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillLeftConvexEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillRightAboveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillRightBelowEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillRightConcaveEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FillRightConvexEdgeEvent(DTSweepContext tcx, TriangulationConstraint edge, AdvancingFrontNode node) { }

	private static void FinalizationConstraints(DTSweepContext tcx) { }

	private static void FinalizationConvexHull(DTSweepContext tcx) { }

	private static void FinalizationPolygon(DTSweepContext tcx) { }

	private static void FixupConstrainedEdges(TriangulationContext tcx) { }

	private static void FlipEdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle t, TriangulationPoint p) { }

	private static void FlipScanEdgeEvent(DTSweepContext tcx, Point2D ep, TriangulationPoint eq, DelaunayTriangle flipTriangle, DelaunayTriangle t, TriangulationPoint p) { }

	private static double HoleAngle(AdvancingFrontNode node) { }

	private static bool IsEdgeSideOfTriangle(DelaunayTriangle triangle, TriangulationPoint ep, TriangulationPoint eq) { }

	private static bool IsShallow(DTSweepContext tcx, AdvancingFrontNode node) { }

	private static bool Legalize(DTSweepContext tcx, DelaunayTriangle t) { }

	private static AdvancingFrontNode NewFrontTriangle(DTSweepContext tcx, TriangulationPoint point, AdvancingFrontNode node) { }

	private static bool NextFlipPoint(Point2D ep, Point2D eq, DelaunayTriangle ot, TriangulationPoint op, out TriangulationPoint newP) { }

	private static DelaunayTriangle NextFlipTriangle(DTSweepContext tcx, Orientation o, DelaunayTriangle t, DelaunayTriangle ot, TriangulationPoint p, TriangulationPoint op) { }

	private static AdvancingFrontNode PointEvent(DTSweepContext tcx, TriangulationPoint point) { }

	private static void RotateTrianglePair(DelaunayTriangle t, TriangulationPoint p, DelaunayTriangle ot, TriangulationPoint op) { }

	private static void Sweep(DTSweepContext tcx) { }

	public static void Triangulate(DTSweepContext tcx) { }

	private static void TurnAdvancingFrontConvex(DTSweepContext tcx, AdvancingFrontNode b, AdvancingFrontNode c) { }

}

