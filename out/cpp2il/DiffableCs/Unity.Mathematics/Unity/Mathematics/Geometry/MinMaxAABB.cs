namespace Unity.Mathematics.Geometry;

[Il2CppEagerStaticClassConstruction]
internal struct MinMaxAABB : IEquatable<MinMaxAABB>
{
	public float3 Min; //Field offset: 0x0
	public float3 Max; //Field offset: 0xC

	public float3 Center
	{
		 get { } //Length: 48
	}

	public float3 Extents
	{
		 get { } //Length: 32
	}

	public float3 HalfExtents
	{
		 get { } //Length: 48
	}

	public bool IsValid
	{
		 get { } //Length: 64
	}

	public float SurfaceArea
	{
		 get { } //Length: 52
	}

	public MinMaxAABB(float3 min, float3 max) { }

	public bool Contains(float3 point) { }

	public bool Contains(MinMaxAABB aabb) { }

	public static MinMaxAABB CreateFromCenterAndExtents(float3 center, float3 extents) { }

	public static MinMaxAABB CreateFromCenterAndHalfExtents(float3 center, float3 halfExtents) { }

	public void Encapsulate(MinMaxAABB aabb) { }

	public void Encapsulate(float3 point) { }

	public override bool Equals(MinMaxAABB other) { }

	public void Expand(float signedDistance) { }

	public float3 get_Center() { }

	public float3 get_Extents() { }

	public float3 get_HalfExtents() { }

	public bool get_IsValid() { }

	public float get_SurfaceArea() { }

	public bool Overlaps(MinMaxAABB aabb) { }

	public virtual string ToString() { }

}

