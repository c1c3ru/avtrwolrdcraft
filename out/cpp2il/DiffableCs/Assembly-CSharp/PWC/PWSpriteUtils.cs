namespace PWC;

public static class PWSpriteUtils
{
	private static readonly int _PWColorID; //Field offset: 0x0
	private static readonly string _PWColorTypeMultiply; //Field offset: 0x8
	private static readonly string _PWColorTypeOverlay; //Field offset: 0x10

	private static PWSpriteUtils() { }

	public static Color GetPWSpriteColor(SpriteRenderer spriteRenderer) { }

	public static void PWCSpriteColorEnableProperKeyword(Material material, PWSpriteColorType colorType) { }

	public static void SetPWSpineColor(Material material, Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

	public static void SetPWSpriteColor(SpriteRenderer spriteRenderer, Color color, PWSpriteColorType colorType = 1, bool ensureShader = true) { }

	public static void SetPWSpriteTexture(SpriteRenderer spriteRenderer, Texture2D texture, bool ensureShader = true) { }

}

