namespace Game.Level;

public class LevelMultiPrefabPeriodicSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PeriodicSpawnCoroutine>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelMultiPrefabPeriodicSpawner <>4__this; //Field offset: 0x20

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
		public <PeriodicSpawnCoroutine>d__15(int <>1__state) { }

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
	private bool _isRandomPrefabs; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference[] _prefabReferences; //Field offset: 0x28
	[SerializeField]
	private float _minTimePeriod; //Field offset: 0x30
	[SerializeField]
	private float _maxTimePeriod; //Field offset: 0x34
	[SerializeField]
	private bool _isRandomSpawnPoints; //Field offset: 0x38
	[SerializeField]
	private Transform[] _spawnPoints; //Field offset: 0x40
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x48
	[SerializeField]
	private int _maxInstances; //Field offset: 0x50
	private int _nextPrefabIndex; //Field offset: 0x54
	private int _nextPoisitionIndex; //Field offset: 0x58
	private Random _random; //Field offset: 0x60
	private MPPlayerGuid _multiplayer_MPGuidGenerator; //Field offset: 0x68

	public LevelMultiPrefabPeriodicSpawner() { }

	private void Awake() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<PeriodicSpawnCoroutine>d__15))]
	private IEnumerator PeriodicSpawnCoroutine() { }

	private void Spawn() { }

}

