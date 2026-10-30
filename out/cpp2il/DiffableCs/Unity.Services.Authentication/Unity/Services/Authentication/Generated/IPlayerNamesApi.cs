namespace Unity.Services.Authentication.Generated;

internal interface IPlayerNamesApi : IApiAccessor
{

	public Task<ApiResponse`1<Player>> GetNameAsync(string playerId, Nullable<Boolean> autoGenerate = null, Nullable<Boolean> showMetadata = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<Player>> UpdateNameAsync(string playerId, UpdateNameRequest updateNameRequest, CancellationToken cancellationToken = null) { }

}

