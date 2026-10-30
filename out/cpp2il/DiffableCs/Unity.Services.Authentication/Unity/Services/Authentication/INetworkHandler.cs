namespace Unity.Services.Authentication;

internal interface INetworkHandler
{

	public Task DeleteAsync(string url, IDictionary<String, String> headers = null) { }

	public Task<T> DeleteAsync(string url, IDictionary<String, String> headers = null) { }

	public Task<T> GetAsync(string url, IDictionary<String, String> headers = null) { }

	public Task<T> PostAsync(string url, IDictionary<String, String> headers = null) { }

	public Task<T> PostAsync(string url, object payload, IDictionary<String, String> headers = null) { }

	public Task<T> PutAsync(string url, object payload, IDictionary<String, String> headers = null) { }

}

