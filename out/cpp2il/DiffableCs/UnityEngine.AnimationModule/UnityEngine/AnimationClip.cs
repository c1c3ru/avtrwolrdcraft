namespace UnityEngine;

[NativeHeader("Modules/Animation/ScriptBindings/AnimationClip.bindings.h")]
[NativeType("Modules/Animation/AnimationClip.h")]
public sealed class AnimationClip : Motion
{

	[NativeProperty("Length", False, TargetType::Function (0))]
	public float length
	{
		 get { } //Length: 60
	}

	public AnimationClip() { }

	public float get_length() { }

	[FreeFunction("AnimationClipBindings::Internal_CreateAnimationClip")]
	private static void Internal_CreateAnimationClip(AnimationClip self) { }

}

