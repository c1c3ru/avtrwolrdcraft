namespace Poly2Tri.Utility;

public class Point2D : IComparable<Point2D>
{
	private double _x; //Field offset: 0x10
	private double _y; //Field offset: 0x18

	public override double X
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Xf
	{
		 get { } //Length: 28
	}

	public override double Y
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Yf
	{
		 get { } //Length: 28
	}

	public Point2D() { }

	public Point2D(double x, double y) { }

	public override int CompareTo(Point2D other) { }

	public double Cross(Point2D p) { }

	public static double Cross(Point2D lhs, Point2D rhs) { }

	public double Dot(Point2D p) { }

	public static double Dot(Point2D lhs, Point2D rhs) { }

	public bool Equals(Point2D p, double epsilon = 0) { }

	public virtual bool Equals(object obj) { }

	public override double get_X() { }

	public float get_Xf() { }

	public override double get_Y() { }

	public float get_Yf() { }

	public virtual int GetHashCode() { }

	public double Magnitude() { }

	private double MagnitudeReciprocal() { }

	public double MagnitudeSquared() { }

	private void Multiply(double scalar) { }

	public void Normalize() { }

	public static Point2D op_Addition(Point2D lhs, double scalar) { }

	public static Point2D op_Addition(Point2D lhs, Point2D rhs) { }

	public static Point2D op_Division(Point2D lhs, double scalar) { }

	public static Point2D op_Division(Point2D lhs, Point2D rhs) { }

	public static bool op_GreaterThan(Point2D lhs, Point2D rhs) { }

	public static bool op_GreaterThanOrEqual(Point2D lhs, Point2D rhs) { }

	public static bool op_LessThan(Point2D lhs, Point2D rhs) { }

	public static bool op_LessThanOrEqual(Point2D lhs, Point2D rhs) { }

	public static Point2D op_Multiply(Point2D lhs, Point2D rhs) { }

	public static Point2D op_Multiply(Point2D lhs, double scalar) { }

	public static Point2D op_Multiply(double scalar, Point2D rhs) { }

	public static Point2D op_Subtraction(Point2D lhs, Point2D rhs) { }

	public static Point2D op_Subtraction(Point2D lhs, double scalar) { }

	public static Point2D op_UnaryNegation(Point2D p) { }

	public static Point2D Perpendicular(Point2D lhs, double scalar) { }

	public static Point2D Perpendicular(double scalar, Point2D rhs) { }

	public override void Set(double x, double y) { }

	public override void set_X(double value) { }

	public override void set_Y(double value) { }

	public void Subtract(Point2D p) { }

	public virtual string ToString() { }

}

