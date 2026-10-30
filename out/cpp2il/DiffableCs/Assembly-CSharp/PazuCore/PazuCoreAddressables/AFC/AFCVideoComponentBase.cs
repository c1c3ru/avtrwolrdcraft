namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCVideoComponentBase : AFCUnityMessageDrivenHandlerBase
{
	[CompilerGenerated]
	private sealed class <PlayVideoCoroutine>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AFCVideoComponentBase <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <PlayVideoCoroutine>d__13(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	protected VideoComponent _videoComponent; //Field offset: 0x28
	[SerializeField]
	private VideoPlayer _videoPlayer; //Field offset: 0x30
	[SerializeField]
	private bool _isPlayWhenPrepared; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onLoadSuccess; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onLoadFailed; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onEndPointReach; //Field offset: 0x50
	protected string _url; //Field offset: 0x58
	private bool _didSetEndPointReachedEvent; //Field offset: 0x60

	protected AFCVideoComponentBase() { }

	[CompilerGenerated]
	private void <LoadVideoFromUrl>b__11_0(bool success) { }

	[CompilerGenerated]
	private bool <PlayVideoCoroutine>b__13_0() { }

	private void EnsureEndPointReachedEvent() { }

	public abstract void LoadVideo() { }

	protected void LoadVideoFromUrl(string url) { }

	protected virtual void OnDestroy() { }

	private void OnEndPointReached(VideoPlayer source) { }

	public virtual void PerformAction() { }

	public void PlayVideo() { }

	[IteratorStateMachine(typeof(<PlayVideoCoroutine>d__13))]
	private IEnumerator PlayVideoCoroutine() { }

}

