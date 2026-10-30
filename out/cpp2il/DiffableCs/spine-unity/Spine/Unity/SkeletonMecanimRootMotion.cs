namespace Spine.Unity;

[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonMecanimRootMotion")]
public class SkeletonMecanimRootMotion : SkeletonRootMotionBase
{
	private const int DefaultMecanimLayerFlags = -1; //Field offset: 0x0
	public int mecanimLayerFlags; //Field offset: 0xF8
	protected Vector2 movementDelta; //Field offset: 0xFC
	protected float rotationDelta; //Field offset: 0x104
	private SkeletonMecanim skeletonMecanim; //Field offset: 0x108

	public SkeletonMecanim SkeletonMecanim
	{
		 get { } //Length: 168
	}

	public SkeletonMecanimRootMotion() { }

	protected virtual Vector2 CalculateAnimationsMovementDelta() { }

	protected virtual float CalculateAnimationsRotationDelta() { }

	public SkeletonMecanim get_SkeletonMecanim() { }

	public virtual Vector2 GetRemainingRootMotion(int layerIndex) { }

	public virtual RootMotionInfo GetRootMotionInfo(int layerIndex) { }

	public virtual void Initialize() { }

	private void OnClipApplied(Animation animation, int layerIndex, float weight, float time, float lastTime, bool playsBackward) { }

	protected virtual void Reset() { }

}

