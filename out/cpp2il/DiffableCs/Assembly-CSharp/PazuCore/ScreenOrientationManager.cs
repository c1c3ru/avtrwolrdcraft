namespace PazuCore;

public class ScreenOrientationManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__32_0; //Field offset: 0x8
		public static Action<Boolean> <>9__36_1; //Field offset: 0x10
		public static Action<Boolean> <>9__37_1; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <CheckForChange>b__32_0() { }

		internal void <EnterOrientation>b__36_1(bool success) { }

		internal void <ReturnToGameOrientationIfNeeded>b__37_1(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <CheckForChange>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScreenOrientationManager <>4__this; //Field offset: 0x20

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
		public <CheckForChange>d__32(int <>1__state) { }

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
	private sealed class <WaitForOrientationIfNeeded>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public bool portrait; //Field offset: 0x20
		public ScreenOrientationManager <>4__this; //Field offset: 0x28
		public Action<Boolean> onFinish; //Field offset: 0x30
		public bool keepCover; //Field offset: 0x38
		private float <safeTimer>5__2; //Field offset: 0x3C

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
		public <WaitForOrientationIfNeeded>d__38(int <>1__state) { }

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
	private static Action<DeviceOrientation> OnOrientationChange; //Field offset: 0x0
	[CompilerGenerated]
	private static ScreenOrientationManager <Instance>k__BackingField; //Field offset: 0x8
	private static ReadOnlyCollection<DeviceOrientation> _ignoreOrientations; //Field offset: 0x10
	[SerializeField]
	private GameObject _cover; //Field offset: 0x20
	[CompilerGenerated]
	private ScreenOrientation <GameScreenOrientation>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ScreenOrientation <CurrentScreenOrientation>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	private ScreenType <GameScreenType>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Vector2Int <GameResolution>k__BackingField; //Field offset: 0x34
	private bool _isOutOfGameOrientation; //Field offset: 0x3C
	private bool _isBusy; //Field offset: 0x3D
	private bool _autorotateToPortrait; //Field offset: 0x3E
	private bool _autorotateToPortraitUpsideDown; //Field offset: 0x3F
	private bool _autorotateToLandscapeLeft; //Field offset: 0x40
	private bool _autorotateToLandscapeRight; //Field offset: 0x41

	public static event Action<DeviceOrientation> OnOrientationChange
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private ScreenOrientation CurrentScreenOrientation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private Vector2Int GameResolution
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private ScreenOrientation GameScreenOrientation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private ScreenType GameScreenType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static ScreenOrientationManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public ScreenOrientationManager() { }

	[CompilerGenerated]
	private void <EnterOrientation>b__36_0(bool success) { }

	[CompilerGenerated]
	private void <ReturnToGameOrientationIfNeeded>b__37_0(bool success) { }

	[CompilerGenerated]
	public static void add_OnOrientationChange(Action<DeviceOrientation> value) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<CheckForChange>d__32))]
	private IEnumerator CheckForChange() { }

	public void EnterLandscape(Action<Boolean> onFinish, bool keepCover = false) { }

	public void EnterOrientation(bool portrait, Action<Boolean> onFinish, bool keepCover = false) { }

	public void EnterPortrait(Action<Boolean> onFinish, bool keepCover = false) { }

	[CompilerGenerated]
	public ScreenOrientation get_CurrentScreenOrientation() { }

	[CompilerGenerated]
	public Vector2Int get_GameResolution() { }

	[CompilerGenerated]
	public ScreenOrientation get_GameScreenOrientation() { }

	[CompilerGenerated]
	public ScreenType get_GameScreenType() { }

	[CompilerGenerated]
	public static ScreenOrientationManager get_Instance() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnOrientationChange(Action<DeviceOrientation> value) { }

	public void ReturnToGameOrientationIfNeeded(Action<Boolean> onFinish) { }

	[CompilerGenerated]
	private void set_CurrentScreenOrientation(ScreenOrientation value) { }

	[CompilerGenerated]
	private void set_GameResolution(Vector2Int value) { }

	[CompilerGenerated]
	private void set_GameScreenOrientation(ScreenOrientation value) { }

	[CompilerGenerated]
	private void set_GameScreenType(ScreenType value) { }

	[CompilerGenerated]
	private static void set_Instance(ScreenOrientationManager value) { }

	[IteratorStateMachine(typeof(<WaitForOrientationIfNeeded>d__38))]
	private IEnumerator WaitForOrientationIfNeeded(bool portrait, Action<Boolean> onFinish, bool keepCover = false) { }

}

