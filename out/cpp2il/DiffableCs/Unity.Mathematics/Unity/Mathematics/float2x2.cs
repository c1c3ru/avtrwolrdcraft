namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct float2x2 : IEquatable<float2x2>, IFormattable
{
	public static readonly float2x2 identity; //Field offset: 0x0
	public static readonly float2x2 zero; //Field offset: 0x10
	public float2 c0; //Field offset: 0x0
	public float2 c1; //Field offset: 0x8

	public float2 Item
	{
		 get { } //Length: 8
	}

	private static float2x2() { }

	public float2x2(double2x2 v) { }

	public float2x2(double v) { }

	public float2x2(uint2x2 v) { }

	public float2x2(uint v) { }

	public float2x2(int2x2 v) { }

	public float2x2(float2 c0, float2 c1) { }

	public float2x2(bool2x2 v) { }

	public float2x2(bool v) { }

	public float2x2(float v) { }

	public float2x2(float m00, float m01, float m10, float m11) { }

	public float2x2(int v) { }

	public override bool Equals(float2x2 rhs) { }

	public virtual bool Equals(object o) { }

	public float2 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static float2x2 op_Addition(float2x2 lhs, float rhs) { }

	public static float2x2 op_Addition(float2x2 lhs, float2x2 rhs) { }

	public static float2x2 op_Addition(float lhs, float2x2 rhs) { }

	public static float2x2 op_Decrement(float2x2 val) { }

	public static float2x2 op_Division(float lhs, float2x2 rhs) { }

	public static float2x2 op_Division(float2x2 lhs, float rhs) { }

	public static float2x2 op_Division(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_Equality(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_Equality(float2x2 lhs, float rhs) { }

	public static bool2x2 op_Equality(float lhs, float2x2 rhs) { }

	public static float2x2 op_Explicit(double v) { }

	public static float2x2 op_Explicit(double2x2 v) { }

	public static float2x2 op_Explicit(bool v) { }

	public static float2x2 op_Explicit(bool2x2 v) { }

	public static bool2x2 op_GreaterThan(float2x2 lhs, float rhs) { }

	public static bool2x2 op_GreaterThan(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_GreaterThan(float lhs, float2x2 rhs) { }

	public static bool2x2 op_GreaterThanOrEqual(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_GreaterThanOrEqual(float2x2 lhs, float rhs) { }

	public static bool2x2 op_GreaterThanOrEqual(float lhs, float2x2 rhs) { }

	public static float2x2 op_Implicit(uint2x2 v) { }

	public static float2x2 op_Implicit(uint v) { }

	public static float2x2 op_Implicit(int2x2 v) { }

	public static float2x2 op_Implicit(int v) { }

	public static float2x2 op_Implicit(float v) { }

	public static float2x2 op_Increment(float2x2 val) { }

	public static bool2x2 op_Inequality(float lhs, float2x2 rhs) { }

	public static bool2x2 op_Inequality(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_Inequality(float2x2 lhs, float rhs) { }

	public static bool2x2 op_LessThan(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_LessThan(float lhs, float2x2 rhs) { }

	public static bool2x2 op_LessThan(float2x2 lhs, float rhs) { }

	public static bool2x2 op_LessThanOrEqual(float2x2 lhs, float rhs) { }

	public static bool2x2 op_LessThanOrEqual(float2x2 lhs, float2x2 rhs) { }

	public static bool2x2 op_LessThanOrEqual(float lhs, float2x2 rhs) { }

	public static float2x2 op_Modulus(float2x2 lhs, float2x2 rhs) { }

	public static float2x2 op_Modulus(float2x2 lhs, float rhs) { }

	public static float2x2 op_Modulus(float lhs, float2x2 rhs) { }

	public static float2x2 op_Multiply(float lhs, float2x2 rhs) { }

	public static float2x2 op_Multiply(float2x2 lhs, float rhs) { }

	public static float2x2 op_Multiply(float2x2 lhs, float2x2 rhs) { }

	public static float2x2 op_Subtraction(float lhs, float2x2 rhs) { }

	public static float2x2 op_Subtraction(float2x2 lhs, float2x2 rhs) { }

	public static float2x2 op_Subtraction(float2x2 lhs, float rhs) { }

	public static float2x2 op_UnaryNegation(float2x2 val) { }

	public static float2x2 op_UnaryPlus(float2x2 val) { }

	public static float2x2 Rotate(float angle) { }

	public static float2x2 Scale(float2 v) { }

	public static float2x2 Scale(float s) { }

	public static float2x2 Scale(float x, float y) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

