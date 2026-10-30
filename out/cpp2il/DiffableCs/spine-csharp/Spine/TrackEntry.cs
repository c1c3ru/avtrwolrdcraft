namespace Spine;

public class TrackEntry : IPoolable<TrackEntry>
{
	internal Animation animation; //Field offset: 0x10
	internal TrackEntry previous; //Field offset: 0x18
	internal TrackEntry next; //Field offset: 0x20
	internal TrackEntry mixingFrom; //Field offset: 0x28
	internal TrackEntry mixingTo; //Field offset: 0x30
	[CompilerGenerated]
	private TrackEntryDelegate Start; //Field offset: 0x38
	[CompilerGenerated]
	private TrackEntryDelegate Interrupt; //Field offset: 0x40
	[CompilerGenerated]
	private TrackEntryDelegate End; //Field offset: 0x48
	[CompilerGenerated]
	private TrackEntryDelegate Dispose; //Field offset: 0x50
	[CompilerGenerated]
	private TrackEntryDelegate Complete; //Field offset: 0x58
	[CompilerGenerated]
	private TrackEntryEventDelegate Event; //Field offset: 0x60
	internal int trackIndex; //Field offset: 0x68
	internal bool loop; //Field offset: 0x6C
	internal bool holdPrevious; //Field offset: 0x6D
	internal bool reverse; //Field offset: 0x6E
	internal bool shortestRotation; //Field offset: 0x6F
	internal float eventThreshold; //Field offset: 0x70
	internal float mixAttachmentThreshold; //Field offset: 0x74
	internal float alphaAttachmentThreshold; //Field offset: 0x78
	internal float mixDrawOrderThreshold; //Field offset: 0x7C
	internal float animationStart; //Field offset: 0x80
	internal float animationEnd; //Field offset: 0x84
	internal float animationLast; //Field offset: 0x88
	internal float nextAnimationLast; //Field offset: 0x8C
	internal float delay; //Field offset: 0x90
	internal float trackTime; //Field offset: 0x94
	internal float trackLast; //Field offset: 0x98
	internal float nextTrackLast; //Field offset: 0x9C
	internal float trackEnd; //Field offset: 0xA0
	internal float timeScale; //Field offset: 0xA4
	internal float alpha; //Field offset: 0xA8
	internal float mixTime; //Field offset: 0xAC
	internal float mixDuration; //Field offset: 0xB0
	internal float interruptAlpha; //Field offset: 0xB4
	internal float totalAlpha; //Field offset: 0xB8
	internal MixBlend mixBlend; //Field offset: 0xBC
	internal readonly ExposedList<Int32> timelineMode; //Field offset: 0xC0
	internal readonly ExposedList<TrackEntry> timelineHoldMix; //Field offset: 0xC8
	internal readonly ExposedList<Single> timelinesRotation; //Field offset: 0xD0

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

	public float Alpha
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float AlphaAttachmentThreshold
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Animation Animation
	{
		 get { } //Length: 8
	}

	public float AnimationEnd
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float AnimationLast
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float AnimationStart
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float AnimationTime
	{
		 get { } //Length: 196
	}

	public float Delay
	{
		 get { } //Length: 8
		 set { } //Length: 128
	}

	public float EventThreshold
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool HoldPrevious
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float InterruptAlpha
	{
		 get { } //Length: 8
	}

	public bool IsComplete
	{
		 get { } //Length: 24
	}

	public bool IsEmptyAnimation
	{
		 get { } //Length: 104
	}

	public bool IsNextReady
	{
		 get { } //Length: 40
	}

	public bool Loop
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float MixAttachmentThreshold
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public MixBlend MixBlend
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixDrawOrderThreshold
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixDuration
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TrackEntry MixingFrom
	{
		 get { } //Length: 8
	}

	public TrackEntry MixingTo
	{
		 get { } //Length: 8
	}

	public float MixTime
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TrackEntry Next
	{
		 get { } //Length: 8
	}

	public TrackEntry Previous
	{
		 get { } //Length: 8
	}

	public bool Reverse
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool ShortestRotation
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float TimeScale
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float TrackComplete
	{
		 get { } //Length: 100
	}

	public float TrackEnd
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int TrackIndex
	{
		 get { } //Length: 8
	}

	public float TrackTime
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool WasApplied
	{
		 get { } //Length: 20
	}

	public TrackEntry() { }

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

	public void AllowImmediateQueue() { }

	public float get_Alpha() { }

	public float get_AlphaAttachmentThreshold() { }

	public Animation get_Animation() { }

	public float get_AnimationEnd() { }

	public float get_AnimationLast() { }

	public float get_AnimationStart() { }

	public float get_AnimationTime() { }

	public float get_Delay() { }

	public float get_EventThreshold() { }

	public bool get_HoldPrevious() { }

	public float get_InterruptAlpha() { }

	public bool get_IsComplete() { }

	public bool get_IsEmptyAnimation() { }

	public bool get_IsNextReady() { }

	public bool get_Loop() { }

	public float get_MixAttachmentThreshold() { }

	public MixBlend get_MixBlend() { }

	public float get_MixDrawOrderThreshold() { }

	public float get_MixDuration() { }

	public TrackEntry get_MixingFrom() { }

	public TrackEntry get_MixingTo() { }

	public float get_MixTime() { }

	public TrackEntry get_Next() { }

	public TrackEntry get_Previous() { }

	public bool get_Reverse() { }

	public bool get_ShortestRotation() { }

	public float get_TimeScale() { }

	public float get_TrackComplete() { }

	public float get_TrackEnd() { }

	public int get_TrackIndex() { }

	public float get_TrackTime() { }

	public bool get_WasApplied() { }

	internal void OnComplete() { }

	internal void OnDispose() { }

	internal void OnEnd() { }

	internal void OnEvent(Event e) { }

	internal void OnInterrupt() { }

	internal void OnStart() { }

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

	public override void Reset() { }

	public void ResetRotationDirections() { }

	public void set_Alpha(float value) { }

	public void set_AlphaAttachmentThreshold(float value) { }

	public void set_AnimationEnd(float value) { }

	public void set_AnimationLast(float value) { }

	public void set_AnimationStart(float value) { }

	public void set_Delay(float value) { }

	public void set_EventThreshold(float value) { }

	public void set_HoldPrevious(bool value) { }

	public void set_Loop(bool value) { }

	public void set_MixAttachmentThreshold(float value) { }

	public void set_MixBlend(MixBlend value) { }

	public void set_MixDrawOrderThreshold(float value) { }

	public void set_MixDuration(float value) { }

	public void set_MixTime(float value) { }

	public void set_Reverse(bool value) { }

	public void set_ShortestRotation(bool value) { }

	public void set_TimeScale(float value) { }

	public void set_TrackEnd(float value) { }

	public void set_TrackTime(float value) { }

	public void SetMixDuration(float mixDuration, float delay) { }

	public virtual string ToString() { }

}

