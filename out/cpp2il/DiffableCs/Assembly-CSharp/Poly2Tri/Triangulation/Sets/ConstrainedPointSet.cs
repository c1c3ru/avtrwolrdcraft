namespace Poly2Tri.Triangulation.Sets;

public class ConstrainedPointSet : PointSet
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Contour, Int32> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <GetNumHoles>b__17_0(Contour c) { }

	}

	private readonly Dictionary<UInt32, TriangulationConstraint> _constraintMap; //Field offset: 0x70
	private readonly List<Contour> _holes; //Field offset: 0x78

	public virtual TriangulationMode TriangulationMode
	{
		 get { } //Length: 8
	}

	public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds) { }

	public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds, IEnumerable<TriangulationConstraint> constraints) { }

	public ConstrainedPointSet(IList<TriangulationPoint> bounds, ICollection<Int32> indices) { }

	public virtual void Add(Point2D p) { }

	public virtual void Add(TriangulationPoint p) { }

	private void AddBoundaryConstraints() { }

	public void AddConstraint(TriangulationConstraint tc) { }

	private void AddConstraints(IEnumerable<TriangulationConstraint> constraints) { }

	public bool AddHole(List<TriangulationPoint> points) { }

	public virtual bool AddRange(IEnumerable<TriangulationPoint> points) { }

	public virtual void AddTriangle(DelaunayTriangle t) { }

	public virtual TriangulationMode get_TriangulationMode() { }

	public int GetActualHoles(out List<Contour>& holes) { }

	public Enumerator<UInt32, TriangulationConstraint> GetConstraintEnumerator() { }

	public Contour GetHole(int idx) { }

	public int GetNumConstraints() { }

	public int GetNumHoles() { }

	protected virtual bool Initialize() { }

	private void InitializeHoles() { }

	public virtual void Prepare(TriangulationContext tcx) { }

	public bool TryGetConstraint(uint constraintCode, out TriangulationConstraint tc) { }

}

