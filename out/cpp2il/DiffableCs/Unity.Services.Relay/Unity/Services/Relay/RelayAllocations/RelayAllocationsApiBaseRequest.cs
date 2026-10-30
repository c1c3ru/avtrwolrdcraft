namespace Unity.Services.Relay.RelayAllocations;

[Preserve]
internal class RelayAllocationsApiBaseRequest
{
	private static readonly Regex JsonRegex; //Field offset: 0x0

	private static RelayAllocationsApiBaseRequest() { }

	public RelayAllocationsApiBaseRequest() { }

	[Preserve]
	public List<String> AddParamsToQueryParams(List<String> queryParams, string key, string value) { }

	[Preserve]
	public List<String> AddParamsToQueryParams(List<String> queryParams, string key, List<String> values, string style, bool explode) { }

	[Preserve]
	public List<String> AddParamsToQueryParams(List<String> queryParams, Dictionary<String, String> modelVars) { }

	[Preserve]
	public List<String> AddParamsToQueryParams(List<String> queryParams, string key, T value) { }

	public Byte[] ConstructBody(Stream stream) { }

	public Byte[] ConstructBody(string s) { }

	public Byte[] ConstructBody(object o) { }

	public string GenerateAcceptHeader(String[] accepts) { }

	public string GenerateContentTypeHeader(String[] contentTypes) { }

	public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, FileStream stream, string contentType) { }

	public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, Stream stream, string contentType) { }

	private string GetFileName(string filePath) { }

	[Preserve]
	public string GetPathParamString(List<String> pathParam) { }

}

