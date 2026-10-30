namespace Unity.Services.Authentication.Shared;

internal abstract class AbstractOpenAPISchema
{
	public static readonly JsonSerializerSettings SerializerSettings; //Field offset: 0x0
	public static readonly JsonSerializerSettings AdditionalPropertiesSerializerSettings; //Field offset: 0x8
	[CompilerGenerated]
	private bool <IsNullable>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <SchemaType>k__BackingField; //Field offset: 0x18

	public abstract object ActualInstance
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool IsNullable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public string SchemaType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private static AbstractOpenAPISchema() { }

	protected AbstractOpenAPISchema() { }

	public abstract object get_ActualInstance() { }

	[CompilerGenerated]
	public bool get_IsNullable() { }

	[CompilerGenerated]
	public string get_SchemaType() { }

	public abstract void set_ActualInstance(object value) { }

	[CompilerGenerated]
	protected void set_IsNullable(bool value) { }

	[CompilerGenerated]
	protected void set_SchemaType(string value) { }

	public abstract string ToJson() { }

}

