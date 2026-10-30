namespace Unity.Services.Authentication;

internal class AuthenticationMetrics : IAuthenticationMetrics
{
	private const string k_PackageName = "com.unity.services.authentication"; //Field offset: 0x0
	private const string k_NetworkErrorKey = "network_error_event"; //Field offset: 0x0
	private const string k_ExpiredSessionKey = "expired_session_event"; //Field offset: 0x0
	private const string k_ClientInvalidStateExceptionKey = "client_invalid_state_exception_event"; //Field offset: 0x0
	private const string k_UnlinkExternalIdNotFoundExceptionKey = "unlink_external_id_not_found_exception_event"; //Field offset: 0x0
	private const string k_ClientSessionTokenNotExistsExceptionKey = "client_session_token_not_exists_exception_event"; //Field offset: 0x0
	private readonly IMetrics m_Metrics; //Field offset: 0x10

	internal AuthenticationMetrics(IMetricsFactory metricsFactory) { }

	public override void SendClientInvalidStateExceptionMetric() { }

	public override void SendClientSessionTokenNotExistsExceptionMetric() { }

	public override void SendExpiredSessionMetric() { }

	public override void SendNetworkErrorMetric() { }

	public override void SendUnlinkExternalIdNotFoundExceptionMetric() { }

}

