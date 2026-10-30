namespace UnityEngine.ResourceManagement.Util;

public class UnityWebRequestResult
{
	[CompilerGenerated]
	private string <Error>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly long <ResponseCode>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Result <Result>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <Method>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <Url>k__BackingField; //Field offset: 0x30

	public string Error
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public string Method
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public long ResponseCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Result Result
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public string Url
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public UnityWebRequestResult(UnityWebRequest request) { }

	[CompilerGenerated]
	public string get_Error() { }

	[CompilerGenerated]
	public string get_Method() { }

	[CompilerGenerated]
	public long get_ResponseCode() { }

	[CompilerGenerated]
	public Result get_Result() { }

	[CompilerGenerated]
	public string get_Url() { }

	[CompilerGenerated]
	public void set_Error(string value) { }

	public bool ShouldRetryDownloadError() { }

	public virtual string ToString() { }

}

