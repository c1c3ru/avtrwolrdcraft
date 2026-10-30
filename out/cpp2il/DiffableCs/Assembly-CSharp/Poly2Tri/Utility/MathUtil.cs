namespace Poly2Tri.Utility;

public class MathUtil
{
	public const double EPSILON = 1E-12; //Field offset: 0x0

	public MathUtil() { }

	public static bool AreValuesEqual(double val1, double val2, double tolerance = 1E-12) { }

	public static double Clamp(double a, double low, double high) { }

	public static bool IsValueBetween(double val, double min, double max, double tolerance) { }

	public static uint Jenkins32Hash(IEnumerable<Byte> data, uint nInitialValue) { }

	public static double RoundWithPrecision(double f, double precision) { }

	public static void Swap(ref T a, ref T b) { }

}

