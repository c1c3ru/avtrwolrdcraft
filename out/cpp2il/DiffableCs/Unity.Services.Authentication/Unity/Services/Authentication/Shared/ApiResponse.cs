namespace Unity.Services.Authentication.Shared;

internal class ApiResponse : IApiResponse
{
	[CompilerGenerated]
	private int <StatusCode>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Multimap<String, String> <Headers>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <ErrorText>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <RawContent>k__BackingField; //Field offset: 0x28

	public override object Content
	{
		 get { } //Length: 8
	}

	public internal override string ErrorText
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override Multimap<String, String> Headers
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public override bool IsClientError
	{
		 get { } //Length: 20
	}

	public override bool IsRedirection
	{
		 get { } //Length: 20
	}

	public override bool IsServerError
	{
		 get { } //Length: 20
	}

	public override bool IsSuccessful
	{
		 get { } //Length: 20
	}

	public internal override string RawContent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal override int StatusCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public ApiResponse() { }

	public override object get_Content() { }

	[CompilerGenerated]
	public override string get_ErrorText() { }

	[CompilerGenerated]
	public override Multimap<String, String> get_Headers() { }

	public override bool get_IsClientError() { }

	public override bool get_IsRedirection() { }

	public override bool get_IsServerError() { }

	public override bool get_IsSuccessful() { }

	[CompilerGenerated]
	public override string get_RawContent() { }

	[CompilerGenerated]
	public override int get_StatusCode() { }

	[CompilerGenerated]
	internal void set_ErrorText(string value) { }

	[CompilerGenerated]
	internal void set_Headers(Multimap<String, String> value) { }

	[CompilerGenerated]
	internal void set_RawContent(string value) { }

	[CompilerGenerated]
	internal void set_StatusCode(int value) { }

}

