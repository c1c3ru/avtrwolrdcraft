namespace Poly2Tri.Triangulation.Polygon;

[DefaultMember("Item")]
public class Polygon : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
{
	private readonly Dictionary<UInt32, TriangulationPoint> _pointMap; //Field offset: 0x48
	private List<DelaunayTriangle> _triangles; //Field offset: 0x50
	[CompilerGenerated]
	private string <FileName>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private bool <DisplayFlipX>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private bool <DisplayFlipY>k__BackingField; //Field offset: 0x61
	[CompilerGenerated]
	private float <DisplayRotate>k__BackingField; //Field offset: 0x64
	private double _precision; //Field offset: 0x68
	[CompilerGenerated]
	private List<Polygon> <Holes>k__BackingField; //Field offset: 0x70
	private PolygonPoint _last; //Field offset: 0x78

	public override Rect2D Bounds
	{
		 get { } //Length: 12
	}

	public override bool DisplayFlipX
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public override bool DisplayFlipY
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public override float DisplayRotate
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public string FileName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private List<Polygon> Holes
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
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

	public IList<TriangulationPoint> Points
	{
		 get { } //Length: 4
	}

	public override double Precision
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override IList<DelaunayTriangle> Triangles
	{
		 get { } //Length: 8
	}

	public override TriangulationMode TriangulationMode
	{
		 get { } //Length: 8
	}

	private Polygon(IList<PolygonPoint> points) { }

	public Polygon(PolygonPoint[] points) { }

	public Polygon(IEnumerable<PolygonPoint> points) { }

	public virtual void Add(Point2D p) { }

	public override void Add(TriangulationPoint p) { }

	public void Add(PolygonPoint p) { }

	protected virtual void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon) { }

	public void AddHole(Polygon poly) { }

	private void AddRange(IList<PolygonPoint> points, WindingOrderType windingOrder) { }

	public void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder) { }

	public override void AddTriangle(DelaunayTriangle t) { }

	public override void AddTriangles(IEnumerable<DelaunayTriangle> list) { }

	public override void ClearTriangles() { }

	public override bool Contains(TriangulationPoint p) { }

	public override void CopyTo(TriangulationPoint[] array, int arrayIndex) { }

	public override Rect2D get_Bounds() { }

	[CompilerGenerated]
	public override bool get_DisplayFlipX() { }

	[CompilerGenerated]
	public override bool get_DisplayFlipY() { }

	[CompilerGenerated]
	public override float get_DisplayRotate() { }

	[CompilerGenerated]
	public string get_FileName() { }

	[CompilerGenerated]
	private List<Polygon> get_Holes() { }

	public override TriangulationPoint get_Item(int index) { }

	public override double get_MaxX() { }

	public override double get_MaxY() { }

	public override double get_MinX() { }

	public override double get_MinY() { }

	public IList<TriangulationPoint> get_Points() { }

	public override double get_Precision() { }

	public override IList<DelaunayTriangle> get_Triangles() { }

	public override TriangulationMode get_TriangulationMode() { }

	public override int IndexOf(TriangulationPoint p) { }

	public override void Insert(int idx, TriangulationPoint p) { }

	public bool IsPointInside(TriangulationPoint p) { }

	public override void Prepare(TriangulationContext tcx) { }

	public override bool Remove(TriangulationPoint p) { }

	public void RemovePoint(PolygonPoint p) { }

	[CompilerGenerated]
	public override void set_DisplayFlipX(bool value) { }

	[CompilerGenerated]
	public override void set_DisplayFlipY(bool value) { }

	[CompilerGenerated]
	public override void set_DisplayRotate(float value) { }

	[CompilerGenerated]
	public void set_FileName(string value) { }

	[CompilerGenerated]
	private void set_Holes(List<Polygon> value) { }

	public override void set_Item(int index, TriangulationPoint value) { }

	public override void set_Precision(double value) { }

	private override IEnumerator<TriangulationPoint> System.Collections.Generic.IEnumerable<Poly2Tri.Triangulation.TriangulationPoint>.GetEnumerator() { }

}

