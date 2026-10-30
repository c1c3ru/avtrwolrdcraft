namespace PWC.QA.RTA;

public class RTALogger
{
	[CompilerGenerated]
	private struct <>c__DisplayClass12_0
	{
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"type", "formattedTime", "text", "details"})]
		public ValueTuple<LogType, String, String, String> log; //Field offset: 0x0

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass12_1
	{
		public string dashSeparator; //Field offset: 0x0

	}

	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"type", "formattedTime", "text", "details"})]
	private List<ValueTuple`4<LogType, String, String, String>> _logBuffers; //Field offset: 0x10
	private string _errorSummaryLogPath; //Field offset: 0x18
	private string _warningSummaryLogPath; //Field offset: 0x20
	private string _fullLogPath; //Field offset: 0x28
	private string _assertionLogsPath; //Field offset: 0x30
	private bool _isListeningToAssertionLogs; //Field offset: 0x38
	private bool _shouldSaveFullLogFile; //Field offset: 0x39

	public RTALogger(string fileName, string directory, bool isListeningToAssertionLogs, bool shouldSaveFullLogFile) { }

	[CompilerGenerated]
	internal static string <SaveLogsFromBuffer_Internal>g__GetLogText|12_1(bool addTime, ref <>c__DisplayClass12_0 unnamed_param_1, ref <>c__DisplayClass12_1 unnamed_param_2) { }

	[CompilerGenerated]
	private void <SaveLogsFromBuffer_Internal>g__SaveText|12_0(string path, string text) { }

	private void EnsurePath_Internal(string path) { }

	public string GetFullLogsPath() { }

	public string GetLastErrorLogsPath() { }

	public string GetLastWarningLogsPath() { }

	private void OnLog_Internal(string condition, string stackTrace, LogType type) { }

	private void SaveLogsFromBuffer_Internal() { }

	public void Stop() { }

}

