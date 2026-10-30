namespace Spine;

public class AnimationState
{
	internal sealed class TrackEntryDelegate : MulticastDelegate
	{

		public TrackEntryDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(TrackEntry trackEntry, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(TrackEntry trackEntry) { }

	}

	internal sealed class TrackEntryEventDelegate : MulticastDelegate
	{

		public TrackEntryEventDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(TrackEntry trackEntry, Event e, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(TrackEntry trackEntry, Event e) { }

	}

	internal static readonly Animation EmptyAnimation; //Field offset: 0x0
	internal const int Subsequent = 0; //Field offset: 0x0
	internal const int First = 1; //Field offset: 0x0
	internal const int HoldSubsequent = 2; //Field offset: 0x0
	internal const int HoldFirst = 3; //Field offset: 0x0
	internal const int HoldMix = 4; //Field offset: 0x0
	internal const int Setup = 1; //Field offset: 0x0
	internal const int Current = 2; //Field offset: 0x0
	protected AnimationStateData data; //Field offset: 0x10
	private readonly ExposedList<TrackEntry> tracks; //Field offset: 0x18
	private readonly ExposedList<Event> events; //Field offset: 0x20
	[CompilerGenerated]
	private TrackEntryDelegate Start; //Field offset: 0x28
	[CompilerGenerated]
	private TrackEntryDelegate Interrupt; //Field offset: 0x30
	[CompilerGenerated]
	private TrackEntryDelegate End; //Field offset: 0x38
	[CompilerGenerated]
	private TrackEntryDelegate Dispose; //Field offset: 0x40
	[CompilerGenerated]
	private TrackEntryDelegate Complete; //Field offset: 0x48
	[CompilerGenerated]
	private TrackEntryEventDelegate Event; //Field offset: 0x50
	private readonly EventQueue queue; //Field offset: 0x58
	private readonly HashSet<String> propertyIds; //Field offset: 0x60
	private bool animationsChanged; //Field offset: 0x68
	private float timeScale; //Field offset: 0x6C
	private int unkeyedState; //Field offset: 0x70
	private readonly Pool<TrackEntry> trackEntryPool; //Field offset: 0x78

	public event TrackEntryDelegate Complete
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TrackEntryDelegate Dispose
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TrackEntryDelegate End
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TrackEntryEventDelegate Event
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TrackEntryDelegate Interrupt
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event TrackEntryDelegate Start
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public AnimationStateData Data
	{
		 get { } //Length: 8
		 set { } //Length: 124
	}

	public float TimeScale
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<TrackEntry> Tracks
	{
		 get { } //Length: 8
	}

	private static AnimationState() { }

	public AnimationState(AnimationStateData data) { }

	[CompilerGenerated]
	private void <.ctor>b__45_0() { }

	[CompilerGenerated]
	public void add_Complete(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void add_Dispose(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void add_End(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void add_Event(TrackEntryEventDelegate value) { }

	[CompilerGenerated]
	public void add_Interrupt(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void add_Start(TrackEntryDelegate value) { }

	public TrackEntry AddAnimation(int trackIndex, Animation animation, bool loop, float delay) { }

	public TrackEntry AddAnimation(int trackIndex, string animationName, bool loop, float delay) { }

	public TrackEntry AddEmptyAnimation(int trackIndex, float mixDuration, float delay) { }

	public void AddEventSubscribersFrom(AnimationState src) { }

	private void AnimationsChanged() { }

	public bool Apply(Skeleton skeleton) { }

	private void ApplyAttachmentTimeline(AttachmentTimeline timeline, Skeleton skeleton, float time, MixBlend blend, bool attachments) { }

	public bool ApplyEventTimelinesOnly(Skeleton skeleton, bool issueEvents = true) { }

	private float ApplyMixingFrom(TrackEntry to, Skeleton skeleton, MixBlend blend) { }

	private float ApplyMixingFromEventTimelinesOnly(TrackEntry to, Skeleton skeleton, bool issueEvents) { }

	private static void ApplyRotateTimeline(RotateTimeline timeline, Skeleton skeleton, float time, float alpha, MixBlend blend, Single[] timelinesRotation, int i, bool firstFrame) { }

	public void AssignEventSubscribersFrom(AnimationState src) { }

	public void ClearListenerNotifications() { }

	public void ClearNext(TrackEntry entry) { }

	public void ClearTrack(int trackIndex) { }

	public void ClearTracks() { }

	private void ComputeHold(TrackEntry entry) { }

	private TrackEntry ExpandToIndex(int index) { }

	public AnimationStateData get_Data() { }

	public float get_TimeScale() { }

	public ExposedList<TrackEntry> get_Tracks() { }

	public TrackEntry GetCurrent(int trackIndex) { }

	private TrackEntry NewTrackEntry(int trackIndex, Animation animation, bool loop, TrackEntry last) { }

	internal void OnComplete(TrackEntry entry) { }

	internal void OnDispose(TrackEntry entry) { }

	internal void OnEnd(TrackEntry entry) { }

	internal void OnEvent(TrackEntry entry, Event e) { }

	internal void OnInterrupt(TrackEntry entry) { }

	internal void OnStart(TrackEntry entry) { }

	private void QueueEvents(TrackEntry entry, float animationTime) { }

	[CompilerGenerated]
	public void remove_Complete(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void remove_Dispose(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void remove_End(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void remove_Event(TrackEntryEventDelegate value) { }

	[CompilerGenerated]
	public void remove_Interrupt(TrackEntryDelegate value) { }

	[CompilerGenerated]
	public void remove_Start(TrackEntryDelegate value) { }

	public void set_Data(AnimationStateData value) { }

	public void set_TimeScale(float value) { }

	public TrackEntry SetAnimation(int trackIndex, string animationName, bool loop) { }

	public TrackEntry SetAnimation(int trackIndex, Animation animation, bool loop) { }

	private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName, bool attachments) { }

	private void SetCurrent(int index, TrackEntry current, bool interrupt) { }

	public TrackEntry SetEmptyAnimation(int trackIndex, float mixDuration) { }

	public void SetEmptyAnimations(float mixDuration) { }

	public virtual string ToString() { }

	public void Update(float delta) { }

	private bool UpdateMixingFrom(TrackEntry to, float delta) { }

}

