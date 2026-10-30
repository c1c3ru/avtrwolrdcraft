namespace Game.Home;

public class GameAchievementsButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <Start>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameAchievementsButton <>4__this; //Field offset: 0x20

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
		public <Start>d__5(int <>1__state) { }

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

	public const string SERVER_HUNT_DATA_RESOURCES_PATH = "Achievements/SeverDependentHunts"; //Field offset: 0x0
	[SerializeField]
	private GameObject _graphic; //Field offset: 0x20
	private HuntData[] _serverHunts; //Field offset: 0x28
	private HuntData _targetHunt; //Field offset: 0x30
	private LevelType _targetLevel; //Field offset: 0x38

	public GameAchievementsButton() { }

	protected virtual void OnClick() { }

	public void SetAutoOpenAchievementsApplication() { }

	private void SetInteractable(bool interactable) { }

	[IteratorStateMachine(typeof(<Start>d__5))]
	private IEnumerator Start() { }

}

