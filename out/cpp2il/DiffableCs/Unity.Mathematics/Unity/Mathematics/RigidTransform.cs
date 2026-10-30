namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public struct RigidTransform
{
	public static readonly RigidTransform identity; //Field offset: 0x0
	public quaternion rot; //Field offset: 0x0
	public float3 pos; //Field offset: 0x10

	private static RigidTransform() { }

	public RigidTransform(float4x4 transform) { }

	public RigidTransform(quaternion rotation, float3 translation) { }

	public RigidTransform(float3x3 rotation, float3 translation) { }

	public static RigidTransform AxisAngle(float3 axis, float angle) { }

	public virtual bool Equals(object x) { }

	public bool Equals(RigidTransform x) { }

	public static RigidTransform Euler(float x, float y, float z, RotationOrder order = 4) { }

	public static RigidTransform Euler(float3 xyz, RotationOrder order = 4) { }

	public static RigidTransform EulerXYZ(float3 xyz) { }

	public static RigidTransform EulerXYZ(float x, float y, float z) { }

	public static RigidTransform EulerXZY(float3 xyz) { }

	public static RigidTransform EulerXZY(float x, float y, float z) { }

	public static RigidTransform EulerYXZ(float3 xyz) { }

	public static RigidTransform EulerYXZ(float x, float y, float z) { }

	public static RigidTransform EulerYZX(float x, float y, float z) { }

	public static RigidTransform EulerYZX(float3 xyz) { }

	public static RigidTransform EulerZXY(float3 xyz) { }

	public static RigidTransform EulerZXY(float x, float y, float z) { }

	public static RigidTransform EulerZYX(float3 xyz) { }

	public static RigidTransform EulerZYX(float x, float y, float z) { }

	public virtual int GetHashCode() { }

	public static RigidTransform RotateX(float angle) { }

	public static RigidTransform RotateY(float angle) { }

	public static RigidTransform RotateZ(float angle) { }

	public string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

	public static RigidTransform Translate(float3 vector) { }

}

