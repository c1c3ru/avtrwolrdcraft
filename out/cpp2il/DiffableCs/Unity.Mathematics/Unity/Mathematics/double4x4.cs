namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct double4x4 : IEquatable<double4x4>, IFormattable
{
	public static readonly double4x4 identity; //Field offset: 0x0
	public static readonly double4x4 zero; //Field offset: 0x80
	public double4 c0; //Field offset: 0x0
	public double4 c1; //Field offset: 0x20
	public double4 c2; //Field offset: 0x40
	public double4 c3; //Field offset: 0x60

	public double4 Item
	{
		 get { } //Length: 12
	}

	private static double4x4() { }

	public double4x4(float4x4 v) { }

	public double4x4(float v) { }

	public double4x4(uint4x4 v) { }

	public double4x4(uint v) { }

	public double4x4(int4x4 v) { }

	public double4x4(double4 c0, double4 c1, double4 c2, double4 c3) { }

	public double4x4(bool4x4 v) { }

	public double4x4(bool v) { }

	public double4x4(double v) { }

	public double4x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33) { }

	public double4x4(int v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(double4x4 rhs) { }

	public double4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static double4x4 op_Addition(double lhs, double4x4 rhs) { }

	public static double4x4 op_Addition(double4x4 lhs, double rhs) { }

	public static double4x4 op_Addition(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_Decrement(double4x4 val) { }

	public static double4x4 op_Division(double4x4 lhs, double rhs) { }

	public static double4x4 op_Division(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_Division(double lhs, double4x4 rhs) { }

	public static bool4x4 op_Equality(double lhs, double4x4 rhs) { }

	public static bool4x4 op_Equality(double4x4 lhs, double4x4 rhs) { }

	public static bool4x4 op_Equality(double4x4 lhs, double rhs) { }

	public static double4x4 op_Explicit(bool v) { }

	public static double4x4 op_Explicit(bool4x4 v) { }

	public static bool4x4 op_GreaterThan(double lhs, double4x4 rhs) { }

	public static bool4x4 op_GreaterThan(double4x4 lhs, double4x4 rhs) { }

	public static bool4x4 op_GreaterThan(double4x4 lhs, double rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(double lhs, double4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(double4x4 lhs, double rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_Implicit(uint4x4 v) { }

	public static double4x4 op_Implicit(int v) { }

	public static double4x4 op_Implicit(float4x4 v) { }

	public static double4x4 op_Implicit(double v) { }

	public static double4x4 op_Implicit(uint v) { }

	public static double4x4 op_Implicit(int4x4 v) { }

	public static double4x4 op_Implicit(float v) { }

	public static double4x4 op_Increment(double4x4 val) { }

	public static bool4x4 op_Inequality(double lhs, double4x4 rhs) { }

	public static bool4x4 op_Inequality(double4x4 lhs, double rhs) { }

	public static bool4x4 op_Inequality(double4x4 lhs, double4x4 rhs) { }

	public static bool4x4 op_LessThan(double lhs, double4x4 rhs) { }

	public static bool4x4 op_LessThan(double4x4 lhs, double rhs) { }

	public static bool4x4 op_LessThan(double4x4 lhs, double4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(double lhs, double4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(double4x4 lhs, double4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(double4x4 lhs, double rhs) { }

	public static double4x4 op_Modulus(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_Modulus(double lhs, double4x4 rhs) { }

	public static double4x4 op_Modulus(double4x4 lhs, double rhs) { }

	public static double4x4 op_Multiply(double lhs, double4x4 rhs) { }

	public static double4x4 op_Multiply(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_Multiply(double4x4 lhs, double rhs) { }

	public static double4x4 op_Subtraction(double lhs, double4x4 rhs) { }

	public static double4x4 op_Subtraction(double4x4 lhs, double rhs) { }

	public static double4x4 op_Subtraction(double4x4 lhs, double4x4 rhs) { }

	public static double4x4 op_UnaryNegation(double4x4 val) { }

	public static double4x4 op_UnaryPlus(double4x4 val) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

