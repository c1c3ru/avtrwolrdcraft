namespace Unity.Services.Authentication;

internal class AuthenticationExceptionHandler : IAuthenticationExceptionHandler
{
	[CompilerGenerated]
	private readonly IAuthenticationMetrics <Metrics>k__BackingField; //Field offset: 0x10

	private IAuthenticationMetrics Metrics
	{
		[CompilerGenerated]
		private get { } //Length: 8
	}

	public AuthenticationExceptionHandler(IAuthenticationMetrics metrics) { }

	public override RequestFailedException BuildClientInvalidProfileException() { }

	public override RequestFailedException BuildClientInvalidStateException(AuthenticationState state) { }

	public override RequestFailedException BuildClientSessionTokenNotExistsException() { }

	public override RequestFailedException BuildClientUnlinkExternalIdNotFoundException() { }

	public override RequestFailedException BuildInvalidCredentialsException() { }

	public override RequestFailedException BuildInvalidIdProviderNameException() { }

	public override RequestFailedException BuildInvalidPlayerNameException() { }

	public override RequestFailedException BuildUnknownException(string error) { }

	public override RequestFailedException ConvertException(WebRequestException exception) { }

	public override RequestFailedException ConvertException(ApiException exception) { }

	private static RequestFailedException CreateHttpException(ApiException exception) { }

	private static RequestFailedException CreateNetworkException(ApiException exception) { }

	private static RequestFailedException CreateUnknownException(Exception exception) { }

	[CompilerGenerated]
	private IAuthenticationMetrics get_Metrics() { }

	private int MapErrorCodes(string serverErrorTitle) { }

	private static List<Notification> ParseNotifications(List<Object> details) { }

}

