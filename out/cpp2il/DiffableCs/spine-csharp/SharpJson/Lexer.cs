namespace SharpJson;

internal class Lexer
{
	internal enum Token
	{
		None = 0,
		Null = 1,
		True = 2,
		False = 3,
		Colon = 4,
		Comma = 5,
		String = 6,
		Number = 7,
		CurlyOpen = 8,
		CurlyClose = 9,
		SquaredOpen = 10,
		SquaredClose = 11,
	}

	[CompilerGenerated]
	private int <lineNumber>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <parseNumbersAsFloat>k__BackingField; //Field offset: 0x14
	private Char[] json; //Field offset: 0x18
	private int index; //Field offset: 0x20
	private bool success; //Field offset: 0x24
	private Char[] stringBuffer; //Field offset: 0x28

	public bool hasError
	{
		 get { } //Length: 16
	}

	public private int lineNumber
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool parseNumbersAsFloat
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Lexer(string text) { }

	public bool get_hasError() { }

	[CompilerGenerated]
	public int get_lineNumber() { }

	[CompilerGenerated]
	public bool get_parseNumbersAsFloat() { }

	private int GetLastIndexOfNumber(int index) { }

	private string GetNumberString() { }

	public Token LookAhead() { }

	public Token NextToken() { }

	private static Token NextToken(Char[] json, ref int index) { }

	public double ParseDoubleNumber() { }

	public float ParseFloatNumber() { }

	public string ParseString() { }

	public void Reset() { }

	[CompilerGenerated]
	private void set_lineNumber(int value) { }

	[CompilerGenerated]
	public void set_parseNumbersAsFloat(bool value) { }

	private void SkipWhiteSpaces() { }

}

