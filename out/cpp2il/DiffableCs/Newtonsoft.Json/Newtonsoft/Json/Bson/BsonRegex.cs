namespace Newtonsoft.Json.Bson;

internal class BsonRegex : BsonToken
{
	[CompilerGenerated]
	private BsonString <Pattern>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private BsonString <Options>k__BackingField; //Field offset: 0x28

	public BsonString Options
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public BsonString Pattern
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public virtual BsonType Type
	{
		 get { } //Length: 8
	}

	public BsonRegex(string pattern, string options) { }

	[CompilerGenerated]
	public BsonString get_Options() { }

	[CompilerGenerated]
	public BsonString get_Pattern() { }

	public virtual BsonType get_Type() { }

	[CompilerGenerated]
	public void set_Options(BsonString value) { }

	[CompilerGenerated]
	public void set_Pattern(BsonString value) { }

}

