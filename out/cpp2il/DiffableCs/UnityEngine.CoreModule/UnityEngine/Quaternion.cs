namespace UnityEngine;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
[NativeHeader("Runtime/Math/MathScripting.h")]
[NativeType(Header = "Runtime/Math/Quaternion.h")]
[UsedByNativeCode]
public struct Quaternion : IEquatable<Quaternion>, IFormattable
{
	private static readonly Quaternion identityQuaternion; //Field offset: 0x0
	public const float kEpsilon = 1E-06; //Field offset: 0x0
	public float x; //Field offset: 0x0
	public float y; //Field offset: 0x4
	public float z; //Field offset: 0x8
	public float w; //Field offset: 0xC

	public Vector3 eulerAngles
	{
		 get { } //Length: 44
	}

	public static Quaternion identity
	{
		 get { } //Length: 76
	}

	private static Quaternion() { }

	public Quaternion(float x, float y, float z, float w) { }

	[FreeFunction("QuaternionScripting::AngleAxis", IsThreadSafe = True)]
	public static Quaternion AngleAxis(float angle, Vector3 axis) { }

	private static void AngleAxis_Injected(float angle, ref Vector3 axis, out Quaternion ret) { }

	public static float Dot(Quaternion a, Quaternion b) { }

	public override bool Equals(Quaternion other) { }

	public virtual bool Equals(object other) { }

	public static Quaternion Euler(Vector3 euler) { }

	public static Quaternion Euler(float x, float y, float z) { }

	[FreeFunction("FromToQuaternionSafe", IsThreadSafe = True)]
	public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection) { }

	private static void FromToRotation_Injected(ref Vector3 fromDirection, ref Vector3 toDirection, out Quaternion ret) { }

	public Vector3 get_eulerAngles() { }

	public static Quaternion get_identity() { }

	public virtual int GetHashCode() { }

	[FreeFunction("EulerToQuaternion", IsThreadSafe = True)]
	private static Quaternion Internal_FromEulerRad(Vector3 euler) { }

	private static void Internal_FromEulerRad_Injected(ref Vector3 euler, out Quaternion ret) { }

	private static Vector3 Internal_MakePositive(Vector3 euler) { }

	[FreeFunction("QuaternionScripting::ToEuler", IsThreadSafe = True)]
	private static Vector3 Internal_ToEulerRad(Quaternion rotation) { }

	private static void Internal_ToEulerRad_Injected(ref Quaternion rotation, out Vector3 ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Quaternion Inverse(Quaternion rotation) { }

	private static void Inverse_Injected(ref Quaternion rotation, out Quaternion ret) { }

	private static bool IsEqualUsingDot(float dot) { }

	[FreeFunction("QuaternionScripting::Lerp", IsThreadSafe = True)]
	public static Quaternion Lerp(Quaternion a, Quaternion b, float t) { }

	private static void Lerp_Injected(ref Quaternion a, ref Quaternion b, float t, out Quaternion ret) { }

	[FreeFunction("QuaternionScripting::LookRotation", IsThreadSafe = True)]
	public static Quaternion LookRotation(Vector3 forward, Vector3 upwards) { }

	private static void LookRotation_Injected(ref Vector3 forward, ref Vector3 upwards, out Quaternion ret) { }

	public static bool op_Equality(Quaternion lhs, Quaternion rhs) { }

	public static bool op_Inequality(Quaternion lhs, Quaternion rhs) { }

	public static Vector3 op_Multiply(Quaternion rotation, Vector3 point) { }

	public static Quaternion op_Multiply(Quaternion lhs, Quaternion rhs) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

