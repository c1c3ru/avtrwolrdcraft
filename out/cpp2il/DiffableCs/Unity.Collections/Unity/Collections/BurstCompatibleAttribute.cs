namespace Unity.Collections;

[AttributeUsage(236, AllowMultiple = True)]
public class BurstCompatibleAttribute : Attribute
{
	internal enum BurstCompatibleCompileTarget
	{
		Player = 0,
		Editor = 1,
		PlayerAndEditor = 2,
	}

	[CompilerGenerated]
	private Type[] <GenericTypeArguments>k__BackingField; //Field offset: 0x10
	public string RequiredUnityDefine; //Field offset: 0x18
	public BurstCompatibleCompileTarget CompileTarget; //Field offset: 0x20

	public Type[] GenericTypeArguments
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public BurstCompatibleAttribute() { }

	[CompilerGenerated]
	public Type[] get_GenericTypeArguments() { }

	[CompilerGenerated]
	public void set_GenericTypeArguments(Type[] value) { }

}

