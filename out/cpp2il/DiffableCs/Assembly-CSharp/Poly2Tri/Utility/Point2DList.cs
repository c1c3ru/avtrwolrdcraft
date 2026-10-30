namespace Poly2Tri.Utility;

[DefaultMember("Item")]
public class Point2DList : IEnumerable<Point2D>, IEnumerable, IList<Point2D>, ICollection<Point2D>
{
	[Flags]
	internal enum PolygonError
	{
		None = 0,
		NotEnoughVertices = 1,
		NotConvex = 2,
		NotSimple = 4,
		AreaTooSmall = 8,
		SidesTooCloseToParallel = 16,
		TooThin = 32,
		Degenerate = 64,
		Unknown = 1073741824,
	}

	internal enum WindingOrderType
	{
		Clockwise = 0,
		AntiClockwise = 1,
		Unknown = 2,
		Default = 1,
	}

	private const int MAX_POLYGON_VERTICES = 100000; //Field offset: 0x0
	public const double LINEAR_SLOP = 0,005; //Field offset: 0x0
	private const double ANGULAR_SLOP = 0,0035367765131532297; //Field offset: 0x0
	protected readonly List<Point2D> MPoints; //Field offset: 0x10
	private WindingOrderType _windingOrder; //Field offset: 0x18
	private Rect2D _boundingBox; //Field offset: 0x20
	[CompilerGenerated]
	private double <Epsilon>k__BackingField; //Field offset: 0x40

	public Rect2D BoundingBox
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public override int Count
	{
		 get { } //Length: 72
	}

	public double Epsilon
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 8
	}

	public override Point2D Item
	{
		 get { } //Length: 88
		 set { } //Length: 104
	}

	public WindingOrderType WindingOrder
	{
		 get { } //Length: 8
		 set { } //Length: 148
	}

	public Point2DList() { }

	private Point2DList(int capacity) { }

	public Point2DList(Point2DList l) { }

	protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon) { }

	public override void Add(Point2D p) { }

	protected override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder) { }

	public void AddRange(IEnumerable<Point2D> items) { }

	public void AddRange(Point2DList l) { }

	private void CalculateBounds() { }

	public double CalculateEpsilon() { }

	public WindingOrderType CalculateWindingOrder() { }

	public PolygonError CheckPolygon() { }

	public override void Clear() { }

	public override bool Contains(Point2D p) { }

	public override void CopyTo(Point2D[] array, int arrayIndex) { }

	public Rect2D get_BoundingBox() { }

	public override int get_Count() { }

	[CompilerGenerated]
	public double get_Epsilon() { }

	public override bool get_IsReadOnly() { }

	public override Point2D get_Item(int index) { }

	public WindingOrderType get_WindingOrder() { }

	private double GetArea() { }

	public Point2D GetCentroid() { }

	public static string GetErrorString(PolygonError error) { }

	private double GetSignedArea() { }

	public override int IndexOf(Point2D p) { }

	public override void Insert(int idx, Point2D item) { }

	public bool IsConvex() { }

	private bool IsDegenerate() { }

	private bool IsSimple() { }

	public void MergeParallelEdges(double tolerance) { }

	public int NextIndex(int index) { }

	public int PreviousIndex(int index) { }

	public void ProjectToAxis(Point2D axis, out double min, out double max) { }

	public override bool Remove(Point2D p) { }

	public override void RemoveAt(int idx) { }

	public void RemoveDuplicateNeighborPoints() { }

	public void RemoveRange(int idxStart, int count) { }

	public void Rotate(double radians) { }

	public void Scale(Point2D value) { }

	protected void set_BoundingBox(Rect2D value) { }

	[CompilerGenerated]
	protected void set_Epsilon(double value) { }

	public override void set_Item(int index, Point2D value) { }

	public void set_WindingOrder(WindingOrderType value) { }

	public void Simplify(double bias = 0) { }

	private override IEnumerator<Point2D> System.Collections.Generic.IEnumerable<Poly2Tri.Utility.Point2D>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public virtual string ToString() { }

	public void Translate(Point2D vector) { }

}

