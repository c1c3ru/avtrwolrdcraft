namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct uint3x2 : IEquatable<uint3x2>, IFormattable
{
	public static readonly uint3x2 zero; //Field offset: 0x0
	public uint3 c0; //Field offset: 0x0
	public uint3 c1; //Field offset: 0xC

	public uint3 Item
	{
		 get { } //Length: 12
	}

	public uint3x2(uint3 c0, uint3 c1) { }

	public uint3x2(uint m00, uint m01, uint m10, uint m11, uint m20, uint m21) { }

	public uint3x2(uint v) { }

	public uint3x2(bool v) { }

	public uint3x2(bool3x2 v) { }

	public uint3x2(int v) { }

	public uint3x2(int3x2 v) { }

	public uint3x2(float v) { }

	public uint3x2(float3x2 v) { }

	public uint3x2(double v) { }

	public uint3x2(double3x2 v) { }

	public override bool Equals(uint3x2 rhs) { }

	public virtual bool Equals(object o) { }

	public uint3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static uint3x2 op_Addition(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_Addition(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Addition(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_BitwiseAnd(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_BitwiseAnd(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_BitwiseAnd(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_BitwiseOr(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_BitwiseOr(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_BitwiseOr(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Decrement(uint3x2 val) { }

	public static uint3x2 op_Division(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_Division(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Division(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_Equality(uint lhs, uint3x2 rhs) { }

	public static bool3x2 op_Equality(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_Equality(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_ExclusiveOr(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_ExclusiveOr(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_ExclusiveOr(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Explicit(int3x2 v) { }

	public static uint3x2 op_Explicit(float v) { }

	public static uint3x2 op_Explicit(float3x2 v) { }

	public static uint3x2 op_Explicit(double v) { }

	public static uint3x2 op_Explicit(int v) { }

	public static uint3x2 op_Explicit(bool v) { }

	public static uint3x2 op_Explicit(bool3x2 v) { }

	public static uint3x2 op_Explicit(double3x2 v) { }

	public static bool3x2 op_GreaterThan(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_GreaterThan(uint3x2 lhs, uint rhs) { }

	public static bool3x2 op_GreaterThan(uint lhs, uint3x2 rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(uint3x2 lhs, uint rhs) { }

	public static bool3x2 op_GreaterThanOrEqual(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_Implicit(uint v) { }

	public static uint3x2 op_Increment(uint3x2 val) { }

	public static bool3x2 op_Inequality(uint3x2 lhs, uint rhs) { }

	public static bool3x2 op_Inequality(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_Inequality(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_LeftShift(uint3x2 x, int n) { }

	public static bool3x2 op_LessThan(uint3x2 lhs, uint3x2 rhs) { }

	public static bool3x2 op_LessThan(uint lhs, uint3x2 rhs) { }

	public static bool3x2 op_LessThan(uint3x2 lhs, uint rhs) { }

	public static bool3x2 op_LessThanOrEqual(uint lhs, uint3x2 rhs) { }

	public static bool3x2 op_LessThanOrEqual(uint3x2 lhs, uint rhs) { }

	public static bool3x2 op_LessThanOrEqual(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_Modulus(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_Modulus(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_Modulus(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Multiply(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_Multiply(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_Multiply(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_OnesComplement(uint3x2 val) { }

	public static uint3x2 op_RightShift(uint3x2 x, int n) { }

	public static uint3x2 op_Subtraction(uint lhs, uint3x2 rhs) { }

	public static uint3x2 op_Subtraction(uint3x2 lhs, uint rhs) { }

	public static uint3x2 op_Subtraction(uint3x2 lhs, uint3x2 rhs) { }

	public static uint3x2 op_UnaryNegation(uint3x2 val) { }

	public static uint3x2 op_UnaryPlus(uint3x2 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

