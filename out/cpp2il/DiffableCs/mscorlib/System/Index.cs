namespace System;

[IsReadOnly]
public struct Index : IEquatable<Index>
{
	private readonly int _value; //Field offset: 0x0

	public static Index End
	{
		 get { } //Length: 8
	}

	public bool IsFromEnd
	{
		 get { } //Length: 12
	}

	public static Index Start
	{
		 get { } //Length: 8
	}

	public int Value
	{
		 get { } //Length: 12
	}

	private Index(int value) { }

	public virtual bool Equals(object value) { }

	public override bool Equals(Index other) { }

	public static Index FromStart(int value) { }

	public static Index get_End() { }

	public bool get_IsFromEnd() { }

	public static Index get_Start() { }

	public int get_Value() { }

	public virtual int GetHashCode() { }

	public static Index op_Implicit(int value) { }

	public virtual string ToString() { }

	private string ToStringFromEnd() { }

}

