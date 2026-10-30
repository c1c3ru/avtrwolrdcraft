namespace Poly2Tri.Triangulation;

public abstract class TriangulationContext
{
	[CompilerGenerated]
	private TriangulationDebugContext <DebugContext>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <IsDebugEnabled>k__BackingField; //Field offset: 0x18
	public readonly List<DelaunayTriangle> Triangles; //Field offset: 0x20
	public readonly List<TriangulationPoint> Points; //Field offset: 0x28
	[CompilerGenerated]
	private TriangulationMode <TriangulationMode>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private ITriangulatable <Triangulatable>k__BackingField; //Field offset: 0x38

	public abstract TriangulationAlgorithm Algorithm
	{
		 get { } //Length: 0
	}

	protected private TriangulationDebugContext DebugContext
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsDebugEnabled
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private ITriangulatable Triangulatable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private TriangulationMode TriangulationMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	protected TriangulationContext(TriangulationDebugContext debug) { }

	public abstract TriangulationAlgorithm get_Algorithm() { }

	[CompilerGenerated]
	protected TriangulationDebugContext get_DebugContext() { }

	[CompilerGenerated]
	public bool get_IsDebugEnabled() { }

	[CompilerGenerated]
	public ITriangulatable get_Triangulatable() { }

	[CompilerGenerated]
	public TriangulationMode get_TriangulationMode() { }

	public abstract DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b) { }

	public override void PrepareTriangulation(ITriangulatable t) { }

	[CompilerGenerated]
	private void set_DebugContext(TriangulationDebugContext value) { }

	[CompilerGenerated]
	protected void set_IsDebugEnabled(bool value) { }

	[CompilerGenerated]
	private void set_Triangulatable(ITriangulatable value) { }

	[CompilerGenerated]
	private void set_TriangulationMode(TriangulationMode value) { }

}

