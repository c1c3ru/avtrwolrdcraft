namespace Poly2Tri.Triangulation.Polygon;

[DefaultMember("Item")]
public class Contour : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public bool parentIsHole; //Field offset: 0x10

		public <>c__DisplayClass44_0() { }

		internal int <GetNumHoles>b__0(Contour c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public Point2D p; //Field offset: 0x10

		public <>c__DisplayClass56_0() { }

		internal bool <IsPointInsideContour>b__0(Contour c) { }

	}

	private readonly List<Contour> _holes; //Field offset: 0x48
	private ITriangulatable _parent; //Field offset: 0x50

	public override Rect2D Bounds
	{
		 get { } //Length: 12
	}

	public override bool DisplayFlipX
	{
		 get { } //Length: 164
		 set { } //Length: 4
	}

	public override bool DisplayFlipY
	{
		 get { } //Length: 164
		 set { } //Length: 4
	}

	public override float DisplayRotate
	{
		 get { } //Length: 164
		 set { } //Length: 4
	}

	public override TriangulationPoint Item
	{
		 get { } //Length: 168
		 set { } //Length: 104
	}

	public override double MaxX
	{
		 get { } //Length: 8
	}

	public override double MaxY
	{
		 get { } //Length: 8
	}

	public override double MinX
	{
		 get { } //Length: 8
	}

	public override double MinY
	{
		 get { } //Length: 8
	}

	public override double Precision
	{
		 get { } //Length: 164
		 set { } //Length: 4
	}

	public override IList<DelaunayTriangle> Triangles
	{
		 get { } //Length: 76
	}

	public override TriangulationMode TriangulationMode
	{
		 get { } //Length: 164
	}

	public Contour(ITriangulatable parent, IList<TriangulationPoint> points, WindingOrderType windingOrder) { }

	public Contour(ITriangulatable parent) { }

	public override void Add(TriangulationPoint p) { }

	protected virtual void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon) { }

	private void AddHole(Contour c) { }

	private void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder) { }

	protected virtual void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder) { }

	public override void AddTriangle(DelaunayTriangle t) { }

	public override void AddTriangles(IEnumerable<DelaunayTriangle> list) { }

	public override void ClearTriangles() { }

	public override bool Contains(TriangulationPoint p) { }

	public override void CopyTo(TriangulationPoint[] array, int arrayIndex) { }

	public Point2D FindPointInContour() { }

	public override Rect2D get_Bounds() { }

	public override bool get_DisplayFlipX() { }

	public override bool get_DisplayFlipY() { }

	public override float get_DisplayRotate() { }

	public override TriangulationPoint get_Item(int index) { }

	public override double get_MaxX() { }

	public override double get_MaxY() { }

	public override double get_MinX() { }

	public override double get_MinY() { }

	public override double get_Precision() { }

	public override IList<DelaunayTriangle> get_Triangles() { }

	public override TriangulationMode get_TriangulationMode() { }

	public void GetActualHoles(bool parentIsHole, ref List<Contour>& holes) { }

	private Contour GetHole(int idx) { }

	public Enumerator<Contour> GetHoleEnumerator() { }

	private int GetNumHoles() { }

	public int GetNumHoles(bool parentIsHole) { }

	public override int IndexOf(TriangulationPoint p) { }

	public void InitializeHoles(ConstrainedPointSet cps) { }

	public static void InitializeHoles(List<Contour> holes, ITriangulatable parent, ConstrainedPointSet cps) { }

	public override void Insert(int idx, TriangulationPoint p) { }

	private bool IsPointInsideContour(Point2D p) { }

	public override void Prepare(TriangulationContext tcx) { }

	public override bool Remove(TriangulationPoint p) { }

	public override void set_DisplayFlipX(bool value) { }

	public override void set_DisplayFlipY(bool value) { }

	public override void set_DisplayRotate(float value) { }

	public override void set_Item(int index, TriangulationPoint value) { }

	public override void set_Precision(double value) { }

	private override IEnumerator<TriangulationPoint> System.Collections.Generic.IEnumerable<Poly2Tri.Triangulation.TriangulationPoint>.GetEnumerator() { }

}

