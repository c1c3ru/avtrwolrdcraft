namespace UnityEngine.Animations;

[NativeHeader("Runtime/Director/Core/HPlayable.h")]
[NativeHeader("Modules/Animation/Director/AnimationPosePlayable.h")]
[NativeHeader("Modules/Animation/ScriptBindings/AnimationPosePlayable.bindings.h")]
[RequiredByNativeCode]
[StaticAccessor("AnimationPosePlayableBindings", StaticAccessorType::DoubleColon (2))]
internal struct AnimationPosePlayable : IEquatable<AnimationPosePlayable>
{
	private static readonly AnimationPosePlayable m_NullPlayable; //Field offset: 0x0
	private PlayableHandle m_Handle; //Field offset: 0x0

	private static AnimationPosePlayable() { }

	internal AnimationPosePlayable(PlayableHandle handle) { }

	public override bool Equals(AnimationPosePlayable other) { }

	public override PlayableHandle GetHandle() { }

}

