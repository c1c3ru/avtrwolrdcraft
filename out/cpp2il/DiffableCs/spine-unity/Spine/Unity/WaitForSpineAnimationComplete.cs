namespace Spine.Unity;

public class WaitForSpineAnimationComplete : WaitForSpineAnimation, IEnumerator
{

	public WaitForSpineAnimationComplete(TrackEntry trackEntry, bool includeEndEvent = false) { }

	public WaitForSpineAnimationComplete NowWaitFor(TrackEntry trackEntry, bool includeEndEvent = false) { }

}

