namespace Unity.Services.Authentication;

internal interface IAuthenticationMetrics
{

	public void SendClientInvalidStateExceptionMetric() { }

	public void SendClientSessionTokenNotExistsExceptionMetric() { }

	public void SendExpiredSessionMetric() { }

	public void SendNetworkErrorMetric() { }

	public void SendUnlinkExternalIdNotFoundExceptionMetric() { }

}

