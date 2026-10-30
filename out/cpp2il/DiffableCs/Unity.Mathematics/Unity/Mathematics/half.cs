namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public struct half : IEquatable<half>, IFormattable
{
	public static readonly half zero; //Field offset: 0x0
	public ushort value; //Field offset: 0x0

	public static float MaxValue
	{
		 get { } //Length: 12
	}

	public static half MaxValueAsHalf
	{
		 get { } //Length: 8
	}

	public static float MinValue
	{
		 get { } //Length: 12
	}

	public static half MinValueAsHalf
	{
		 get { } //Length: 8
	}

	private static half() { }

	public half(double v) { }

	public half(half x) { }

	public half(float v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(half rhs) { }

	public static float get_MaxValue() { }

	public static half get_MaxValueAsHalf() { }

	public static float get_MinValue() { }

	public static half get_MinValueAsHalf() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(half lhs, half rhs) { }

	public static half op_Explicit(float v) { }

	public static half op_Explicit(double v) { }

	public static double op_Implicit(half d) { }

	public static float op_Implicit(half d) { }

	public static bool op_Inequality(half lhs, half rhs) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

