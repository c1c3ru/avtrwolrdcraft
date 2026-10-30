namespace Game.Level.TimedLocker;

public class LevelTimedLocker : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <UpdateTimer>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTimedLocker <>4__this; //Field offset: 0x20

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
		public <UpdateTimer>d__12(int <>1__state) { }

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
	private LevelDoor _lockerDoor; //Field offset: 0x20
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _giftReadySprite; //Field offset: 0x30
	[SerializeField]
	private int _interval; //Field offset: 0x38
	private DateTime _startingTime; //Field offset: 0x40
	private bool _isTimerRunning; //Field offset: 0x48
	private bool _hasPersistentData; //Field offset: 0x49

	public LevelTimedLocker() { }

	private void Awake() { }

	public bool CanOpenDoor() { }

	private void DisplayTime(TimeSpan timeToDisplay) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void ResetTimer() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StartTimer() { }

	[IteratorStateMachine(typeof(<UpdateTimer>d__12))]
	private IEnumerator UpdateTimer() { }

}

