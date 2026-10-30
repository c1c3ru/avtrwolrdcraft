namespace Poly2Tri.Triangulation.Sets;

[DefaultMember("Item")]
public class PointSet : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
{
	private readonly Dictionary<UInt32, TriangulationPoint> _pointMap; //Field offset: 0x48
	[CompilerGenerated]
	private IList<DelaunayTriangle> <Triangles>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private string <FileName>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private bool <DisplayFlipX>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private bool <DisplayFlipY>k__BackingField; //Field offset: 0x61
	[CompilerGenerated]
	private float <DisplayRotate>k__BackingField; //Field offset: 0x64
	private double _precision; //Field offset: 0x68

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
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public private override IList<DelaunayTriangle> Triangles
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override TriangulationMode TriangulationMode
	{
		 get { } //Length: 8
	}

	protected PointSet(IEnumerable<TriangulationPoint> bounds) { }

	public virtual void Add(Point2D p) { }

	public override void Add(TriangulationPoint p) { }

	protected virtual void Add(Point2D p, int idx, bool constrainToBounds) { }

	protected bool Add(TriangulationPoint p, int idx, bool constrainToBounds) { }

	protected virtual void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder) { }

	public override bool AddRange(IEnumerable<TriangulationPoint> points) { }

	public override void AddTriangle(DelaunayTriangle t) { }

	public override void AddTriangles(IEnumerable<DelaunayTriangle> list) { }

	public override void ClearTriangles() { }

	protected bool ConstrainPointToBounds(TriangulationPoint p) { }

	protected bool ConstrainPointToBounds(Point2D p) { }

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

	public override TriangulationPoint get_Item(int index) { }

	public override double get_MaxX() { }

	public override double get_MaxY() { }

	public override double get_MinX() { }

	public override double get_MinY() { }

	public override double get_Precision() { }

	[CompilerGenerated]
	public override IList<DelaunayTriangle> get_Triangles() { }

	public override TriangulationMode get_TriangulationMode() { }

	public override int IndexOf(TriangulationPoint p) { }

	protected override bool Initialize() { }

	public override void Insert(int idx, TriangulationPoint item) { }

	public override void Prepare(TriangulationContext tcx) { }

	public virtual bool Remove(Point2D p) { }

	public override bool Remove(TriangulationPoint p) { }

	public virtual void RemoveAt(int idx) { }

	[CompilerGenerated]
	public override void set_DisplayFlipX(bool value) { }

	[CompilerGenerated]
	public override void set_DisplayFlipY(bool value) { }

	[CompilerGenerated]
	public override void set_DisplayRotate(float value) { }

	[CompilerGenerated]
	public void set_FileName(string value) { }

	public override void set_Item(int index, TriangulationPoint value) { }

	public override void set_Precision(double value) { }

	[CompilerGenerated]
	private void set_Triangles(IList<DelaunayTriangle> value) { }

	private override IEnumerator<TriangulationPoint> System.Collections.Generic.IEnumerable<Poly2Tri.Triangulation.TriangulationPoint>.GetEnumerator() { }

	protected bool TryGetPoint(double x, double y, out TriangulationPoint p) { }

}

