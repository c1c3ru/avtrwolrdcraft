namespace Unity.Services.Lobbies.Http;

internal class ApiTelemetryScopeFactory
{
	private readonly IMetrics m_Metrics; //Field offset: 0x10

	public ApiTelemetryScopeFactory(IMetrics metrics) { }

	public ApiTelemetryScope Instrument(string api) { }

}

