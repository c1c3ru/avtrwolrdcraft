namespace Newtonsoft.Json.Serialization;

public class DiagnosticsTraceWriter : ITraceWriter
{
	[CompilerGenerated]
	private TraceLevel <LevelFilter>k__BackingField; //Field offset: 0x10

	public override TraceLevel LevelFilter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public DiagnosticsTraceWriter() { }

	[CompilerGenerated]
	public override TraceLevel get_LevelFilter() { }

	private TraceEventType GetTraceEventType(TraceLevel level) { }

	[CompilerGenerated]
	public void set_LevelFilter(TraceLevel value) { }

	[NullableContext(1)]
	public override void Trace(TraceLevel level, string message, Exception ex) { }

}

