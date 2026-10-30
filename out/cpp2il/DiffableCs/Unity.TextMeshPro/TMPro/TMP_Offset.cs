namespace TMPro;

public struct TMP_Offset
{
	private static readonly TMP_Offset k_ZeroOffset; //Field offset: 0x0
	private float m_Left; //Field offset: 0x0
	private float m_Right; //Field offset: 0x4
	private float m_Top; //Field offset: 0x8
	private float m_Bottom; //Field offset: 0xC

	public float bottom
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float horizontal
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float left
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float right
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float top
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float vertical
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public static TMP_Offset zero
	{
		 get { } //Length: 92
	}

	private static TMP_Offset() { }

	public TMP_Offset(float horizontal, float vertical) { }

	public TMP_Offset(float left, float right, float top, float bottom) { }

	public virtual bool Equals(object obj) { }

	public bool Equals(TMP_Offset other) { }

	public float get_bottom() { }

	public float get_horizontal() { }

	public float get_left() { }

	public float get_right() { }

	public float get_top() { }

	public float get_vertical() { }

	public static TMP_Offset get_zero() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(TMP_Offset lhs, TMP_Offset rhs) { }

	public static bool op_Inequality(TMP_Offset lhs, TMP_Offset rhs) { }

	public static TMP_Offset op_Multiply(TMP_Offset a, float b) { }

	public void set_bottom(float value) { }

	public void set_horizontal(float value) { }

	public void set_left(float value) { }

	public void set_right(float value) { }

	public void set_top(float value) { }

	public void set_vertical(float value) { }

}

