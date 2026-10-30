//Type is in global namespace

public class PackedPlayModeBuildLogs
{
	internal struct RuntimeBuildLog
	{
		public LogType Type; //Field offset: 0x0
		public string Message; //Field offset: 0x8

		public RuntimeBuildLog(LogType type, string message) { }

	}

	[SerializeField]
	private List<RuntimeBuildLog> m_RuntimeBuildLogs; //Field offset: 0x10

	public List<RuntimeBuildLog> RuntimeBuildLogs
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PackedPlayModeBuildLogs() { }

	public List<RuntimeBuildLog> get_RuntimeBuildLogs() { }

	public void set_RuntimeBuildLogs(List<RuntimeBuildLog> value) { }

}

