namespace UnityEngine.UIElements;

public struct BackgroundSize : IEquatable<BackgroundSize>
{
	private BackgroundSizeType m_SizeType; //Field offset: 0x0
	private Length m_X; //Field offset: 0x4
	private Length m_Y; //Field offset: 0xC

	public BackgroundSizeType sizeType
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public Length x
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public Length y
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public BackgroundSize(Length sizeX, Length sizeY) { }

	public BackgroundSize(BackgroundSizeType sizeType) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(BackgroundSize other) { }

	public BackgroundSizeType get_sizeType() { }

	public Length get_x() { }

	public Length get_y() { }

	public virtual int GetHashCode() { }

	internal static BackgroundSize Initial() { }

	public static bool op_Equality(BackgroundSize style1, BackgroundSize style2) { }

	public static bool op_Inequality(BackgroundSize style1, BackgroundSize style2) { }

	public void set_sizeType(BackgroundSizeType value) { }

	public void set_x(Length value) { }

	public void set_y(Length value) { }

	public virtual string ToString() { }

}

