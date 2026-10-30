namespace PazuCore.PazuCloud;

public class Response
{
	internal enum ResultType
	{
		Ok = 0,
		Error = 1,
	}

	public ResultType resultType; //Field offset: 0x10
	public bool isLocalResponse; //Field offset: 0x14
	public readonly string result; //Field offset: 0x18
	public readonly string status; //Field offset: 0x20
	public readonly string message; //Field offset: 0x28
	public readonly string jwtDataString; //Field offset: 0x30
	public readonly Dictionary<String, Object> data; //Field offset: 0x38
	public readonly Dictionary<String, Object> jwtData; //Field offset: 0x40
	public readonly string text; //Field offset: 0x48
	public readonly ClientMessage clientMessage; //Field offset: 0x50

	public Response(string responseText) { }

	public Response() { }

	public static Response GetFailureResponse(bool isLocalResponse) { }

	protected string GetStringFromData(string fromKey, bool logErrorOnFailure = true) { }

	protected string GetStringFromDictionary(Dictionary<String, Object> dictionary, string fromKey, bool logErrorOnFailure = true) { }

	protected string GetStringFromJWTData(string fromKey, bool logErrorOnFailure = true) { }

	public bool IsResultOk() { }

	public override void Log(string op) { }

	public void LogAllInfo(string op) { }

	private Dictionary<String, Object> ParseData(string responseString) { }

}

