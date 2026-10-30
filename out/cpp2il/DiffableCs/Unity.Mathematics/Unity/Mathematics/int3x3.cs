namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct int3x3 : IEquatable<int3x3>, IFormattable
{
	public static readonly int3x3 identity; //Field offset: 0x0
	public static readonly int3x3 zero; //Field offset: 0x24
	public int3 c0; //Field offset: 0x0
	public int3 c1; //Field offset: 0xC
	public int3 c2; //Field offset: 0x18

	public int3 Item
	{
		 get { } //Length: 12
	}

	private static int3x3() { }

	public int3x3(double3x3 v) { }

	public int3x3(double v) { }

	public int3x3(float3x3 v) { }

	public int3x3(float v) { }

	public int3x3(uint3x3 v) { }

	public int3x3(int3 c0, int3 c1, int3 c2) { }

	public int3x3(bool3x3 v) { }

	public int3x3(bool v) { }

	public int3x3(int v) { }

	public int3x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22) { }

	public int3x3(uint v) { }

	public override bool Equals(int3x3 rhs) { }

	public virtual bool Equals(object o) { }

	public int3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static int3x3 op_Addition(int lhs, int3x3 rhs) { }

	public static int3x3 op_Addition(int3x3 lhs, int rhs) { }

	public static int3x3 op_Addition(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_BitwiseAnd(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_BitwiseAnd(int3x3 lhs, int rhs) { }

	public static int3x3 op_BitwiseAnd(int lhs, int3x3 rhs) { }

	public static int3x3 op_BitwiseOr(int3x3 lhs, int rhs) { }

	public static int3x3 op_BitwiseOr(int lhs, int3x3 rhs) { }

	public static int3x3 op_BitwiseOr(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_Decrement(int3x3 val) { }

	public static int3x3 op_Division(int lhs, int3x3 rhs) { }

	public static int3x3 op_Division(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_Division(int3x3 lhs, int rhs) { }

	public static bool3x3 op_Equality(int3x3 lhs, int rhs) { }

	public static bool3x3 op_Equality(int3x3 lhs, int3x3 rhs) { }

	public static bool3x3 op_Equality(int lhs, int3x3 rhs) { }

	public static int3x3 op_ExclusiveOr(int3x3 lhs, int rhs) { }

	public static int3x3 op_ExclusiveOr(int lhs, int3x3 rhs) { }

	public static int3x3 op_ExclusiveOr(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_Explicit(float3x3 v) { }

	public static int3x3 op_Explicit(double3x3 v) { }

	public static int3x3 op_Explicit(float v) { }

	public static int3x3 op_Explicit(uint3x3 v) { }

	public static int3x3 op_Explicit(uint v) { }

	public static int3x3 op_Explicit(bool3x3 v) { }

	public static int3x3 op_Explicit(bool v) { }

	public static int3x3 op_Explicit(double v) { }

	public static bool3x3 op_GreaterThan(int lhs, int3x3 rhs) { }

	public static bool3x3 op_GreaterThan(int3x3 lhs, int rhs) { }

	public static bool3x3 op_GreaterThan(int3x3 lhs, int3x3 rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(int3x3 lhs, int3x3 rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(int3x3 lhs, int rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(int lhs, int3x3 rhs) { }

	public static int3x3 op_Implicit(int v) { }

	public static int3x3 op_Increment(int3x3 val) { }

	public static bool3x3 op_Inequality(int lhs, int3x3 rhs) { }

	public static bool3x3 op_Inequality(int3x3 lhs, int rhs) { }

	public static bool3x3 op_Inequality(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_LeftShift(int3x3 x, int n) { }

	public static bool3x3 op_LessThan(int3x3 lhs, int3x3 rhs) { }

	public static bool3x3 op_LessThan(int lhs, int3x3 rhs) { }

	public static bool3x3 op_LessThan(int3x3 lhs, int rhs) { }

	public static bool3x3 op_LessThanOrEqual(int3x3 lhs, int rhs) { }

	public static bool3x3 op_LessThanOrEqual(int lhs, int3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_Modulus(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_Modulus(int lhs, int3x3 rhs) { }

	public static int3x3 op_Modulus(int3x3 lhs, int rhs) { }

	public static int3x3 op_Multiply(int lhs, int3x3 rhs) { }

	public static int3x3 op_Multiply(int3x3 lhs, int rhs) { }

	public static int3x3 op_Multiply(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_OnesComplement(int3x3 val) { }

	public static int3x3 op_RightShift(int3x3 x, int n) { }

	public static int3x3 op_Subtraction(int lhs, int3x3 rhs) { }

	public static int3x3 op_Subtraction(int3x3 lhs, int rhs) { }

	public static int3x3 op_Subtraction(int3x3 lhs, int3x3 rhs) { }

	public static int3x3 op_UnaryNegation(int3x3 val) { }

	public static int3x3 op_UnaryPlus(int3x3 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

