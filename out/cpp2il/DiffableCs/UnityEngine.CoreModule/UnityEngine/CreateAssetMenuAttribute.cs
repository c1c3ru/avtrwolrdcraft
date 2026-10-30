namespace UnityEngine;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = False)]
public sealed class CreateAssetMenuAttribute : Attribute
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <menuName>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <fileName>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <order>k__BackingField; //Field offset: 0x20

	public string fileName
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public string menuName
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public int order
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public CreateAssetMenuAttribute() { }

	[CompilerGenerated]
	public void set_fileName(string value) { }

	[CompilerGenerated]
	public void set_menuName(string value) { }

	[CompilerGenerated]
	public void set_order(int value) { }

}

