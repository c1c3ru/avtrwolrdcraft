namespace Unity.Services.Authentication.Shared;

internal interface IApiClient
{

	public Task<ApiResponse`1<T>> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse`1<T>> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

	public Task<ApiResponse> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = null) { }

}

