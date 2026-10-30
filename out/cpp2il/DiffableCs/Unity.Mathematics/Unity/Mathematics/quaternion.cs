namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public struct quaternion : IEquatable<quaternion>, IFormattable
{
	public static readonly quaternion identity; //Field offset: 0x0
	public float4 value; //Field offset: 0x0

	private static quaternion() { }

	public quaternion(float x, float y, float z, float w) { }

	public quaternion(float4 value) { }

	public quaternion(float3x3 m) { }

	public quaternion(float4x4 m) { }

	public static quaternion AxisAngle(float3 axis, float angle) { }

	public virtual bool Equals(object x) { }

	public override bool Equals(quaternion x) { }

	public static quaternion Euler(float x, float y, float z, RotationOrder order = 4) { }

	public static quaternion Euler(float3 xyz, RotationOrder order = 4) { }

	public static quaternion EulerXYZ(float3 xyz) { }

	public static quaternion EulerXYZ(float x, float y, float z) { }

	public static quaternion EulerXZY(float3 xyz) { }

	public static quaternion EulerXZY(float x, float y, float z) { }

	public static quaternion EulerYXZ(float x, float y, float z) { }

	public static quaternion EulerYXZ(float3 xyz) { }

	public static quaternion EulerYZX(float x, float y, float z) { }

	public static quaternion EulerYZX(float3 xyz) { }

	public static quaternion EulerZXY(float3 xyz) { }

	public static quaternion EulerZXY(float x, float y, float z) { }

	public static quaternion EulerZYX(float x, float y, float z) { }

	public static quaternion EulerZYX(float3 xyz) { }

	public virtual int GetHashCode() { }

	public static quaternion LookRotation(float3 forward, float3 up) { }

	public static quaternion LookRotationSafe(float3 forward, float3 up) { }

	public static quaternion op_Implicit(Quaternion q) { }

	public static quaternion op_Implicit(float4 v) { }

	public static Quaternion op_Implicit(quaternion q) { }

	public static quaternion RotateX(float angle) { }

	public static quaternion RotateY(float angle) { }

	public static quaternion RotateZ(float angle) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

