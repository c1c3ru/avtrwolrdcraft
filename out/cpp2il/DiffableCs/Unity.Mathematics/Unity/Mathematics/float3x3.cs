namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct float3x3 : IEquatable<float3x3>, IFormattable
{
	public static readonly float3x3 identity; //Field offset: 0x0
	public static readonly float3x3 zero; //Field offset: 0x24
	public float3 c0; //Field offset: 0x0
	public float3 c1; //Field offset: 0xC
	public float3 c2; //Field offset: 0x18

	public float3 Item
	{
		 get { } //Length: 12
	}

	private static float3x3() { }

	public float3x3(quaternion q) { }

	public float3x3(float4x4 f4x4) { }

	public float3x3(double3x3 v) { }

	public float3x3(double v) { }

	public float3x3(uint3x3 v) { }

	public float3x3(uint v) { }

	public float3x3(float3 c0, float3 c1, float3 c2) { }

	public float3x3(int v) { }

	public float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22) { }

	public float3x3(float v) { }

	public float3x3(int3x3 v) { }

	public float3x3(bool v) { }

	public float3x3(bool3x3 v) { }

	public static float3x3 AxisAngle(float3 axis, float angle) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(float3x3 rhs) { }

	public static float3x3 Euler(float x, float y, float z, RotationOrder order = 4) { }

	public static float3x3 Euler(float3 xyz, RotationOrder order = 4) { }

	public static float3x3 EulerXYZ(float3 xyz) { }

	public static float3x3 EulerXYZ(float x, float y, float z) { }

	public static float3x3 EulerXZY(float x, float y, float z) { }

	public static float3x3 EulerXZY(float3 xyz) { }

	public static float3x3 EulerYXZ(float x, float y, float z) { }

	public static float3x3 EulerYXZ(float3 xyz) { }

	public static float3x3 EulerYZX(float x, float y, float z) { }

	public static float3x3 EulerYZX(float3 xyz) { }

	public static float3x3 EulerZXY(float3 xyz) { }

	public static float3x3 EulerZXY(float x, float y, float z) { }

	public static float3x3 EulerZYX(float3 xyz) { }

	public static float3x3 EulerZYX(float x, float y, float z) { }

	public float3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static float3x3 LookRotation(float3 forward, float3 up) { }

	public static float3x3 LookRotationSafe(float3 forward, float3 up) { }

	public static float3x3 op_Addition(float lhs, float3x3 rhs) { }

	public static float3x3 op_Addition(float3x3 lhs, float rhs) { }

	public static float3x3 op_Addition(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Decrement(float3x3 val) { }

	public static float3x3 op_Division(float3x3 lhs, float rhs) { }

	public static float3x3 op_Division(float lhs, float3x3 rhs) { }

	public static float3x3 op_Division(float3x3 lhs, float3x3 rhs) { }

	public static bool3x3 op_Equality(float lhs, float3x3 rhs) { }

	public static bool3x3 op_Equality(float3x3 lhs, float rhs) { }

	public static bool3x3 op_Equality(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Explicit(bool3x3 v) { }

	public static float3x3 op_Explicit(double v) { }

	public static float3x3 op_Explicit(bool v) { }

	public static float3x3 op_Explicit(double3x3 v) { }

	public static float3x3 op_Explicit(float4x4 f4x4) { }

	public static bool3x3 op_GreaterThan(float3x3 lhs, float rhs) { }

	public static bool3x3 op_GreaterThan(float lhs, float3x3 rhs) { }

	public static bool3x3 op_GreaterThan(float3x3 lhs, float3x3 rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(float lhs, float3x3 rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(float3x3 lhs, float rhs) { }

	public static bool3x3 op_GreaterThanOrEqual(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Implicit(int3x3 v) { }

	public static float3x3 op_Implicit(int v) { }

	public static float3x3 op_Implicit(float v) { }

	public static float3x3 op_Implicit(uint v) { }

	public static float3x3 op_Implicit(uint3x3 v) { }

	public static float3x3 op_Increment(float3x3 val) { }

	public static bool3x3 op_Inequality(float lhs, float3x3 rhs) { }

	public static bool3x3 op_Inequality(float3x3 lhs, float rhs) { }

	public static bool3x3 op_Inequality(float3x3 lhs, float3x3 rhs) { }

	public static bool3x3 op_LessThan(float lhs, float3x3 rhs) { }

	public static bool3x3 op_LessThan(float3x3 lhs, float rhs) { }

	public static bool3x3 op_LessThan(float3x3 lhs, float3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(float3x3 lhs, float3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(float lhs, float3x3 rhs) { }

	public static bool3x3 op_LessThanOrEqual(float3x3 lhs, float rhs) { }

	public static float3x3 op_Modulus(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Modulus(float3x3 lhs, float rhs) { }

	public static float3x3 op_Modulus(float lhs, float3x3 rhs) { }

	public static float3x3 op_Multiply(float lhs, float3x3 rhs) { }

	public static float3x3 op_Multiply(float3x3 lhs, float rhs) { }

	public static float3x3 op_Multiply(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Subtraction(float3x3 lhs, float rhs) { }

	public static float3x3 op_Subtraction(float3x3 lhs, float3x3 rhs) { }

	public static float3x3 op_Subtraction(float lhs, float3x3 rhs) { }

	public static float3x3 op_UnaryNegation(float3x3 val) { }

	public static float3x3 op_UnaryPlus(float3x3 val) { }

	public static float3x3 RotateX(float angle) { }

	public static float3x3 RotateY(float angle) { }

	public static float3x3 RotateZ(float angle) { }

	public static float3x3 Scale(float s) { }

	public static float3x3 Scale(float x, float y, float z) { }

	public static float3x3 Scale(float3 v) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

