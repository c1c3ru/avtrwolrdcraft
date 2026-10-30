namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct float4x4 : IEquatable<float4x4>, IFormattable
{
	public static readonly float4x4 identity; //Field offset: 0x0
	public static readonly float4x4 zero; //Field offset: 0x40
	public float4 c0; //Field offset: 0x0
	public float4 c1; //Field offset: 0x10
	public float4 c2; //Field offset: 0x20
	public float4 c3; //Field offset: 0x30

	public float4 Item
	{
		 get { } //Length: 8
	}

	private static float4x4() { }

	public float4x4(RigidTransform transform) { }

	public float4x4(quaternion rotation, float3 translation) { }

	public float4x4(float3x3 rotation, float3 translation) { }

	public float4x4(double4x4 v) { }

	public float4x4(double v) { }

	public float4x4(uint4x4 v) { }

	public float4x4(float4 c0, float4 c1, float4 c2, float4 c3) { }

	public float4x4(int4x4 v) { }

	public float4x4(bool v) { }

	public float4x4(uint v) { }

	public float4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33) { }

	public float4x4(float v) { }

	public float4x4(int v) { }

	public float4x4(bool4x4 v) { }

	public static float4x4 AxisAngle(float3 axis, float angle) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(float4x4 rhs) { }

	public static float4x4 Euler(float3 xyz, RotationOrder order = 4) { }

	public static float4x4 Euler(float x, float y, float z, RotationOrder order = 4) { }

	public static float4x4 EulerXYZ(float x, float y, float z) { }

	public static float4x4 EulerXYZ(float3 xyz) { }

	public static float4x4 EulerXZY(float x, float y, float z) { }

	public static float4x4 EulerXZY(float3 xyz) { }

	public static float4x4 EulerYXZ(float x, float y, float z) { }

	public static float4x4 EulerYXZ(float3 xyz) { }

	public static float4x4 EulerYZX(float x, float y, float z) { }

	public static float4x4 EulerYZX(float3 xyz) { }

	public static float4x4 EulerZXY(float3 xyz) { }

	public static float4x4 EulerZXY(float x, float y, float z) { }

	public static float4x4 EulerZYX(float3 xyz) { }

	public static float4x4 EulerZYX(float x, float y, float z) { }

	public float4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static float4x4 LookAt(float3 eye, float3 target, float3 up) { }

	public static float4x4 op_Addition(float lhs, float4x4 rhs) { }

	public static float4x4 op_Addition(float4x4 lhs, float rhs) { }

	public static float4x4 op_Addition(float4x4 lhs, float4x4 rhs) { }

	public static float4x4 op_Decrement(float4x4 val) { }

	public static float4x4 op_Division(float4x4 lhs, float rhs) { }

	public static float4x4 op_Division(float4x4 lhs, float4x4 rhs) { }

	public static float4x4 op_Division(float lhs, float4x4 rhs) { }

	public static bool4x4 op_Equality(float lhs, float4x4 rhs) { }

	public static bool4x4 op_Equality(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_Equality(float4x4 lhs, float rhs) { }

	public static float4x4 op_Explicit(bool v) { }

	public static float4x4 op_Explicit(bool4x4 v) { }

	public static float4x4 op_Explicit(double v) { }

	public static float4x4 op_Explicit(double4x4 v) { }

	public static bool4x4 op_GreaterThan(float lhs, float4x4 rhs) { }

	public static bool4x4 op_GreaterThan(float4x4 lhs, float rhs) { }

	public static bool4x4 op_GreaterThan(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(float lhs, float4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_GreaterThanOrEqual(float4x4 lhs, float rhs) { }

	public static float4x4 op_Implicit(Matrix4x4 m) { }

	public static float4x4 op_Implicit(uint v) { }

	public static float4x4 op_Implicit(float v) { }

	public static float4x4 op_Implicit(uint4x4 v) { }

	public static Matrix4x4 op_Implicit(float4x4 m) { }

	public static float4x4 op_Implicit(int4x4 v) { }

	public static float4x4 op_Implicit(int v) { }

	public static float4x4 op_Increment(float4x4 val) { }

	public static bool4x4 op_Inequality(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_Inequality(float4x4 lhs, float rhs) { }

	public static bool4x4 op_Inequality(float lhs, float4x4 rhs) { }

	public static bool4x4 op_LessThan(float lhs, float4x4 rhs) { }

	public static bool4x4 op_LessThan(float4x4 lhs, float rhs) { }

	public static bool4x4 op_LessThan(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(float4x4 lhs, float rhs) { }

	public static bool4x4 op_LessThanOrEqual(float4x4 lhs, float4x4 rhs) { }

	public static bool4x4 op_LessThanOrEqual(float lhs, float4x4 rhs) { }

	public static float4x4 op_Modulus(float4x4 lhs, float rhs) { }

	public static float4x4 op_Modulus(float lhs, float4x4 rhs) { }

	public static float4x4 op_Modulus(float4x4 lhs, float4x4 rhs) { }

	public static float4x4 op_Multiply(float4x4 lhs, float4x4 rhs) { }

	public static float4x4 op_Multiply(float4x4 lhs, float rhs) { }

	public static float4x4 op_Multiply(float lhs, float4x4 rhs) { }

	public static float4x4 op_Subtraction(float4x4 lhs, float rhs) { }

	public static float4x4 op_Subtraction(float4x4 lhs, float4x4 rhs) { }

	public static float4x4 op_Subtraction(float lhs, float4x4 rhs) { }

	public static float4x4 op_UnaryNegation(float4x4 val) { }

	public static float4x4 op_UnaryPlus(float4x4 val) { }

	public static float4x4 Ortho(float width, float height, float near, float far) { }

	public static float4x4 OrthoOffCenter(float left, float right, float bottom, float top, float near, float far) { }

	public static float4x4 PerspectiveFov(float verticalFov, float aspect, float near, float far) { }

	public static float4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far) { }

	public static float4x4 RotateX(float angle) { }

	public static float4x4 RotateY(float angle) { }

	public static float4x4 RotateZ(float angle) { }

	public static float4x4 Scale(float s) { }

	public static float4x4 Scale(float3 scales) { }

	public static float4x4 Scale(float x, float y, float z) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

	public static float4x4 Translate(float3 vector) { }

	public static float4x4 TRS(float3 translation, quaternion rotation, float3 scale) { }

}

