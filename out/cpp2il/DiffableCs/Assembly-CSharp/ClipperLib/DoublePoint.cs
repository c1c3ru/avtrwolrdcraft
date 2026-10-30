namespace ClipperLib;

public struct DoublePoint
{
	public double X; //Field offset: 0x0
	public double Y; //Field offset: 0x8

	public DoublePoint(double x = 0, double y = 0) { }

	public DoublePoint(DoublePoint dp) { }

	public DoublePoint(IntPoint ip) { }

}

