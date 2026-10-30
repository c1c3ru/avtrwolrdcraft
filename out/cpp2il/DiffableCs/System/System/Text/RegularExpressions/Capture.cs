namespace System.Text.RegularExpressions;

public class Capture
{
	[CompilerGenerated]
	private int <Index>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <Length>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private string <Text>k__BackingField; //Field offset: 0x18

	public int Index
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public int Length
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	internal string Text
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public string Value
	{
		 get { } //Length: 36
	}

	internal Capture(string text, int index, int length) { }

	internal Capture() { }

	[CompilerGenerated]
	public int get_Index() { }

	[CompilerGenerated]
	public int get_Length() { }

	[CompilerGenerated]
	internal string get_Text() { }

	public string get_Value() { }

	internal ReadOnlySpan<Char> GetLeftSubstring() { }

	internal ReadOnlySpan<Char> GetRightSubstring() { }

	[CompilerGenerated]
	 void set_Index(int value) { }

	[CompilerGenerated]
	 void set_Length(int value) { }

	[CompilerGenerated]
	 void set_Text(string value) { }

	public virtual string ToString() { }

}

