namespace UnityEngine;

[NativeHeader("Modules/Animation/Motion.h")]
public class Motion : object
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <isAnimatorMotion>k__BackingField; //Field offset: 0x18

	public bool isLooping
	{
		[NativeMethod("IsLooping")]
		 get { } //Length: 60
	}

	protected Motion() { }

	[NativeMethod("IsLooping")]
	public bool get_isLooping() { }

}

