namespace Unity.Services.Authentication.PlayerAccounts;

internal class NetworkHandler : INetworkHandler
{
	internal static class ContentType
	{
		public const string Json = "application/json"; //Field offset: 0x0

	}

	[CompilerGenerated]
	private readonly INetworkConfiguration <Configuration>k__BackingField; //Field offset: 0x10
	private readonly JsonSerializerSettings m_JsonSerializerSettings; //Field offset: 0x18

	private INetworkConfiguration Configuration
	{
		[CompilerGenerated]
		private get { } //Length: 8
	}

	public NetworkHandler() { }

	public override Task DeleteAsync(string url, IDictionary<String, String> headers = null) { }

	public override Task<T> DeleteAsync(string url, IDictionary<String, String> headers = null) { }

	[CompilerGenerated]
	private INetworkConfiguration get_Configuration() { }

	public override Task<T> GetAsync(string url, IDictionary<String, String> headers = null) { }

	public override Task<T> PostAsync(string url, IDictionary<String, String> headers = null) { }

	public override Task<T> PostAsync(string url, string payload, IDictionary<String, String> headers = null) { }

	public override Task<T> PutAsync(string url, object payload, IDictionary<String, String> headers = null) { }

}

