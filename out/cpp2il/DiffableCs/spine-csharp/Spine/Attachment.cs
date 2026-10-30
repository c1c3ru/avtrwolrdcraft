namespace Spine;

public abstract class Attachment
{
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x10

	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	protected Attachment(string name) { }

	protected Attachment(Attachment other) { }

	public abstract Attachment Copy() { }

	[CompilerGenerated]
	public string get_Name() { }

	public virtual string ToString() { }

}

