namespace PazuCore;

public class HomeLayout : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__15_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Start>b__15_0() { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public HomeLayout <>4__this; //Field offset: 0x20
		private float <safeTimer>5__2; //Field offset: 0x28

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
		public <Start>d__15(int <>1__state) { }

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
	private static HomeLayout <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GameObject prefab; //Field offset: 0x20
	private HomeButtonsCanvas _homeButtonsCanvas; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsClearBottomRightCalled>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsClearBottomLeftCalled>k__BackingField; //Field offset: 0x31

	public private static HomeLayout Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsClearBottomLeftCalled
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsClearBottomRightCalled
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public HomeLayout() { }

	private void Awake() { }

	public void ClearBottomLeft() { }

	public void ClearBottomRight() { }

	[CompilerGenerated]
	public static HomeLayout get_Instance() { }

	[CompilerGenerated]
	public bool get_IsClearBottomLeftCalled() { }

	[CompilerGenerated]
	public bool get_IsClearBottomRightCalled() { }

	public void Hide() { }

	public void HideAndDestroy() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(HomeLayout value) { }

	[CompilerGenerated]
	private void set_IsClearBottomLeftCalled(bool value) { }

	[CompilerGenerated]
	private void set_IsClearBottomRightCalled(bool value) { }

	private void SetCanvasVisible(bool visible) { }

	public void Show() { }

	[IteratorStateMachine(typeof(<Start>d__15))]
	private IEnumerator Start() { }

}

