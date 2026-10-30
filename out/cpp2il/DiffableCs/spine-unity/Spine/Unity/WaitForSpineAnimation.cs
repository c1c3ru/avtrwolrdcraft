namespace Spine.Unity;

public class WaitForSpineAnimation : IEnumerator
{
	[Flags]
	internal enum AnimationEventTypes
	{
		Start = 1,
		Interrupt = 2,
		End = 4,
		Dispose = 8,
		Complete = 16,
	}

	private bool m_WasFired; //Field offset: 0x10

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 8
	}

	public WaitForSpineAnimation(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor) { }

	private void HandleComplete(TrackEntry trackEntry) { }

	public WaitForSpineAnimation NowWaitFor(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor) { }

	protected void SafeSubscribe(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

