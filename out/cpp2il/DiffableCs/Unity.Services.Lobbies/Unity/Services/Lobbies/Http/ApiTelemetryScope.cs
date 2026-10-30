namespace Unity.Services.Lobbies.Http;

internal sealed class ApiTelemetryScope : IDisposable
{
	private const string k_RequestLatencyMetric = "http_request_ms"; //Field offset: 0x0
	private const string k_ApiTag = "api"; //Field offset: 0x0
	private readonly IMetrics m_Metrics; //Field offset: 0x10
	private readonly Dictionary<String, String> m_Tags; //Field offset: 0x18
	private readonly Stopwatch m_Stopwatch; //Field offset: 0x20
	private bool m_Disposed; //Field offset: 0x28

	public ApiTelemetryScope(IMetrics metrics, string api) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

}

