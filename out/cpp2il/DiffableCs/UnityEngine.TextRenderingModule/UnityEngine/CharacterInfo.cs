namespace UnityEngine;

[UsedByNativeCode]
public struct CharacterInfo
{
	public int index; //Field offset: 0x0
	[Obsolete("CharacterInfo.uv is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead.")]
	public Rect uv; //Field offset: 0x4
	[Obsolete("CharacterInfo.vert is deprecated. Use minX, maxX, minY, maxY instead.")]
	public Rect vert; //Field offset: 0x14
	[NativeName("advance")]
	[Obsolete("CharacterInfo.width is deprecated. Use advance instead.")]
	public float width; //Field offset: 0x24
	public int size; //Field offset: 0x28
	public FontStyle style; //Field offset: 0x2C
	[Obsolete("CharacterInfo.flipped is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead, which will be correct regardless of orientation.")]
	public bool flipped; //Field offset: 0x30

	public int advance
	{
		 get { } //Length: 184
	}

	public int get_advance() { }

}

