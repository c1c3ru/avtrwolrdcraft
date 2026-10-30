namespace Spine.Unity;

public class WaitForSpineEvent : IEnumerator
{
	private EventData m_TargetEvent; //Field offset: 0x10
	private string m_EventName; //Field offset: 0x18
	private AnimationState m_AnimationState; //Field offset: 0x20
	private bool m_WasFired; //Field offset: 0x28
	private bool m_unsubscribeAfterFiring; //Field offset: 0x29

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 8
	}

	public bool WillUnsubscribeAfterFiring
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public WaitForSpineEvent(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true) { }

	public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, EventData eventDataReference, bool unsubscribeAfterFiring = true) { }

	public WaitForSpineEvent(AnimationState state, string eventName, bool unsubscribeAfterFiring = true) { }

	public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, string eventName, bool unsubscribeAfterFiring = true) { }

	private void Clear(AnimationState state) { }

	public bool get_WillUnsubscribeAfterFiring() { }

	private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e) { }

	private void HandleAnimationStateEventByName(TrackEntry trackEntry, Event e) { }

	public WaitForSpineEvent NowWaitFor(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true) { }

	public WaitForSpineEvent NowWaitFor(AnimationState state, string eventName, bool unsubscribeAfterFiring = true) { }

	public void set_WillUnsubscribeAfterFiring(bool value) { }

	private void Subscribe(AnimationState state, EventData eventDataReference, bool unsubscribe) { }

	private void SubscribeByName(AnimationState state, string eventName, bool unsubscribe) { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

