namespace PazuCore;

public class MoreGamesButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <LoadIcon>b__17_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public MoreGamesButton <>4__this; //Field offset: 0x10
		public LibraryGame game; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <LoadIcon>b__1(string textureName) { }

		internal void <LoadIcon>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <Init>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MoreGamesButton <>4__this; //Field offset: 0x20

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
		public <Init>d__16(int <>1__state) { }

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
	private sealed class <LoadIcon>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MoreGamesButton <>4__this; //Field offset: 0x20
		private <>c__DisplayClass17_0 <>8__1; //Field offset: 0x28

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
		public <LoadIcon>d__17(int <>1__state) { }

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
	private static Action OnClickAction; //Field offset: 0x0
	[SerializeField]
	private Type type; //Field offset: 0x20
	[SerializeField]
	private Image moreGamesImage; //Field offset: 0x28
	[SerializeField]
	private Vector2 animateInOffset; //Field offset: 0x30
	[SerializeField]
	private TextureLoading textureLoading; //Field offset: 0x38
	[SerializeField]
	private Image _logo; //Field offset: 0x40
	[SerializeField]
	private Sprite _moreGamesLogo; //Field offset: 0x48
	private bool _initOnStart; //Field offset: 0x50
	private string _usedTextureName; //Field offset: 0x58
	private CanvasGroup _canvasGroup; //Field offset: 0x60
	private LibraryGame _game; //Field offset: 0x68

	public static event Action OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public MoreGamesButton() { }

	[CompilerGenerated]
	private void <Awake>b__13_0() { }

	[CompilerGenerated]
	public static void add_OnClickAction(Action value) { }

	protected virtual void Awake() { }

	[IteratorStateMachine(typeof(<Init>d__16))]
	private IEnumerator Init() { }

	[IteratorStateMachine(typeof(<LoadIcon>d__17))]
	private IEnumerator LoadIcon() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnClickAction(Action value) { }

	private void Start() { }

}

