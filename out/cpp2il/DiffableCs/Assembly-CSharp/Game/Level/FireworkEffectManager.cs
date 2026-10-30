namespace Game.Level;

public class FireworkEffectManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PeriodicSpawnCoroutine>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FireworkEffectManager <>4__this; //Field offset: 0x20

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
		public <PeriodicSpawnCoroutine>d__9(int <>1__state) { }

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
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference[] _prefabReferences; //Field offset: 0x28
	[SerializeField]
	private float _minTimePeriod; //Field offset: 0x30
	[SerializeField]
	private float _maxTimePeriod; //Field offset: 0x34
	[SerializeField]
	private Vector2 _minSpawnPosition; //Field offset: 0x38
	[SerializeField]
	private Vector2 _maxSpawnPosition; //Field offset: 0x40

	public FireworkEffectManager() { }

	private void Awake() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<PeriodicSpawnCoroutine>d__9))]
	private IEnumerator PeriodicSpawnCoroutine() { }

	private Vector2 RandomizeVector2() { }

}

