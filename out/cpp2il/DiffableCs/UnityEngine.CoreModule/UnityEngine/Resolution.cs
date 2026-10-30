namespace UnityEngine;

[RequiredByNativeCode]
public struct Resolution
{
	private int m_Width; //Field offset: 0x0
	private int m_Height; //Field offset: 0x4
	private RefreshRate m_RefreshRate; //Field offset: 0x8

	public int height
	{
		 get { } //Length: 8
	}

	public int width
	{
		 get { } //Length: 8
	}

	public int get_height() { }

	public int get_width() { }

	public virtual string ToString() { }

}

