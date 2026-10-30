namespace SimpleEasing;

public static class VectorHelper
{
	private static Vector2 _vector2; //Field offset: 0x0
	private static Vector3 _vector3; //Field offset: 0x8
	private static Quaternion _quaternion; //Field offset: 0x14
	private static Color _color; //Field offset: 0x24

	public static Color EaseColor(Func<Single, Single, Single, Single> easingFunction, Color from, Color to, float t) { }

	public static Quaternion EaseQuaternion(Func<Single, Single, Single, Single> easingFunction, Quaternion from, Quaternion to, float t) { }

	public static Vector2 EaseVector2(Func<Single, Single, Single, Single> easingFunction, Vector2 from, Vector2 to, float t) { }

	public static Vector3 EaseVector3(Func<Single, Single, Single, Single> easingFunction, Vector3 from, Vector3 to, float t) { }

}

