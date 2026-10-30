namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepBasin
{
	public AdvancingFrontNode LeftNode; //Field offset: 0x10
	public AdvancingFrontNode BottomNode; //Field offset: 0x18
	public AdvancingFrontNode RightNode; //Field offset: 0x20
	public double Width; //Field offset: 0x28
	public bool LeftHighest; //Field offset: 0x30

	public DTSweepBasin() { }

}

