namespace TMPro;

public struct Extents
{
	internal static Extents zero; //Field offset: 0x0
	internal static Extents uninitialized; //Field offset: 0x10
	public Vector2 min; //Field offset: 0x0
	public Vector2 max; //Field offset: 0x8

	private static Extents() { }

	public Extents(Vector2 min, Vector2 max) { }

	public virtual string ToString() { }

}

