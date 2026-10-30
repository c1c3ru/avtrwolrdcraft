namespace PazuCore;

public class ScreenLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public AsyncOperation async; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal bool <StartNoneAnimation>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public AsyncOperation async; //Field offset: 0x10
		public ScreenLoader <>4__this; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal bool <StartSlideAnimation>b__0() { }

		internal void <StartSlideAnimation>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <StartNoneAnimation>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AsyncOperation async; //Field offset: 0x20
		public ScreenLoader <>4__this; //Field offset: 0x28

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
		public <StartNoneAnimation>d__22(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <StartSlideAnimation>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AsyncOperation async; //Field offset: 0x20
		public ScreenLoader <>4__this; //Field offset: 0x28
		public ScreenTransitionDirection direction; //Field offset: 0x30
		public float duration; //Field offset: 0x34
		private <>c__DisplayClass23_0 <>8__1; //Field offset: 0x38
		private RectTransform <currentScreen>5__2; //Field offset: 0x40
		private RenderMode <currentCanvasRenderMode>5__3; //Field offset: 0x48

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
		public <StartSlideAnimation>d__23(int <>1__state) { }

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

	public static ScreenLoader instance; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<GameObject> OnStartLoadingScreenCallback; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<GameObject> OnEndLoadingScreenCallback; //Field offset: 0x10
	[CompilerGenerated]
	private bool <IsLoadingScreen>k__BackingField; //Field offset: 0x20
	private Canvas currentCanvas; //Field offset: 0x28
	private Canvas nextCanvas; //Field offset: 0x30
	private GameObject objectToMove; //Field offset: 0x38
	private AsyncOperation async; //Field offset: 0x40

	public static event Action<GameObject> OnEndLoadingScreenCallback
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<GameObject> OnStartLoadingScreenCallback
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private bool IsLoadingScreen
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public float Progress
	{
		 get { } //Length: 24
	}

	public ScreenLoader() { }

	[CompilerGenerated]
	public static void add_OnEndLoadingScreenCallback(Action<GameObject> value) { }

	[CompilerGenerated]
	public static void add_OnStartLoadingScreenCallback(Action<GameObject> value) { }

	private void Awake() { }

	public void DidEndLoadingScreen() { }

	[CompilerGenerated]
	public bool get_IsLoadingScreen() { }

	public float get_Progress() { }

	private Canvas getCurrentCanvas() { }

	public void MoveToScene(string sceneName, ScreenTransitionDirection direction, float duration = 0, ScreenTransition screenTransition = 0, GameObject objectToMove = null) { }

	public void MoveToScene(int sceneIndex, float duration = 0, ScreenTransition screenTransition = 0, GameObject objectToMove = null) { }

	private void MoveToSceneInternal(object sceneIdentifier, float duration = 0, ScreenTransition screenTransition = 0, GameObject objectToMove = null, ScreenTransitionDirection direction = 1) { }

	[CompilerGenerated]
	public static void remove_OnEndLoadingScreenCallback(Action<GameObject> value) { }

	[CompilerGenerated]
	public static void remove_OnStartLoadingScreenCallback(Action<GameObject> value) { }

	[CompilerGenerated]
	private void set_IsLoadingScreen(bool value) { }

	[IteratorStateMachine(typeof(<StartNoneAnimation>d__22))]
	private IEnumerator StartNoneAnimation(AsyncOperation async) { }

	[IteratorStateMachine(typeof(<StartSlideAnimation>d__23))]
	private IEnumerator StartSlideAnimation(float duration, ScreenTransitionDirection direction, AsyncOperation async) { }

}

