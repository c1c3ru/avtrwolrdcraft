namespace Unity.Services.Lobbies.Http;

[Preserve]
internal class BasicError : IError
{
	[CompilerGenerated]
	private readonly string <Type>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Title>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Nullable<Int32> <Status>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly int <Code>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly string <Detail>k__BackingField; //Field offset: 0x30

	[Preserve]
	public override int Code
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public override string Detail
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public override Nullable<Int32> Status
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public override string Title
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public override string Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public BasicError(string type, string title, Nullable<Int32> status, int code, string detail) { }

	[CompilerGenerated]
	public override int get_Code() { }

	[CompilerGenerated]
	public override string get_Detail() { }

	[CompilerGenerated]
	public override Nullable<Int32> get_Status() { }

	[CompilerGenerated]
	public override string get_Title() { }

	[CompilerGenerated]
	public override string get_Type() { }

	public virtual string ToString() { }

}

