namespace TMPro;

[ExcludeFromPreset]
public class TMP_ColorGradient : ScriptableObject
{
	private const ColorMode k_DefaultColorMode = 3; //Field offset: 0x0
	private static readonly Color k_DefaultColor; //Field offset: 0x0
	public ColorMode colorMode; //Field offset: 0x18
	public Color topLeft; //Field offset: 0x1C
	public Color topRight; //Field offset: 0x2C
	public Color bottomLeft; //Field offset: 0x3C
	public Color bottomRight; //Field offset: 0x4C

	private static TMP_ColorGradient() { }

	public TMP_ColorGradient() { }

	public TMP_ColorGradient(Color color) { }

	public TMP_ColorGradient(Color color0, Color color1, Color color2, Color color3) { }

}

