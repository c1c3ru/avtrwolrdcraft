namespace Unity.Services.Qos.V2.ErrorMitigation;

internal class StatusCodePolicyConfig
{
	private IDictionary<Int64, Boolean> _statusCodesToHandleDict; //Field offset: 0x10

	public StatusCodePolicyConfig() { }

	public void Clear() { }

	public void DontHandleStatusCode(long code) { }

	public void HandleStatusCode(long code) { }

	public bool IsHandledStatusCode(long code) { }

}

