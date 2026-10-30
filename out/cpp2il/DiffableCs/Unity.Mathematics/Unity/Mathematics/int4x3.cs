namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct int4x3 : IEquatable<int4x3>, IFormattable
{
	public static readonly int4x3 zero; //Field offset: 0x0
	public int4 c0; //Field offset: 0x0
	public int4 c1; //Field offset: 0x10
	public int4 c2; //Field offset: 0x20

	public int4 Item
	{
		 get { } //Length: 8
	}

	public int4x3(int4 c0, int4 c1, int4 c2) { }

	public int4x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22, int m30, int m31, int m32) { }

	public int4x3(int v) { }

	public int4x3(bool v) { }

	public int4x3(bool4x3 v) { }

	public int4x3(uint v) { }

	public int4x3(uint4x3 v) { }

	public int4x3(float v) { }

	public int4x3(float4x3 v) { }

	public int4x3(double v) { }

	public int4x3(double4x3 v) { }

	public override bool Equals(int4x3 rhs) { }

	public virtual bool Equals(object o) { }

	public int4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static int4x3 op_Addition(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_Addition(int4x3 lhs, int rhs) { }

	public static int4x3 op_Addition(int lhs, int4x3 rhs) { }

	public static int4x3 op_BitwiseAnd(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_BitwiseAnd(int4x3 lhs, int rhs) { }

	public static int4x3 op_BitwiseAnd(int lhs, int4x3 rhs) { }

	public static int4x3 op_BitwiseOr(int lhs, int4x3 rhs) { }

	public static int4x3 op_BitwiseOr(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_BitwiseOr(int4x3 lhs, int rhs) { }

	public static int4x3 op_Decrement(int4x3 val) { }

	public static int4x3 op_Division(int lhs, int4x3 rhs) { }

	public static int4x3 op_Division(int4x3 lhs, int rhs) { }

	public static int4x3 op_Division(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_Equality(int lhs, int4x3 rhs) { }

	public static bool4x3 op_Equality(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_Equality(int4x3 lhs, int rhs) { }

	public static int4x3 op_ExclusiveOr(int lhs, int4x3 rhs) { }

	public static int4x3 op_ExclusiveOr(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_ExclusiveOr(int4x3 lhs, int rhs) { }

	public static int4x3 op_Explicit(uint4x3 v) { }

	public static int4x3 op_Explicit(float v) { }

	public static int4x3 op_Explicit(float4x3 v) { }

	public static int4x3 op_Explicit(double v) { }

	public static int4x3 op_Explicit(uint v) { }

	public static int4x3 op_Explicit(bool v) { }

	public static int4x3 op_Explicit(bool4x3 v) { }

	public static int4x3 op_Explicit(double4x3 v) { }

	public static bool4x3 op_GreaterThan(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_GreaterThan(int4x3 lhs, int rhs) { }

	public static bool4x3 op_GreaterThan(int lhs, int4x3 rhs) { }

	public static bool4x3 op_GreaterThanOrEqual(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_GreaterThanOrEqual(int4x3 lhs, int rhs) { }

	public static bool4x3 op_GreaterThanOrEqual(int lhs, int4x3 rhs) { }

	public static int4x3 op_Implicit(int v) { }

	public static int4x3 op_Increment(int4x3 val) { }

	public static bool4x3 op_Inequality(int4x3 lhs, int rhs) { }

	public static bool4x3 op_Inequality(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_Inequality(int lhs, int4x3 rhs) { }

	public static int4x3 op_LeftShift(int4x3 x, int n) { }

	public static bool4x3 op_LessThan(int4x3 lhs, int4x3 rhs) { }

	public static bool4x3 op_LessThan(int lhs, int4x3 rhs) { }

	public static bool4x3 op_LessThan(int4x3 lhs, int rhs) { }

	public static bool4x3 op_LessThanOrEqual(int lhs, int4x3 rhs) { }

	public static bool4x3 op_LessThanOrEqual(int4x3 lhs, int rhs) { }

	public static bool4x3 op_LessThanOrEqual(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_Modulus(int lhs, int4x3 rhs) { }

	public static int4x3 op_Modulus(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_Modulus(int4x3 lhs, int rhs) { }

	public static int4x3 op_Multiply(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_Multiply(int lhs, int4x3 rhs) { }

	public static int4x3 op_Multiply(int4x3 lhs, int rhs) { }

	public static int4x3 op_OnesComplement(int4x3 val) { }

	public static int4x3 op_RightShift(int4x3 x, int n) { }

	public static int4x3 op_Subtraction(int lhs, int4x3 rhs) { }

	public static int4x3 op_Subtraction(int4x3 lhs, int rhs) { }

	public static int4x3 op_Subtraction(int4x3 lhs, int4x3 rhs) { }

	public static int4x3 op_UnaryNegation(int4x3 val) { }

	public static int4x3 op_UnaryPlus(int4x3 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

