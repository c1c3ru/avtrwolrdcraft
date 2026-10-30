namespace Unity.Services.Authentication;

internal interface IAuthenticationNetworkClient
{

	public Task<SignInResponse> AddUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public Task<CodeLinkConfirmResponse> ConfirmCodeAsync(ConfirmSignInCodeRequest request) { }

	public Task DeleteAccountAsync(string playerId) { }

	public Task<GenerateCodeResponse> GenerateSignInCodeAsync(GenerateSignInCodeRequest request) { }

	public Task<CodeLinkInfoResponse> GetCodeIdentifierAsync(CodeLinkInfoRequest request) { }

	public Task<GetNotificationsResponse> GetNotificationsAsync(string playerId) { }

	public Task<PlayerInfoResponse> GetPlayerInfoAsync(string playerId) { }

	public Task<LinkResponse> LinkWithExternalTokenAsync(string idProvider, LinkWithExternalTokenRequest externalToken) { }

	public Task<SignInResponse> SignInAnonymouslyAsync() { }

	public Task<SignInResponse> SignInWithCodeAsync(SignInWithCodeRequest request) { }

	public Task<SignInResponse> SignInWithExternalTokenAsync(string idProvider, SignInWithExternalTokenRequest externalToken) { }

	public Task<SignInResponse> SignInWithSessionTokenAsync(string token) { }

	public Task<SignInResponse> SignInWithUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public Task<SignInResponse> SignUpWithUsernamePasswordAsync(UsernamePasswordRequest credentials) { }

	public Task<UnlinkResponse> UnlinkExternalTokenAsync(string idProvider, UnlinkRequest request) { }

	public Task<SignInResponse> UpdatePasswordAsync(UpdatePasswordRequest credentials) { }

}

