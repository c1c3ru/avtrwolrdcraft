namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct uint3x4 : IEquatable<uint3x4>, IFormattable
{
	public static readonly uint3x4 zero; //Field offset: 0x0
	public uint3 c0; //Field offset: 0x0
	public uint3 c1; //Field offset: 0xC
	public uint3 c2; //Field offset: 0x18
	public uint3 c3; //Field offset: 0x24

	public uint3 Item
	{
		 get { } //Length: 12
	}

	public uint3x4(uint3 c0, uint3 c1, uint3 c2, uint3 c3) { }

	public uint3x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13, uint m20, uint m21, uint m22, uint m23) { }

	public uint3x4(uint v) { }

	public uint3x4(bool v) { }

	public uint3x4(bool3x4 v) { }

	public uint3x4(int v) { }

	public uint3x4(int3x4 v) { }

	public uint3x4(float v) { }

	public uint3x4(float3x4 v) { }

	public uint3x4(double v) { }

	public uint3x4(double3x4 v) { }

	public override bool Equals(uint3x4 rhs) { }

	public virtual bool Equals(object o) { }

	public uint3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static uint3x4 op_Addition(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_Addition(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Addition(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_BitwiseAnd(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_BitwiseAnd(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_BitwiseAnd(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_BitwiseOr(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_BitwiseOr(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_BitwiseOr(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Decrement(uint3x4 val) { }

	public static uint3x4 op_Division(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_Division(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Division(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_Equality(uint lhs, uint3x4 rhs) { }

	public static bool3x4 op_Equality(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_Equality(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_ExclusiveOr(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_ExclusiveOr(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_ExclusiveOr(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Explicit(int3x4 v) { }

	public static uint3x4 op_Explicit(float v) { }

	public static uint3x4 op_Explicit(float3x4 v) { }

	public static uint3x4 op_Explicit(double v) { }

	public static uint3x4 op_Explicit(int v) { }

	public static uint3x4 op_Explicit(bool v) { }

	public static uint3x4 op_Explicit(bool3x4 v) { }

	public static uint3x4 op_Explicit(double3x4 v) { }

	public static bool3x4 op_GreaterThan(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_GreaterThan(uint3x4 lhs, uint rhs) { }

	public static bool3x4 op_GreaterThan(uint lhs, uint3x4 rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(uint3x4 lhs, uint rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_Implicit(uint v) { }

	public static uint3x4 op_Increment(uint3x4 val) { }

	public static bool3x4 op_Inequality(uint3x4 lhs, uint rhs) { }

	public static bool3x4 op_Inequality(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_Inequality(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_LeftShift(uint3x4 x, int n) { }

	public static bool3x4 op_LessThan(uint3x4 lhs, uint3x4 rhs) { }

	public static bool3x4 op_LessThan(uint lhs, uint3x4 rhs) { }

	public static bool3x4 op_LessThan(uint3x4 lhs, uint rhs) { }

	public static bool3x4 op_LessThanOrEqual(uint lhs, uint3x4 rhs) { }

	public static bool3x4 op_LessThanOrEqual(uint3x4 lhs, uint rhs) { }

	public static bool3x4 op_LessThanOrEqual(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_Modulus(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_Modulus(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_Modulus(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Multiply(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_Multiply(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_Multiply(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_OnesComplement(uint3x4 val) { }

	public static uint3x4 op_RightShift(uint3x4 x, int n) { }

	public static uint3x4 op_Subtraction(uint lhs, uint3x4 rhs) { }

	public static uint3x4 op_Subtraction(uint3x4 lhs, uint rhs) { }

	public static uint3x4 op_Subtraction(uint3x4 lhs, uint3x4 rhs) { }

	public static uint3x4 op_UnaryNegation(uint3x4 val) { }

	public static uint3x4 op_UnaryPlus(uint3x4 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

