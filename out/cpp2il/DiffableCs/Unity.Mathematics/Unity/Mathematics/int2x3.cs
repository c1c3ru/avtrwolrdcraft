namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct int2x3 : IEquatable<int2x3>, IFormattable
{
	public static readonly int2x3 zero; //Field offset: 0x0
	public int2 c0; //Field offset: 0x0
	public int2 c1; //Field offset: 0x8
	public int2 c2; //Field offset: 0x10

	public int2 Item
	{
		 get { } //Length: 8
	}

	public int2x3(int2 c0, int2 c1, int2 c2) { }

	public int2x3(int m00, int m01, int m02, int m10, int m11, int m12) { }

	public int2x3(int v) { }

	public int2x3(bool v) { }

	public int2x3(bool2x3 v) { }

	public int2x3(uint v) { }

	public int2x3(uint2x3 v) { }

	public int2x3(float v) { }

	public int2x3(float2x3 v) { }

	public int2x3(double v) { }

	public int2x3(double2x3 v) { }

	public override bool Equals(int2x3 rhs) { }

	public virtual bool Equals(object o) { }

	public int2 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static int2x3 op_Addition(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_Addition(int2x3 lhs, int rhs) { }

	public static int2x3 op_Addition(int lhs, int2x3 rhs) { }

	public static int2x3 op_BitwiseAnd(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_BitwiseAnd(int2x3 lhs, int rhs) { }

	public static int2x3 op_BitwiseAnd(int lhs, int2x3 rhs) { }

	public static int2x3 op_BitwiseOr(int lhs, int2x3 rhs) { }

	public static int2x3 op_BitwiseOr(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_BitwiseOr(int2x3 lhs, int rhs) { }

	public static int2x3 op_Decrement(int2x3 val) { }

	public static int2x3 op_Division(int lhs, int2x3 rhs) { }

	public static int2x3 op_Division(int2x3 lhs, int rhs) { }

	public static int2x3 op_Division(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_Equality(int lhs, int2x3 rhs) { }

	public static bool2x3 op_Equality(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_Equality(int2x3 lhs, int rhs) { }

	public static int2x3 op_ExclusiveOr(int lhs, int2x3 rhs) { }

	public static int2x3 op_ExclusiveOr(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_ExclusiveOr(int2x3 lhs, int rhs) { }

	public static int2x3 op_Explicit(uint2x3 v) { }

	public static int2x3 op_Explicit(float v) { }

	public static int2x3 op_Explicit(float2x3 v) { }

	public static int2x3 op_Explicit(double v) { }

	public static int2x3 op_Explicit(uint v) { }

	public static int2x3 op_Explicit(bool v) { }

	public static int2x3 op_Explicit(bool2x3 v) { }

	public static int2x3 op_Explicit(double2x3 v) { }

	public static bool2x3 op_GreaterThan(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_GreaterThan(int2x3 lhs, int rhs) { }

	public static bool2x3 op_GreaterThan(int lhs, int2x3 rhs) { }

	public static bool2x3 op_GreaterThanOrEqual(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_GreaterThanOrEqual(int2x3 lhs, int rhs) { }

	public static bool2x3 op_GreaterThanOrEqual(int lhs, int2x3 rhs) { }

	public static int2x3 op_Implicit(int v) { }

	public static int2x3 op_Increment(int2x3 val) { }

	public static bool2x3 op_Inequality(int2x3 lhs, int rhs) { }

	public static bool2x3 op_Inequality(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_Inequality(int lhs, int2x3 rhs) { }

	public static int2x3 op_LeftShift(int2x3 x, int n) { }

	public static bool2x3 op_LessThan(int2x3 lhs, int2x3 rhs) { }

	public static bool2x3 op_LessThan(int lhs, int2x3 rhs) { }

	public static bool2x3 op_LessThan(int2x3 lhs, int rhs) { }

	public static bool2x3 op_LessThanOrEqual(int lhs, int2x3 rhs) { }

	public static bool2x3 op_LessThanOrEqual(int2x3 lhs, int rhs) { }

	public static bool2x3 op_LessThanOrEqual(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_Modulus(int lhs, int2x3 rhs) { }

	public static int2x3 op_Modulus(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_Modulus(int2x3 lhs, int rhs) { }

	public static int2x3 op_Multiply(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_Multiply(int lhs, int2x3 rhs) { }

	public static int2x3 op_Multiply(int2x3 lhs, int rhs) { }

	public static int2x3 op_OnesComplement(int2x3 val) { }

	public static int2x3 op_RightShift(int2x3 x, int n) { }

	public static int2x3 op_Subtraction(int lhs, int2x3 rhs) { }

	public static int2x3 op_Subtraction(int2x3 lhs, int rhs) { }

	public static int2x3 op_Subtraction(int2x3 lhs, int2x3 rhs) { }

	public static int2x3 op_UnaryNegation(int2x3 val) { }

	public static int2x3 op_UnaryPlus(int2x3 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

