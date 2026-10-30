namespace Spine.Unity;

[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRootMotion")]
public class SkeletonRootMotion : SkeletonRootMotionBase
{
	private const int DefaultAnimationTrackFlags = -1; //Field offset: 0x0
	public int animationTrackFlags; //Field offset: 0xF8
	private AnimationState animationState; //Field offset: 0x100
	private SkeletonGraphic skeletonGraphic; //Field offset: 0x108

	protected virtual float AdditionalScale
	{
		 get { } //Length: 120
	}

	public SkeletonRootMotion() { }

	private void ApplyMixAlphaToDelta(ref Vector2 currentDelta, TrackEntry next, TrackEntry track) { }

	private void ApplyMixAlphaToDelta(ref float currentDelta, TrackEntry next, TrackEntry track) { }

	protected virtual Vector2 CalculateAnimationsMovementDelta() { }

	protected virtual float CalculateAnimationsRotationDelta() { }

	protected virtual float get_AdditionalScale() { }

	private void GetMixAlpha(ref float cumulatedMixAlpha, TrackEntry next, TrackEntry track) { }

	public virtual Vector2 GetRemainingRootMotion(int trackIndex) { }

	public virtual RootMotionInfo GetRootMotionInfo(int trackIndex) { }

	public virtual void Initialize() { }

	protected virtual void Reset() { }

}

