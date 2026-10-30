namespace PWC.World.Buildings;

public class WorldBuildingStorageUnitIndicator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldBuildingStorageUnitIndicator <>4__this; //Field offset: 0x20
		private bool <shouldBeVisible>5__2; //Field offset: 0x28

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
		public <Start>d__4(int <>1__state) { }

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

	public const string PD_KEY = "WorldBuildingStorageUnitIndicator"; //Field offset: 0x0
	[SerializeField]
	private GameObject _view; //Field offset: 0x20
	[SerializeField]
	private WorldBuilding _building; //Field offset: 0x28

	public WorldBuildingStorageUnitIndicator() { }

	private void Awake() { }

	private void OnClickBuilding(WorldBuilding building, LevelType levelType) { }

	private void OnDestroy() { }

	[IteratorStateMachine(typeof(<Start>d__4))]
	private IEnumerator Start() { }

}

