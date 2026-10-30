namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepContext : TriangulationContext
{
	private const float ALPHA = 0,3; //Field offset: 0x0
	public AdvancingFront Front; //Field offset: 0x40
	[CompilerGenerated]
	private TriangulationPoint <Head>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private TriangulationPoint <Tail>k__BackingField; //Field offset: 0x50
	public readonly DTSweepBasin Basin; //Field offset: 0x58
	public readonly DTSweepEdgeEvent EdgeEvent; //Field offset: 0x60
	private readonly DTSweepPointComparator _comparator; //Field offset: 0x68

	public virtual TriangulationAlgorithm Algorithm
	{
		 get { } //Length: 8
	}

	public DTSweepDebugContext DebugContext
	{
		 get { } //Length: 120
	}

	private TriangulationPoint Head
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private TriangulationPoint Tail
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public DTSweepContext() { }

	public void CreateAdvancingFront() { }

	public void FinalizeTriangulation() { }

	public virtual TriangulationAlgorithm get_Algorithm() { }

	public DTSweepDebugContext get_DebugContext() { }

	[CompilerGenerated]
	private TriangulationPoint get_Head() { }

	[CompilerGenerated]
	private TriangulationPoint get_Tail() { }

	public AdvancingFrontNode LocateNode(TriangulationPoint point) { }

	public void MapTriangleToNodes(DelaunayTriangle t) { }

	public void MeshClean(DelaunayTriangle triangle) { }

	private void MeshCleanReq(DelaunayTriangle triangle) { }

	public virtual DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b) { }

	public virtual void PrepareTriangulation(ITriangulatable t) { }

	public void RemoveFromList(DelaunayTriangle triangle) { }

	[CompilerGenerated]
	private void set_Head(TriangulationPoint value) { }

	[CompilerGenerated]
	private void set_Tail(TriangulationPoint value) { }

}

