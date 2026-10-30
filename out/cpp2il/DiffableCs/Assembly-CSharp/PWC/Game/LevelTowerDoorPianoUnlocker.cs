namespace PWC.Game;

public class LevelTowerDoorPianoUnlocker : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <OpenDoor>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTowerDoorPianoUnlocker <>4__this; //Field offset: 0x20
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
		public <OpenDoor>d__17(int <>1__state) { }

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
	private bool _onceUnlockedKeepUnlocked; //Field offset: 0x20
	[SerializeField]
	private GameObject _door; //Field offset: 0x28
	[SerializeField]
	private LevelPiano _piano; //Field offset: 0x30
	[SerializeField]
	private Int32[] _secretCode; //Field offset: 0x38
	[SerializeField]
	private LevelToggleableGameObject[] _lights; //Field offset: 0x40
	[SerializeField]
	private float _openHeight; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	[Space]
	private UnityEvent _onDoorUnlockededEvent; //Field offset: 0x58
	private bool _isUnlocked; //Field offset: 0x60
	private int _currentIndex; //Field offset: 0x64
	private readonly WaitForSeconds _waitBetweenNotes; //Field offset: 0x68

	public LevelTowerDoorPianoUnlocker() { }

	[CompilerGenerated]
	private void <OpenDoor>b__17_0() { }

	private void Awake() { }

	private void EnsureLightsOffIfLocked(Scene scene) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPianoKeyClicked(int index) { }

	[IteratorStateMachine(typeof(<OpenDoor>d__17))]
	private IEnumerator OpenDoor() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TurnOffAllLights() { }

	private void TurnOnNextLight() { }

}

