namespace PazuCore.AF.Library;

public class LibraryTextureComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LibraryTextureComponent <>4__this; //Field offset: 0x10
		public Coroutine textureLoadingCoroutine; //Field offset: 0x18
		public bool alreadyInCache; //Field offset: 0x20

		public <>c__DisplayClass26_0() { }

		internal void <LoadTextureIfNeeded>b__0(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <InvisibleCheck>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LibraryTextureComponent <>4__this; //Field offset: 0x20
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
		public <InvisibleCheck>d__23(int <>1__state) { }

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
	[SerializeField]
	protected MaskableGraphic _image; //Field offset: 0x20
	[SerializeField]
	private TextureLoading _textureLoading; //Field offset: 0x28
	private string _textureUrl; //Field offset: 0x30
	private bool _didLoadTexture; //Field offset: 0x38
	private bool _isItemReady; //Field offset: 0x39
	private bool _isInsideLoadingTexturesArea; //Field offset: 0x3A
	private Coroutine _invisibleCheckCotouine; //Field offset: 0x40
	private bool _invisibleCheckCoroutineIsRunning; //Field offset: 0x48
	private string _textureName; //Field offset: 0x50
	private readonly WaitForSeconds _invisbileCheckWaitInterval; //Field offset: 0x58
	private CanvasGroup _canvasGroup; //Field offset: 0x60
	private bool _didSetTextureCalledOnce; //Field offset: 0x68

	public LibraryTextureComponent() { }

	protected override void Awake() { }

	private void FadeIn() { }

	public void FadeOut(Action onFinish) { }

	private float GetAlpha() { }

	private void HideTextureLoading() { }

	[IteratorStateMachine(typeof(<InvisibleCheck>d__23))]
	private IEnumerator InvisibleCheck() { }

	private bool IsInsideLoadingTextureArea() { }

	public void LoadTextureIfNeeded() { }

	private void OnCullStateChanged(bool state) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnFadeUpdate(float value) { }

	public void OnItemReady() { }

	private void ReleaseTexture() { }

	public void ReleaseTextureIfNeeded() { }

	public void ResetAppearanceIfNeeded() { }

	private void SetAlpha(float alpha) { }

	public void SetTexture(string textureUrl) { }

	private void ShowTextureLoading() { }

	private void StartInvisibleCheck() { }

	private void StopInvisibleCheck() { }

}

