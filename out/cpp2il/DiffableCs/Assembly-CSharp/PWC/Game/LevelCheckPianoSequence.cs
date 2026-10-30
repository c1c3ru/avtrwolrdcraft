namespace PWC.Game;

public class LevelCheckPianoSequence : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <SolvedPlay>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCheckPianoSequence <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <SolvedPlay>d__16(int <>1__state) { }

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

	private const float TIME_BETWEEN_NOTES = 0,2; //Field offset: 0x0
	[SerializeField]
	private bool _isSolveableMultipleTimes; //Field offset: 0x20
	[SerializeField]
	private LevelPiano _piano; //Field offset: 0x28
	[SerializeField]
	private Int32[] _secretCode; //Field offset: 0x30
	[SerializeField]
	private LevelToggleableGameObject[] _lights; //Field offset: 0x38
	[SerializeField]
	[Space]
	private UnityEvent _solvedEvents; //Field offset: 0x40
	private bool _isSolved; //Field offset: 0x48
	private int _currentIndex; //Field offset: 0x4C
	private readonly WaitForSeconds _waitBetweenNotes; //Field offset: 0x50

	public LevelCheckPianoSequence() { }

	private void Awake() { }

	private void EnsureLightsOffIfSolved(Scene scene) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPianoKeyClicked(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	[IteratorStateMachine(typeof(<SolvedPlay>d__16))]
	private IEnumerator SolvedPlay() { }

	private void TurnOffAllLights() { }

	private void TurnOnNextLight() { }

}

