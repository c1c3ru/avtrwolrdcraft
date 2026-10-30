namespace PWC.Level;

[AttributeUsage(AttributeTargets::Class (4), Inherited = True, AllowMultiple = False)]
public class HideParentPropertiesInInspector : Attribute
{
	[CompilerGenerated]
	private String[] <Names>k__BackingField; //Field offset: 0x10

	public private String[] Names
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public HideParentPropertiesInInspector(String[] names) { }

	[CompilerGenerated]
	public String[] get_Names() { }

	[CompilerGenerated]
	private void set_Names(String[] value) { }

}

