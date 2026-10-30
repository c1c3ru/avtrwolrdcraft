namespace Game.Level.Arcade.ClawMachine;

public class LevelClawMachine : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IArcadePlayable
{
	[CompilerGenerated]
	private sealed class <PlayLightsSequence>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelClawMachine <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28
		private int <j>5__3; //Field offset: 0x2C

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
		public <PlayLightsSequence>d__19(int <>1__state) { }

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
	private LevelClawMachineClaw _claw; //Field offset: 0x20
	[SerializeField]
	private LevelButton _leftButton; //Field offset: 0x28
	[SerializeField]
	private LevelButton _rightButton; //Field offset: 0x30
	[SerializeField]
	private LevelButton _pushButton; //Field offset: 0x38
	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x40
	[SerializeField]
	private LevelSpawner _candySpawner; //Field offset: 0x48
	[SerializeField]
	private LevelSpawner _toySpawner; //Field offset: 0x50
	[SerializeField]
	private Transform[] _spawnPoints; //Field offset: 0x58
	[SerializeField]
	private ToysToSpawn[] _toysToSpawn; //Field offset: 0x60
	[SerializeField]
	private PDPrefabReference[] _candiesToSpawn; //Field offset: 0x68
	[SerializeField]
	private LevelLight[] _machineLights; //Field offset: 0x70
	[SerializeField]
	private bool _shouldSpawn; //Field offset: 0x78
	private int _currentWave; //Field offset: 0x7C

	public LevelClawMachine() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void Play() { }

	private void PlayLights() { }

	[IteratorStateMachine(typeof(<PlayLightsSequence>d__19))]
	private IEnumerator PlayLightsSequence() { }

	public void SetAllButtonsState(bool newState) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SpawnAllToys(int wave) { }

	private void SpawnToysIfNeeded() { }

}

