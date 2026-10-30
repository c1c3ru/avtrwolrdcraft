namespace TMPro;

public static class TMP_Math
{
	public const float FLOAT_MAX = 32767; //Field offset: 0x0
	public const float FLOAT_MIN = -32767; //Field offset: 0x0
	public const int INT_MAX = 2147483647; //Field offset: 0x0
	public const int INT_MIN = -2147483647; //Field offset: 0x0
	public const float FLOAT_UNSET = -32767; //Field offset: 0x0
	public const int INT_UNSET = -32767; //Field offset: 0x0
	public static Vector2 MAX_16BIT; //Field offset: 0x0
	public static Vector2 MIN_16BIT; //Field offset: 0x8

	private static TMP_Math() { }

	public static bool Approximately(float a, float b) { }

	public static int Mod(int a, int b) { }

}

