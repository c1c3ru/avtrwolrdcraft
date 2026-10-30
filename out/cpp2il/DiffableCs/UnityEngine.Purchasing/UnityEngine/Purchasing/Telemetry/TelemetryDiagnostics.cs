namespace UnityEngine.Purchasing.Telemetry;

internal class TelemetryDiagnostics : ITelemetryDiagnostics
{
	private readonly ITelemetryDiagnosticsInstanceWrapper m_TelemetryDiagnosticsInstanceWrapper; //Field offset: 0x10

	public TelemetryDiagnostics(ITelemetryDiagnosticsInstanceWrapper telemetryDiagnosticsInstanceWrapper) { }

	public override void SendDiagnostic(string diagnosticName, Exception e) { }

}

