namespace PWC.Level;

public class LevelNewAvatarManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <SpawnAvatar>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <OnLevelPrePostInitCoroutine>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelNewAvatarManager <>4__this; //Field offset: 0x20

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
		public <OnLevelPrePostInitCoroutine>d__18(int <>1__state) { }

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
	private sealed class <ShowRateAppWindowIfNeeded>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

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
		public <ShowRateAppWindowIfNeeded>d__23(int <>1__state) { }

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

	public static bool IsNewAvatarFromDoneButton; //Field offset: 0x0
	public static bool IsNewAvatarFromBackButton; //Field offset: 0x1
	public static SpineType SpineTypeFromMaker; //Field offset: 0x4
	[SerializeField]
	protected Transform _parent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _postInitEvent; //Field offset: 0x28
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x30
	private bool _isNewAvatarForPostInit; //Field offset: 0x34
	private bool _didConsumeDoneButtonFlags; //Field offset: 0x35
	protected LevelItem _newAvatarLevelItem; //Field offset: 0x38

	protected override bool RestoresDoneButtonFlagsOnReload
	{
		 get { } //Length: 8
	}

	public LevelNewAvatarManager() { }

	private void Awake() { }

	protected override bool get_RestoresDoneButtonFlagsOnReload() { }

	protected override void OnAvatarSpawnPostInit() { }

	protected override void OnAvatarSpawnPrePostInit() { }

	private void OnBeforeResetCurrentLevel() { }

	private void OnBeforeSceneLoadStage1() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnLevelPrePostInit() { }

	[IteratorStateMachine(typeof(<OnLevelPrePostInitCoroutine>d__18))]
	private IEnumerator OnLevelPrePostInitCoroutine() { }

	protected override void PerformNewAvatarFromBackButtonAction() { }

	private void RestoreDoneButtonFlagsIfReloadedBeforePostInit() { }

	[IteratorStateMachine(typeof(<ShowRateAppWindowIfNeeded>d__23))]
	private IEnumerator ShowRateAppWindowIfNeeded() { }

	protected override void SpawnAvatar() { }

}

