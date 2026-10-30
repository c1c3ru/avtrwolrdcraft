namespace WebSocketSharp;

public class LogData
{
	private StackFrame _caller; //Field offset: 0x10
	private DateTime _date; //Field offset: 0x18
	private LogLevel _level; //Field offset: 0x20
	private string _message; //Field offset: 0x28

	public StackFrame Caller
	{
		 get { } //Length: 8
	}

	public DateTime Date
	{
		 get { } //Length: 8
	}

	public LogLevel Level
	{
		 get { } //Length: 8
	}

	public string Message
	{
		 get { } //Length: 8
	}

	internal LogData(LogLevel level, StackFrame caller, string message) { }

	public StackFrame get_Caller() { }

	public DateTime get_Date() { }

	public LogLevel get_Level() { }

	public string get_Message() { }

	public virtual string ToString() { }

}

