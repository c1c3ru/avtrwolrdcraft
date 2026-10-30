namespace Poly2Tri.Utility;

public struct Rect2D
{
	private readonly double _minX; //Field offset: 0x0
	private readonly double _maxX; //Field offset: 0x8
	private readonly double _minY; //Field offset: 0x10
	private readonly double _maxY; //Field offset: 0x18

	public double Bottom
	{
		 get { } //Length: 8
	}

	public double Height
	{
		 get { } //Length: 12
	}

	public bool IsEmpty
	{
		 get { } //Length: 168
	}

	public double Left
	{
		 get { } //Length: 8
	}

	public double MaxX
	{
		 get { } //Length: 8
	}

	public double MaxY
	{
		 get { } //Length: 8
	}

	public double MinX
	{
		 get { } //Length: 8
	}

	public double MinY
	{
		 get { } //Length: 8
	}

	public double Right
	{
		 get { } //Length: 8
	}

	public double Top
	{
		 get { } //Length: 8
	}

	public double Width
	{
		 get { } //Length: 12
	}

	private Rect2D(double minX, double maxX, double minY, double maxY) { }

	public Rect2D AddPoint(Point2D p) { }

	private bool Equals(Rect2D r, double epsilon = 1E-12) { }

	public virtual bool Equals(object obj) { }

	public double get_Bottom() { }

	public double get_Height() { }

	public bool get_IsEmpty() { }

	public double get_Left() { }

	public double get_MaxX() { }

	public double get_MaxY() { }

	public double get_MinX() { }

	public double get_MinY() { }

	public double get_Right() { }

	public double get_Top() { }

	public double get_Width() { }

	public virtual int GetHashCode() { }

	public bool Intersects(Rect2D r) { }

}

