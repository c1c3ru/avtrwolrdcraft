namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct uint4x4 : IEquatable<uint4x4>, IFormattable
{
	public static readonly uint4x4 identity; //Field offset: 0x0
	public static readonly uint4x4 zero; //Field offset: 0x40
	public uint4 c0; //Field offset: 0x0
	public uint4 c1; //Field offset: 0x10
	public uint4 c2; //Field offset: 0x20
	public uint4 c3; //Field offset: 0x30

	public uint4 Item
	{
		 get { } //Length: 8
	}

	private static uint4x4() { }

	public uint4x4(double4x4 v) { }

	public uint4x4(double v) { }

	public uint4x4(float4x4 v) { }

	public uint4x4(float v) { }

	public uint4x4(int4x4 v) { }

	public uint4x4(uint4 c0, uint4 c1, uint4 c2, uint4 c3) { }

	public uint4x4(bool4x4 v) { }

	public uint4x4(bool v) { }

	public uint4x4(uint v) { }

	public uint4x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13, uint m20, uint m21, uint m22, uint m23, uint m30, uint m31, uint m32, uint m33) { }

	public uint4x4(int v) { }

	public override bool Equals(uint4x4 rhs) { }

	public virtual bool Equals(object o) { }

	public uint4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static uint4x4 op_Addition(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Addition(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_Addition(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_BitwiseAnd(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_BitwiseAnd(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_BitwiseAnd(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_BitwiseOr(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_BitwiseOr(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_BitwiseOr(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_Decrement(uint4x4 val) { }

	public static uint4x4 op_Division(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Division(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_Division(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_Equality(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_Equality(uint4x4 lhs, uint4x4 rhs) { }

	public static bool4x4 op_Equality(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_ExclusiveOr(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_ExclusiveOr(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_ExclusiveOr(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_Explicit(float4x4 v) { }

	public static uint4x4 op_Explicit(double4x4 v) { }

	public static uint4x4 op_Explicit(float v) { }

	public static uint4x4 op_Explicit(int4x4 v) { }

	public static uint4x4 op_Explicit(int v) { }

	public static uint4x4 op_Explicit(bool4x4 v) { }

	public static uint4x4 op_Explicit(bool v) { }

	public static uint4x4 op_Explicit(double v) { }

	public static bool4x4 op_GreaterThan(uint lhs, uint4x4 rhs) { }

	public static bool4x4 op_GreaterThan(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_GreaterThan(uint4x4 lhs, uint4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(uint4x4 lhs, uint4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Implicit(uint v) { }

	public static uint4x4 op_Increment(uint4x4 val) { }

	public static bool4x4 op_Inequality(uint lhs, uint4x4 rhs) { }

	public static bool4x4 op_Inequality(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_Inequality(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_LeftShift(uint4x4 x, int n) { }

	public static bool4x4 op_LessThan(uint4x4 lhs, uint4x4 rhs) { }

	public static bool4x4 op_LessThan(uint lhs, uint4x4 rhs) { }

	public static bool4x4 op_LessThan(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_LessThanOrEqual(uint4x4 lhs, uint rhs) { }

	public static bool4x4 op_LessThanOrEqual(uint lhs, uint4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_Modulus(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_Modulus(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Modulus(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_Multiply(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Multiply(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_Multiply(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_OnesComplement(uint4x4 val) { }

	public static uint4x4 op_RightShift(uint4x4 x, int n) { }

	public static uint4x4 op_Subtraction(uint lhs, uint4x4 rhs) { }

	public static uint4x4 op_Subtraction(uint4x4 lhs, uint rhs) { }

	public static uint4x4 op_Subtraction(uint4x4 lhs, uint4x4 rhs) { }

	public static uint4x4 op_UnaryNegation(uint4x4 val) { }

	public static uint4x4 op_UnaryPlus(uint4x4 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

