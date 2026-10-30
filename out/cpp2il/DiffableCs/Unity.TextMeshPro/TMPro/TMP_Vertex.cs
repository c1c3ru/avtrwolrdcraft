namespace TMPro;

public struct TMP_Vertex
{
	private static readonly TMP_Vertex k_Zero; //Field offset: 0x0
	public Vector3 position; //Field offset: 0x0
	public Vector2 uv; //Field offset: 0xC
	public Vector2 uv2; //Field offset: 0x14
	public Vector2 uv4; //Field offset: 0x1C
	public Color32 color; //Field offset: 0x24

	public static TMP_Vertex zero
	{
		 get { } //Length: 104
	}

	private static TMP_Vertex() { }

	public static TMP_Vertex get_zero() { }

}

