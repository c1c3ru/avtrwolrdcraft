namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct double3x3 : IEquatable<double3x3>, IFormattable
{
	public static readonly double3x3 identity; //Field offset: 0x0
	public static readonly double3x3 zero; //Field offset: 0x48
	public double3 c0; //Field offset: 0x0
	public double3 c1; //Field offset: 0x18
	public double3 c2; //Field offset: 0x30

	public double3 Item
	{
		 get { } //Length: 12
	}

	private static double3x3() { }

	public double3x3(float3x3 v) { }

	public double3x3(float v) { }

	public double3x3(uint3x3 v) { }

	public double3x3(uint v) { }

	public double3x3(int3x3 v) { }

	public double3x3(double3 c0, double3 c1, double3 c2) { }

	public double3x3(bool3x3 v) { }

	public double3x3(bool v) { }

	public double3x3(double v) { }

	public double3x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22) { }

	public double3x3(int v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(double3x3 rhs) { }

	public double3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static double3x3 op_Addition(double lhs, double3x3 rhs) { }

	public static double3x3 op_Addition(double3x3 lhs, double rhs) { }

	public static double3x3 op_Addition(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_Decrement(double3x3 val) { }

	public static double3x3 op_Division(double3x3 lhs, double rhs) { }

	public static double3x3 op_Division(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_Division(double lhs, double3x3 rhs) { }

	public static bool3x3 op_Equality(double lhs, double3x3 rhs) { }

	public static bool3x3 op_Equality(double3x3 lhs, double3x3 rhs) { }

	public static bool3x3 op_Equality(double3x3 lhs, double rhs) { }

	public static double3x3 op_Explicit(bool v) { }

	public static double3x3 op_Explicit(bool3x3 v) { }

	public static bool3x3 op_GreaterThan(double lhs, double3x3 rhs) { }

	public static bool3x3 op_GreaterThan(double3x3 lhs, double3x3 rhs) { }

	public static bool3x3 op_GreaterThan(double3x3 lhs, double rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(double lhs, double3x3 rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(double3x3 lhs, double rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_Implicit(uint3x3 v) { }

	public static double3x3 op_Implicit(int v) { }

	public static double3x3 op_Implicit(float3x3 v) { }

	public static double3x3 op_Implicit(double v) { }

	public static double3x3 op_Implicit(uint v) { }

	public static double3x3 op_Implicit(int3x3 v) { }

	public static double3x3 op_Implicit(float v) { }

	public static double3x3 op_Increment(double3x3 val) { }

	public static bool3x3 op_Inequality(double lhs, double3x3 rhs) { }

	public static bool3x3 op_Inequality(double3x3 lhs, double rhs) { }

	public static bool3x3 op_Inequality(double3x3 lhs, double3x3 rhs) { }

	public static bool3x3 op_LessThan(double lhs, double3x3 rhs) { }

	public static bool3x3 op_LessThan(double3x3 lhs, double rhs) { }

	public static bool3x3 op_LessThan(double3x3 lhs, double3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(double lhs, double3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(double3x3 lhs, double3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(double3x3 lhs, double rhs) { }

	public static double3x3 op_Modulus(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_Modulus(double lhs, double3x3 rhs) { }

	public static double3x3 op_Modulus(double3x3 lhs, double rhs) { }

	public static double3x3 op_Multiply(double lhs, double3x3 rhs) { }

	public static double3x3 op_Multiply(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_Multiply(double3x3 lhs, double rhs) { }

	public static double3x3 op_Subtraction(double lhs, double3x3 rhs) { }

	public static double3x3 op_Subtraction(double3x3 lhs, double rhs) { }

	public static double3x3 op_Subtraction(double3x3 lhs, double3x3 rhs) { }

	public static double3x3 op_UnaryNegation(double3x3 val) { }

	public static double3x3 op_UnaryPlus(double3x3 val) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

