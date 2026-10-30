namespace Game.Level;

public class LevelShower : LevelDrinkDispenser
{
	[CompilerGenerated]
	private sealed class <SpawnPuddles>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelShower <>4__this; //Field offset: 0x20

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
		public <SpawnPuddles>d__8(int <>1__state) { }

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
	private LevelDoor _door; //Field offset: 0xA0
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0xA8
	[SerializeField]
	private RectTransform _puddlesArea; //Field offset: 0xB0
	[SerializeField]
	private LevelSpawn _puddlePrefab; //Field offset: 0xB8

	public LevelShower() { }

	protected virtual void Awake() { }

	private Vector2 GetPuddleSpawnPoint() { }

	protected virtual void OnDestroy() { }

	private void OnDoorChangeState(bool isOpen) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<SpawnPuddles>d__8))]
	private IEnumerator SpawnPuddles() { }

}

