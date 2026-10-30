namespace Poly2Tri.Triangulation;

public class TriangulationPoint : Point2D, IEquatable<TriangulationPoint>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public TriangulationPoint <>4__this; //Field offset: 0x10
		public TriangulationPoint p; //Field offset: 0x18
		public Func<DTSweepConstraint, Boolean> <>9__0; //Field offset: 0x20

		public <>c__DisplayClass26_0() { }

		internal bool <GetEdge>b__0(DTSweepConstraint sc) { }

	}

	public const double VERTEX_CODE_DEFAULT_PRECISION = 3; //Field offset: 0x0
	[CompilerGenerated]
	private uint <VertexCode>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private List<DTSweepConstraint> <Edges>k__BackingField; //Field offset: 0x28

	public private List<DTSweepConstraint> Edges
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool HasEdges
	{
		 get { } //Length: 16
	}

	public private uint VertexCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public virtual double X
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public virtual double Y
	{
		 get { } //Length: 8
		 set { } //Length: 52
	}

	public TriangulationPoint(double x, double y, double precision = 3) { }

	public void AddEdge(DTSweepConstraint e) { }

	public static uint CreateVertexCode(double x, double y, double precision) { }

	public override bool Equals(TriangulationPoint other) { }

	public virtual bool Equals(object obj) { }

	[CompilerGenerated]
	public List<DTSweepConstraint> get_Edges() { }

	public bool get_HasEdges() { }

	[CompilerGenerated]
	public uint get_VertexCode() { }

	public virtual double get_X() { }

	public virtual double get_Y() { }

	public bool GetEdge(TriangulationPoint p, out DTSweepConstraint edge) { }

	public virtual int GetHashCode() { }

	public bool HasEdge(TriangulationPoint p) { }

	public virtual void Set(double x, double y) { }

	[CompilerGenerated]
	private void set_Edges(List<DTSweepConstraint> value) { }

	[CompilerGenerated]
	private void set_VertexCode(uint value) { }

	public virtual void set_X(double value) { }

	public virtual void set_Y(double value) { }

	public virtual string ToString() { }

}

