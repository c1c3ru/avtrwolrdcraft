namespace UnityEngine;

[NativeHeader("Runtime/Export/Random/Random.bindings.h")]
public static class Random
{

	public static Vector2 insideUnitCircle
	{
		 get { } //Length: 68
	}

	public static float value
	{
		[FreeFunction]
		 get { } //Length: 40
	}

	public static Vector2 get_insideUnitCircle() { }

	[FreeFunction]
	public static float get_value() { }

	[FreeFunction]
	private static void GetRandomUnitCircle(out Vector2 output) { }

	[NativeMethod("SetSeed")]
	[StaticAccessor("GetScriptingRand()", StaticAccessorType::Dot (0))]
	public static void InitState(int seed) { }

	[FreeFunction]
	private static int RandomRangeInt(int minInclusive, int maxExclusive) { }

	[FreeFunction]
	public static float Range(float minInclusive, float maxInclusive) { }

	public static int Range(int minInclusive, int maxExclusive) { }

}

