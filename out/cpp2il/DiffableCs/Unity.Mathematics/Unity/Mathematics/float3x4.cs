namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct float3x4 : IEquatable<float3x4>, IFormattable
{
	public static readonly float3x4 zero; //Field offset: 0x0
	public float3 c0; //Field offset: 0x0
	public float3 c1; //Field offset: 0xC
	public float3 c2; //Field offset: 0x18
	public float3 c3; //Field offset: 0x24

	public float3 Item
	{
		 get { } //Length: 12
	}

	public float3x4(float3 c0, float3 c1, float3 c2, float3 c3) { }

	public float3x4(double v) { }

	public float3x4(uint3x4 v) { }

	public float3x4(uint v) { }

	public float3x4(int3x4 v) { }

	public float3x4(double3x4 v) { }

	public float3x4(bool3x4 v) { }

	public float3x4(bool v) { }

	public float3x4(float v) { }

	public float3x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23) { }

	public float3x4(int v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(float3x4 rhs) { }

	public float3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static float3x4 op_Addition(float3x4 lhs, float rhs) { }

	public static float3x4 op_Addition(float lhs, float3x4 rhs) { }

	public static float3x4 op_Addition(float3x4 lhs, float3x4 rhs) { }

	public static float3x4 op_Decrement(float3x4 val) { }

	public static float3x4 op_Division(float3x4 lhs, float rhs) { }

	public static float3x4 op_Division(float3x4 lhs, float3x4 rhs) { }

	public static float3x4 op_Division(float lhs, float3x4 rhs) { }

	public static bool3x4 op_Equality(float3x4 lhs, float rhs) { }

	public static bool3x4 op_Equality(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_Equality(float lhs, float3x4 rhs) { }

	public static float3x4 op_Explicit(double v) { }

	public static float3x4 op_Explicit(bool v) { }

	public static float3x4 op_Explicit(bool3x4 v) { }

	public static float3x4 op_Explicit(double3x4 v) { }

	public static bool3x4 op_GreaterThan(float3x4 lhs, float rhs) { }

	public static bool3x4 op_GreaterThan(float lhs, float3x4 rhs) { }

	public static bool3x4 op_GreaterThan(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(float3x4 lhs, float rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_GreaterThanOrEqual(float lhs, float3x4 rhs) { }

	public static float3x4 op_Implicit(uint v) { }

	public static float3x4 op_Implicit(int3x4 v) { }

	public static float3x4 op_Implicit(float v) { }

	public static float3x4 op_Implicit(uint3x4 v) { }

	public static float3x4 op_Implicit(int v) { }

	public static float3x4 op_Increment(float3x4 val) { }

	public static bool3x4 op_Inequality(float3x4 lhs, float rhs) { }

	public static bool3x4 op_Inequality(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_Inequality(float lhs, float3x4 rhs) { }

	public static bool3x4 op_LessThan(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_LessThan(float lhs, float3x4 rhs) { }

	public static bool3x4 op_LessThan(float3x4 lhs, float rhs) { }

	public static bool3x4 op_LessThanOrEqual(float3x4 lhs, float3x4 rhs) { }

	public static bool3x4 op_LessThanOrEqual(float3x4 lhs, float rhs) { }

	public static bool3x4 op_LessThanOrEqual(float lhs, float3x4 rhs) { }

	public static float3x4 op_Modulus(float lhs, float3x4 rhs) { }

	public static float3x4 op_Modulus(float3x4 lhs, float rhs) { }

	public static float3x4 op_Modulus(float3x4 lhs, float3x4 rhs) { }

	public static float3x4 op_Multiply(float lhs, float3x4 rhs) { }

	public static float3x4 op_Multiply(float3x4 lhs, float rhs) { }

	public static float3x4 op_Multiply(float3x4 lhs, float3x4 rhs) { }

	public static float3x4 op_Subtraction(float lhs, float3x4 rhs) { }

	public static float3x4 op_Subtraction(float3x4 lhs, float rhs) { }

	public static float3x4 op_Subtraction(float3x4 lhs, float3x4 rhs) { }

	public static float3x4 op_UnaryNegation(float3x4 val) { }

	public static float3x4 op_UnaryPlus(float3x4 val) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

