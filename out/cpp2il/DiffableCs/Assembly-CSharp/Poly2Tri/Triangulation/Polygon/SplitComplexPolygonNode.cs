namespace Poly2Tri.Triangulation.Polygon;

[DefaultMember("Item")]
public class SplitComplexPolygonNode
{
	private readonly List<SplitComplexPolygonNode> _connected; //Field offset: 0x10
	private Point2D _position; //Field offset: 0x18

	public SplitComplexPolygonNode Item
	{
		 get { } //Length: 88
	}

	public int NumConnected
	{
		 get { } //Length: 72
	}

	public Point2D Position
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SplitComplexPolygonNode(Point2D pos) { }

	public void AddConnection(SplitComplexPolygonNode toMe) { }

	public void ClearConnections() { }

	public virtual bool Equals(object obj) { }

	public bool Equals(SplitComplexPolygonNode pn) { }

	public SplitComplexPolygonNode get_Item(int index) { }

	public int get_NumConnected() { }

	public Point2D get_Position() { }

	public virtual int GetHashCode() { }

	public SplitComplexPolygonNode GetRightestConnection(Point2D incomingDir) { }

	public SplitComplexPolygonNode GetRightestConnection(SplitComplexPolygonNode incoming) { }

	private bool IsRighter(double sinA, double cosA, double sinB, double cosB) { }

	public static bool op_Equality(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs) { }

	public static bool op_Inequality(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs) { }

	public void RemoveConnection(SplitComplexPolygonNode fromMe) { }

	public void set_Position(Point2D value) { }

	public virtual string ToString() { }

}

