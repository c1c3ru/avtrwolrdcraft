namespace Poly2Tri.Triangulation.Delaunay;

public class DelaunayTriangle : IEquatable<DelaunayTriangle>
{
	public FixedArray3<TriangulationPoint> Points; //Field offset: 0x10
	public FixedArray3<DelaunayTriangle> Neighbors; //Field offset: 0x28
	private FixedArray3<Boolean> _edgeIsConstrained; //Field offset: 0x40
	public FixedArray3<Boolean> EdgeIsDelaunay; //Field offset: 0x43
	[CompilerGenerated]
	private bool <IsInterior>k__BackingField; //Field offset: 0x46

	public FixedArray3<Boolean> EdgeIsConstrained
	{
		 get { } //Length: 16
	}

	public bool IsInterior
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public DelaunayTriangle(TriangulationPoint p1, TriangulationPoint p2, TriangulationPoint p3) { }

	public double Area() { }

	public TriangulationPoint Centroid() { }

	internal void CircumCircleCenter(out double x, out double y) { }

	public void Clear() { }

	private void ClearNeighbor(DelaunayTriangle triangle) { }

	private void ClearNeighbors() { }

	public bool Contains(TriangulationPoint p) { }

	public int EdgeIndex(TriangulationPoint p1, TriangulationPoint p2) { }

	public override bool Equals(DelaunayTriangle other) { }

	public FixedArray3<Boolean> get_EdgeIsConstrained() { }

	[CompilerGenerated]
	public bool get_IsInterior() { }

	public bool GetConstrainedEdgeAcross(TriangulationPoint p) { }

	public bool GetConstrainedEdgeCCW(TriangulationPoint p) { }

	public bool GetConstrainedEdgeCW(TriangulationPoint p) { }

	public bool GetDelaunayEdgeAcross(TriangulationPoint p) { }

	public bool GetDelaunayEdgeCCW(TriangulationPoint p) { }

	public bool GetDelaunayEdgeCW(TriangulationPoint p) { }

	private bool GetEdge(int idx, out DTSweepConstraint edge) { }

	public bool GetEdgeAcross(TriangulationPoint p, out DTSweepConstraint edge) { }

	public bool GetEdgeCCW(TriangulationPoint p, out DTSweepConstraint edge) { }

	public bool GetEdgeCW(TriangulationPoint p, out DTSweepConstraint edge) { }

	private int IndexCCWFrom(TriangulationPoint p) { }

	public int IndexCWFrom(TriangulationPoint p) { }

	public int IndexOf(TriangulationPoint p) { }

	public void Legalize(TriangulationPoint oPoint, TriangulationPoint nPoint) { }

	public void MarkConstrainedEdge(int index) { }

	public void MarkConstrainedEdge(DTSweepConstraint edge) { }

	public void MarkConstrainedEdge(TriangulationPoint p, TriangulationPoint q) { }

	public void MarkEdge(IEnumerable<DelaunayTriangle> tList) { }

	public void MarkEdge(DelaunayTriangle triangle) { }

	private void MarkNeighbor(TriangulationPoint p1, TriangulationPoint p2, DelaunayTriangle t) { }

	public void MarkNeighbor(DelaunayTriangle t) { }

	public void MarkNeighborEdges() { }

	public DelaunayTriangle NeighborAcrossFrom(TriangulationPoint point) { }

	public DelaunayTriangle NeighborCCWFrom(TriangulationPoint point) { }

	public DelaunayTriangle NeighborCWFrom(TriangulationPoint point) { }

	public TriangulationPoint OppositePoint(DelaunayTriangle t, TriangulationPoint p) { }

	public TriangulationPoint PointCCWFrom(TriangulationPoint point) { }

	public TriangulationPoint PointCWFrom(TriangulationPoint point) { }

	private void RotateCW() { }

	[CompilerGenerated]
	public void set_IsInterior(bool value) { }

	private void SetConstrainedEdge(int idx, bool ce) { }

	public void SetConstrainedEdgeAcross(TriangulationPoint p, bool ce) { }

	public void SetConstrainedEdgeCCW(TriangulationPoint p, bool ce) { }

	public void SetConstrainedEdgeCW(TriangulationPoint p, bool ce) { }

	public void SetDelaunayEdgeAcross(TriangulationPoint p, bool ce) { }

	public void SetDelaunayEdgeCCW(TriangulationPoint p, bool ce) { }

	public void SetDelaunayEdgeCW(TriangulationPoint p, bool ce) { }

	public virtual string ToString() { }

}

