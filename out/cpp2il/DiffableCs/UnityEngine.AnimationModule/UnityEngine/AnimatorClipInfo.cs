namespace UnityEngine;

[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
[NativeHeader("Modules/Animation/AnimatorInfo.h")]
[UsedByNativeCode]
public struct AnimatorClipInfo
{
	private int m_ClipInstanceID; //Field offset: 0x0
	private float m_Weight; //Field offset: 0x4

	public AnimationClip clip
	{
		 get { } //Length: 80
	}

	public float weight
	{
		 get { } //Length: 8
	}

	public AnimationClip get_clip() { }

	public float get_weight() { }

	[FreeFunction("AnimationBindings::InstanceIDToAnimationClipPPtr")]
	private static AnimationClip InstanceIDToAnimationClipPPtr(int instanceID) { }

}

