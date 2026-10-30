namespace PWC.Level;

public interface ILevelAnimatable
{

	[CompilerGenerated]
	private void <PlayAnimationAndReturnToProperIdle>b__4_0(TrackEntry _) { }

	public TrackEntry AddAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

	public string GetCurrentAnimationName() { }

	public SkeletonAnimation GetSkeletonAnimation() { }

	public TrackEntry PlayAnimationAndReturnToProperIdle(string animationName, int trackIndex = 0) { }

	public void ReturnToProperIdle() { }

	public TrackEntry SetAnimation(string animationName, bool loop = false, int trackIndex = 0) { }

}

