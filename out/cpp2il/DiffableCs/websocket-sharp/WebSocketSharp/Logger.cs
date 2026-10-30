namespace WebSocketSharp;

public class Logger
{
	private string _file; //Field offset: 0x10
	private LogLevel _level; //Field offset: 0x18
	private Action<LogData, String> _output; //Field offset: 0x20
	private object _sync; //Field offset: 0x28

	public string File
	{
		 get { } //Length: 24
		 set { } //Length: 296
	}

	public LogLevel Level
	{
		 get { } //Length: 24
		 set { } //Length: 316
	}

	public Action<LogData, String> Output
	{
		 get { } //Length: 8
		 set { } //Length: 332
	}

	public Logger() { }

	public Logger(LogLevel level) { }

	public Logger(LogLevel level, string file, Action<LogData, String> output) { }

	public void Debug(string message) { }

	private static void defaultOutput(LogData data, string path) { }

	public void Error(string message) { }

	public void Fatal(string message) { }

	public string get_File() { }

	public LogLevel get_Level() { }

	public Action<LogData, String> get_Output() { }

	public void Info(string message) { }

	private void output(string message, LogLevel level) { }

	public void set_File(string value) { }

	public void set_Level(LogLevel value) { }

	public void set_Output(Action<LogData, String> value) { }

	public void Trace(string message) { }

	public void Warn(string message) { }

	private static void writeToFile(string value, string path) { }

}

