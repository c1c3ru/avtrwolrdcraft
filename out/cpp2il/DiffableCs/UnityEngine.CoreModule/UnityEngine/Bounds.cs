namespace UnityEngine;

[NativeClass("AABB")]
[NativeHeader("Runtime/Geometry/Intersection.h")]
[NativeHeader("Runtime/Geometry/AABB.h")]
[NativeHeader("Runtime/Geometry/Ray.h")]
[NativeHeader("Runtime/Math/MathScripting.h")]
[NativeType(Header = "Runtime/Geometry/AABB.h")]
[RequiredByNativeCode(Optional = True, GenerateProxy = True)]
public struct Bounds : IEquatable<Bounds>, IFormattable
{
	private Vector3 m_Center; //Field offset: 0x0
	[NativeName("m_Extent")]
	private Vector3 m_Extents; //Field offset: 0xC

	public Vector3 center
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public Vector3 extents
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public Vector3 max
	{
		 get { } //Length: 32
		 set { } //Length: 80
	}

	public Vector3 min
	{
		 get { } //Length: 32
		 set { } //Length: 80
	}

	public Vector3 size
	{
		 get { } //Length: 24
		 set { } //Length: 28
	}

	public Bounds(Vector3 center, Vector3 size) { }

	[NativeMethod("IsInside", IsThreadSafe = True)]
	public bool Contains(Vector3 point) { }

	private static bool Contains_Injected(ref Bounds _unity_self, ref Vector3 point) { }

	public void Encapsulate(Bounds bounds) { }

	public void Encapsulate(Vector3 point) { }

	public override bool Equals(Bounds other) { }

	public virtual bool Equals(object other) { }

	public void Expand(Vector3 amount) { }

	public Vector3 get_center() { }

	public Vector3 get_extents() { }

	public Vector3 get_max() { }

	public Vector3 get_min() { }

	public Vector3 get_size() { }

	public virtual int GetHashCode() { }

	public bool Intersects(Bounds bounds) { }

	public static bool op_Equality(Bounds lhs, Bounds rhs) { }

	public static bool op_Inequality(Bounds lhs, Bounds rhs) { }

	public void set_center(Vector3 value) { }

	public void set_extents(Vector3 value) { }

	public void set_max(Vector3 value) { }

	public void set_min(Vector3 value) { }

	public void set_size(Vector3 value) { }

	public void SetMinMax(Vector3 min, Vector3 max) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

