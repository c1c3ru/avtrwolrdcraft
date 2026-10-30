namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class AdvancingFront
{
	public AdvancingFrontNode Head; //Field offset: 0x10
	public AdvancingFrontNode Tail; //Field offset: 0x18
	private AdvancingFrontNode _search; //Field offset: 0x20

	public AdvancingFront(AdvancingFrontNode head, AdvancingFrontNode tail) { }

	public AdvancingFrontNode LocateNode(TriangulationPoint point) { }

	private AdvancingFrontNode LocateNode(double x) { }

	public AdvancingFrontNode LocatePoint(TriangulationPoint point) { }

	public virtual string ToString() { }

}

