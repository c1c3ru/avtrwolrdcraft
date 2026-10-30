namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepDebugContext : TriangulationDebugContext
{
	[CompilerGenerated]
	private DelaunayTriangle <PrimaryTriangle>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private DelaunayTriangle <SecondaryTriangle>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private TriangulationPoint <ActivePoint>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private AdvancingFrontNode <ActiveNode>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private DTSweepConstraint <ActiveConstraint>k__BackingField; //Field offset: 0x30

	public DTSweepConstraint ActiveConstraint
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public AdvancingFrontNode ActiveNode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public TriangulationPoint ActivePoint
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public bool IsDebugContext
	{
		 get { } //Length: 8
	}

	public DelaunayTriangle PrimaryTriangle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public DelaunayTriangle SecondaryTriangle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public DTSweepDebugContext() { }

	public virtual void Clear() { }

	[CompilerGenerated]
	public DTSweepConstraint get_ActiveConstraint() { }

	[CompilerGenerated]
	public AdvancingFrontNode get_ActiveNode() { }

	[CompilerGenerated]
	public TriangulationPoint get_ActivePoint() { }

	public bool get_IsDebugContext() { }

	[CompilerGenerated]
	public DelaunayTriangle get_PrimaryTriangle() { }

	[CompilerGenerated]
	public DelaunayTriangle get_SecondaryTriangle() { }

	[CompilerGenerated]
	public void set_ActiveConstraint(DTSweepConstraint value) { }

	[CompilerGenerated]
	public void set_ActiveNode(AdvancingFrontNode value) { }

	[CompilerGenerated]
	public void set_ActivePoint(TriangulationPoint value) { }

	[CompilerGenerated]
	public void set_PrimaryTriangle(DelaunayTriangle value) { }

	[CompilerGenerated]
	public void set_SecondaryTriangle(DelaunayTriangle value) { }

}

