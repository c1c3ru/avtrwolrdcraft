namespace TMPro;

public struct HighlightState
{
	public Color32 color; //Field offset: 0x0
	public TMP_Offset padding; //Field offset: 0x4

	public HighlightState(Color32 color, TMP_Offset padding) { }

	public virtual bool Equals(object obj) { }

	public bool Equals(HighlightState other) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(HighlightState lhs, HighlightState rhs) { }

	public static bool op_Inequality(HighlightState lhs, HighlightState rhs) { }

}

