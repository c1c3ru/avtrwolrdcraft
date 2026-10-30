namespace Spine.Unity;

public interface IAnimationStateComponent : ISpineComponent
{

	public AnimationState AnimationState
	{
		 get { } //Length: 0
	}

	public bool UnscaledTime
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public AnimationState get_AnimationState() { }

	public bool get_UnscaledTime() { }

	public void set_UnscaledTime(bool value) { }

}

