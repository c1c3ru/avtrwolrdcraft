namespace Unity.Mathematics.Geometry;

[DebuggerDisplay("{Normal}, {Distance}")]
[Il2CppEagerStaticClassConstruction]
internal struct Plane
{
	public float4 NormalAndDistance; //Field offset: 0x0

	public float Distance
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Plane Flipped
	{
		 get { } //Length: 28
	}

	public float3 Normal
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public Plane(float coefficientA, float coefficientB, float coefficientC, float coefficientD) { }

	public Plane(float3 normal, float distance) { }

	public Plane(float3 normal, float3 pointInPlane) { }

	public Plane(float3 vector1InPlane, float3 vector2InPlane, float3 pointInPlane) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckPlaneIsNormalized() { }

	public static Plane CreateFromUnitNormalAndDistance(float3 unitNormal, float distance) { }

	public static Plane CreateFromUnitNormalAndPointInPlane(float3 unitNormal, float3 pointInPlane) { }

	public float get_Distance() { }

	public Plane get_Flipped() { }

	public float3 get_Normal() { }

	public static Plane Normalize(Plane plane) { }

	public static float4 Normalize(float4 planeCoefficients) { }

	public static float4 op_Implicit(Plane plane) { }

	public float3 Projection(float3 point) { }

	public void set_Distance(float value) { }

	public void set_Normal(float3 value) { }

	public float SignedDistanceToPoint(float3 point) { }

}

