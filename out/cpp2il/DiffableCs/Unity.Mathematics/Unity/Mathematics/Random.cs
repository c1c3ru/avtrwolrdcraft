namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public struct Random
{
	public uint state; //Field offset: 0x0

	public Random(uint seed) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckIndexForHash(uint index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckInitState() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNextIntMax(int max) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNextIntMinMax(int min, int max) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckNextUIntMinMax(uint min, uint max) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckState() { }

	public static Random CreateFromIndex(uint index) { }

	public void InitState(uint seed = 1851936439) { }

	public bool NextBool() { }

	public bool2 NextBool2() { }

	public bool3 NextBool3() { }

	public bool4 NextBool4() { }

	public double NextDouble() { }

	public double NextDouble(double max) { }

	public double NextDouble(double min, double max) { }

	public double2 NextDouble2(double2 max) { }

	public double2 NextDouble2() { }

	public double2 NextDouble2(double2 min, double2 max) { }

	public double2 NextDouble2Direction() { }

	public double3 NextDouble3(double3 max) { }

	public double3 NextDouble3() { }

	public double3 NextDouble3(double3 min, double3 max) { }

	public double3 NextDouble3Direction() { }

	public double4 NextDouble4(double4 max) { }

	public double4 NextDouble4(double4 min, double4 max) { }

	public double4 NextDouble4() { }

	public float NextFloat(float min, float max) { }

	public float NextFloat() { }

	public float NextFloat(float max) { }

	public float2 NextFloat2() { }

	public float2 NextFloat2(float2 min, float2 max) { }

	public float2 NextFloat2(float2 max) { }

	public float2 NextFloat2Direction() { }

	public float3 NextFloat3(float3 max) { }

	public float3 NextFloat3(float3 min, float3 max) { }

	public float3 NextFloat3() { }

	public float3 NextFloat3Direction() { }

	public float4 NextFloat4(float4 max) { }

	public float4 NextFloat4(float4 min, float4 max) { }

	public float4 NextFloat4() { }

	public int NextInt(int min, int max) { }

	public int NextInt(int max) { }

	public int NextInt() { }

	public int2 NextInt2(int2 min, int2 max) { }

	public int2 NextInt2() { }

	public int2 NextInt2(int2 max) { }

	public int3 NextInt3(int3 min, int3 max) { }

	public int3 NextInt3(int3 max) { }

	public int3 NextInt3() { }

	public int4 NextInt4(int4 min, int4 max) { }

	public int4 NextInt4(int4 max) { }

	public int4 NextInt4() { }

	public quaternion NextQuaternionRotation() { }

	private uint NextState() { }

	public uint NextUInt() { }

	public uint NextUInt(uint max) { }

	public uint NextUInt(uint min, uint max) { }

	public uint2 NextUInt2() { }

	public uint2 NextUInt2(uint2 max) { }

	public uint2 NextUInt2(uint2 min, uint2 max) { }

	public uint3 NextUInt3() { }

	public uint3 NextUInt3(uint3 max) { }

	public uint3 NextUInt3(uint3 min, uint3 max) { }

	public uint4 NextUInt4() { }

	public uint4 NextUInt4(uint4 max) { }

	public uint4 NextUInt4(uint4 min, uint4 max) { }

	internal static uint WangHash(uint n) { }

}

