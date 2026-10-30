namespace ClipperLib;

public struct IntPoint
{
	public long X; //Field offset: 0x0
	public long Y; //Field offset: 0x8

	public IntPoint(long X, long Y) { }

	public IntPoint(double x, double y) { }

	public IntPoint(IntPoint pt) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(IntPoint a, IntPoint b) { }

	public static bool op_Inequality(IntPoint a, IntPoint b) { }

}

