namespace Unity.Services.Authentication.Shared;

internal class ApiRequestPathBuilder
{
	private string _baseUrl; //Field offset: 0x10
	private string _path; //Field offset: 0x18
	private string _query; //Field offset: 0x20

	public ApiRequestPathBuilder(string baseUrl, string path) { }

	public void AddPathParameters(Dictionary<String, String> parameters) { }

	public void AddQueryParameters(Multimap<String, String> parameters) { }

	public string GetFullUri() { }

}

