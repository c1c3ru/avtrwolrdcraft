namespace PazuCore.AF.Feed;

public class FeedTextureComponent : TextureComponent
{
	[CompilerGenerated]
	private sealed class <InvisibleCheck>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FeedTextureComponent <>4__this; //Field offset: 0x20
		private int <loopsCounter>5__2; //Field offset: 0x28

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
		public <InvisibleCheck>d__17(int <>1__state) { }

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

	private const int INVISIBLE_CHECK_INTERVAL = 1; //Field offset: 0x0
	private string _textureUrl; //Field offset: 0x38
	private bool _didLoadTexture; //Field offset: 0x40
	private bool _isItemReady; //Field offset: 0x41
	private bool _isInsideLoadingTexturesArea; //Field offset: 0x42
	private Coroutine _invisibleCheckCotouine; //Field offset: 0x48
	private bool _invisibleCheckCoroutineIsRunning; //Field offset: 0x50
	private bool _didSetTextureCalledOnce; //Field offset: 0x51
	private readonly WaitForSeconds _invisbileCheckWaitInterval; //Field offset: 0x58

	public FeedTextureComponent() { }

	[IteratorStateMachine(typeof(<InvisibleCheck>d__17))]
	private IEnumerator InvisibleCheck() { }

	private bool IsInsideLoadingTextureArea() { }

	private void LoadTextureIfNeeded() { }

	private void OnCullStateChanged(bool state) { }

	protected virtual void OnDestroy() { }

	public void OnItemReady() { }

	private void ReleaseTexture() { }

	private void ReleaseTextureIfNeeded() { }

	public void SetTexture(string textureUrl) { }

	private void StartInvisibleCheck() { }

	private void StopInvisibleCheck() { }

}

