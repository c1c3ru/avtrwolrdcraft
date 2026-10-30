namespace Unity.Services.Authentication.Shared;

internal interface IApiResponse
{

	public object Content
	{
		 get { } //Length: 0
	}

	public string ErrorText
	{
		 get { } //Length: 0
	}

	public Multimap<String, String> Headers
	{
		 get { } //Length: 0
	}

	public bool IsClientError
	{
		 get { } //Length: 0
	}

	public bool IsRedirection
	{
		 get { } //Length: 0
	}

	public bool IsServerError
	{
		 get { } //Length: 0
	}

	public bool IsSuccessful
	{
		 get { } //Length: 0
	}

	public string RawContent
	{
		 get { } //Length: 0
	}

	public int StatusCode
	{
		 get { } //Length: 0
	}

	public object get_Content() { }

	public string get_ErrorText() { }

	public Multimap<String, String> get_Headers() { }

	public bool get_IsClientError() { }

	public bool get_IsRedirection() { }

	public bool get_IsServerError() { }

	public bool get_IsSuccessful() { }

	public string get_RawContent() { }

	public int get_StatusCode() { }

}

