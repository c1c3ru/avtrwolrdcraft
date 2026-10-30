namespace UnityEngine.Video;

[NativeHeader("Modules/Video/Public/VideoPlayer.h")]
[RequireComponent(typeof(Transform))]
[RequiredByNativeCode]
public sealed class VideoPlayer : Behaviour
{
	internal sealed class ErrorEventHandler : MulticastDelegate
	{

		public ErrorEventHandler(object object, IntPtr method) { }

		public override void Invoke(VideoPlayer source, string message) { }

	}

	internal sealed class EventHandler : MulticastDelegate
	{

		public EventHandler(object object, IntPtr method) { }

		public override void Invoke(VideoPlayer source) { }

	}

	internal sealed class FrameReadyEventHandler : MulticastDelegate
	{

		public FrameReadyEventHandler(object object, IntPtr method) { }

		public override void Invoke(VideoPlayer source, long frameIdx) { }

	}

	internal sealed class TimeEventHandler : MulticastDelegate
	{

		public TimeEventHandler(object object, IntPtr method) { }

		public override void Invoke(VideoPlayer source, double seconds) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler prepareCompleted; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler loopPointReached; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler started; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler frameDropped; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ErrorEventHandler errorReceived; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler seekCompleted; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private TimeEventHandler clockResyncOccurred; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private FrameReadyEventHandler frameReady; //Field offset: 0x50

	public event ErrorEventHandler errorReceived
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event EventHandler loopPointReached
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event EventHandler prepareCompleted
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event EventHandler started
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	[NativeName("VideoClip")]
	public VideoClip clip
	{
		 set { } //Length: 68
	}

	public bool isPlaying
	{
		[NativeName("IsPlaying")]
		 get { } //Length: 60
	}

	public bool isPrepared
	{
		[NativeName("IsPrepared")]
		 get { } //Length: 60
	}

	public VideoSource source
	{
		 set { } //Length: 68
	}

	[NativeHeader("Runtime/Graphics/Texture.h")]
	public Texture texture
	{
		 get { } //Length: 60
	}

	[NativeName("VideoUrl")]
	public string url
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public VideoPlayer() { }

	[CompilerGenerated]
	public void add_errorReceived(ErrorEventHandler value) { }

	[CompilerGenerated]
	public void add_loopPointReached(EventHandler value) { }

	[CompilerGenerated]
	public void add_prepareCompleted(EventHandler value) { }

	[CompilerGenerated]
	public void add_started(EventHandler value) { }

	[NativeName("IsPlaying")]
	public bool get_isPlaying() { }

	[NativeName("IsPrepared")]
	public bool get_isPrepared() { }

	public Texture get_texture() { }

	public string get_url() { }

	public bool GetDirectAudioMute(ushort trackIndex) { }

	[RequiredByNativeCode]
	private static void InvokeClockResyncOccurredCallback_Internal(VideoPlayer source, double seconds) { }

	[RequiredByNativeCode]
	private static void InvokeErrorReceivedCallback_Internal(VideoPlayer source, string errorStr) { }

	[RequiredByNativeCode]
	private static void InvokeFrameDroppedCallback_Internal(VideoPlayer source) { }

	[RequiredByNativeCode]
	private static void InvokeFrameReadyCallback_Internal(VideoPlayer source, long frameIdx) { }

	[RequiredByNativeCode]
	private static void InvokeLoopPointReachedCallback_Internal(VideoPlayer source) { }

	[RequiredByNativeCode]
	private static void InvokePrepareCompletedCallback_Internal(VideoPlayer source) { }

	[RequiredByNativeCode]
	private static void InvokeSeekCompletedCallback_Internal(VideoPlayer source) { }

	[RequiredByNativeCode]
	private static void InvokeStartedCallback_Internal(VideoPlayer source) { }

	public void Pause() { }

	public void Play() { }

	public void Prepare() { }

	[CompilerGenerated]
	public void remove_errorReceived(ErrorEventHandler value) { }

	[CompilerGenerated]
	public void remove_loopPointReached(EventHandler value) { }

	[CompilerGenerated]
	public void remove_prepareCompleted(EventHandler value) { }

	[CompilerGenerated]
	public void remove_started(EventHandler value) { }

	public void set_clip(VideoClip value) { }

	public void set_source(VideoSource value) { }

	public void set_url(string value) { }

	public void SetDirectAudioMute(ushort trackIndex, bool mute) { }

}

