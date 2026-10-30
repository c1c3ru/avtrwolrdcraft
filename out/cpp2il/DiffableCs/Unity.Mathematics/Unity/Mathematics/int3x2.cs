namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct int3x2 : IEquatable<int3x2>, IFormattable
{
	public static readonly int3x2 zero; //Field offset: 0x0
	public int3 c0; //Field offset: 0x0
	public int3 c1; //Field offset: 0xC

	public int3 Item
	{
		 get { } //Length: 12
	}

	public int3x2(int3 c0, int3 c1) { }

	public int3x2(int m00, int m01, int m10, int m11, int m20, int m21) { }

	public int3x2(int v) { }

	public int3x2(bool v) { }

	public int3x2(bool3x2 v) { }

	public int3x2(uint v) { }

	public int3x2(uint3x2 v) { }

	public int3x2(float v) { }

	public int3x2(float3x2 v) { }

	public int3x2(double v) { }

	public int3x2(double3x2 v) { }

	public override bool Equals(int3x2 rhs) { }

	public virtual bool Equals(object o) { }

	public int3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static int3x2 op_Addition(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_Addition(int3x2 lhs, int rhs) { }

	public static int3x2 op_Addition(int lhs, int3x2 rhs) { }

	public static int3x2 op_BitwiseAnd(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_BitwiseAnd(int3x2 lhs, int rhs) { }

	public static int3x2 op_BitwiseAnd(int lhs, int3x2 rhs) { }

	public static int3x2 op_BitwiseOr(int lhs, int3x2 rhs) { }

	public static int3x2 op_BitwiseOr(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_BitwiseOr(int3x2 lhs, int rhs) { }

	public static int3x2 op_Decrement(int3x2 val) { }

	public static int3x2 op_Division(int lhs, int3x2 rhs) { }

	public static int3x2 op_Division(int3x2 lhs, int rhs) { }

	public static int3x2 op_Division(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_Equality(int lhs, int3x2 rhs) { }

	public static bool3x2 op_Equality(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_Equality(int3x2 lhs, int rhs) { }

	public static int3x2 op_ExclusiveOr(int lhs, int3x2 rhs) { }

	public static int3x2 op_ExclusiveOr(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_ExclusiveOr(int3x2 lhs, int rhs) { }

	public static int3x2 op_Explicit(uint3x2 v) { }

	public static int3x2 op_Explicit(float v) { }

	public static int3x2 op_Explicit(float3x2 v) { }

	public static int3x2 op_Explicit(double v) { }

	public static int3x2 op_Explicit(uint v) { }

	public static int3x2 op_Explicit(bool v) { }

	public static int3x2 op_Explicit(bool3x2 v) { }

	public static int3x2 op_Explicit(double3x2 v) { }

	public static bool3x2 op_GreaterThan(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_GreaterThan(int3x2 lhs, int rhs) { }

	public static bool3x2 op_GreaterThan(int lhs, int3x2 rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(int3x2 lhs, int rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(int lhs, int3x2 rhs) { }

	public static int3x2 op_Implicit(int v) { }

	public static int3x2 op_Increment(int3x2 val) { }

	public static bool3x2 op_Inequality(int3x2 lhs, int rhs) { }

	public static bool3x2 op_Inequality(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_Inequality(int lhs, int3x2 rhs) { }

	public static int3x2 op_LeftShift(int3x2 x, int n) { }

	public static bool3x2 op_LessThan(int3x2 lhs, int3x2 rhs) { }

	public static bool3x2 op_LessThan(int lhs, int3x2 rhs) { }

	public static bool3x2 op_LessThan(int3x2 lhs, int rhs) { }

	public static bool3x2 op_LessThanOrEqual(int lhs, int3x2 rhs) { }

	public static bool3x2 op_LessThanOrEqual(int3x2 lhs, int rhs) { }

	public static bool3x2 op_LessThanOrEqual(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_Modulus(int lhs, int3x2 rhs) { }

	public static int3x2 op_Modulus(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_Modulus(int3x2 lhs, int rhs) { }

	public static int3x2 op_Multiply(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_Multiply(int lhs, int3x2 rhs) { }

	public static int3x2 op_Multiply(int3x2 lhs, int rhs) { }

	public static int3x2 op_OnesComplement(int3x2 val) { }

	public static int3x2 op_RightShift(int3x2 x, int n) { }

	public static int3x2 op_Subtraction(int lhs, int3x2 rhs) { }

	public static int3x2 op_Subtraction(int3x2 lhs, int rhs) { }

	public static int3x2 op_Subtraction(int3x2 lhs, int3x2 rhs) { }

	public static int3x2 op_UnaryNegation(int3x2 val) { }

	public static int3x2 op_UnaryPlus(int3x2 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

