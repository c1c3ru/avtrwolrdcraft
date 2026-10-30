namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCSpineSkeletonAnimationPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public AFCSpineSkeletonAnimationPlayer <>4__this; //Field offset: 0x10
		public string animationName; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal void <PlayAnimation>b__0() { }

	}

	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private string _idleAniamtion; //Field offset: 0x28

	public AFCSpineSkeletonAnimationPlayer() { }

	[CompilerGenerated]
	private void <PlayIdleLoopAnimation>b__3_0() { }

	private void DetectAnimation(string SpineAnimation, Action playAnimation) { }

	public void PlayAnimation(string animationName) { }

	private void PlayIdleLoopAnimation() { }

}

