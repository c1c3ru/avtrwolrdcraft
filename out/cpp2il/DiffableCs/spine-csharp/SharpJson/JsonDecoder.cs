namespace SharpJson;

public class JsonDecoder
{
	[CompilerGenerated]
	private string <errorMessage>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <parseNumbersAsFloat>k__BackingField; //Field offset: 0x18
	private Lexer lexer; //Field offset: 0x20

	public private string errorMessage
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

	public JsonDecoder() { }

	public object Decode(string text) { }

	public static object DecodeText(string text) { }

	private T EvalLexer(T value) { }

	[CompilerGenerated]
	public string get_errorMessage() { }

	[CompilerGenerated]
	public bool get_parseNumbersAsFloat() { }

	private IList<Object> ParseArray() { }

	private IDictionary<String, Object> ParseObject() { }

	private object ParseValue() { }

	[CompilerGenerated]
	private void set_errorMessage(string value) { }

	[CompilerGenerated]
	public void set_parseNumbersAsFloat(bool value) { }

	private void TriggerError(string message) { }

}

