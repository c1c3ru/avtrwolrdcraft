namespace Spine.Unity;

[CreateAssetMenu(menuName = "Spine/Animation Reference Asset", order = 100)]
public class AnimationReferenceAsset : ScriptableObject, IHasSkeletonDataAsset, ISpineComponent
{
	private const bool QuietSkeletonData = True; //Field offset: 0x0
	[SerializeField]
	protected SkeletonDataAsset skeletonDataAsset; //Field offset: 0x18
	[SerializeField]
	[SpineAnimation(null, null, True, False, False)]
	protected string animationName; //Field offset: 0x20
	private Animation animation; //Field offset: 0x28

	public Animation Animation
	{
		 get { } //Length: 36
	}

	public override SkeletonDataAsset SkeletonDataAsset
	{
		 get { } //Length: 8
	}

	public AnimationReferenceAsset() { }

	public void Clear() { }

	public Animation get_Animation() { }

	public override SkeletonDataAsset get_SkeletonDataAsset() { }

	public void Initialize() { }

	public static Animation op_Implicit(AnimationReferenceAsset asset) { }

}

