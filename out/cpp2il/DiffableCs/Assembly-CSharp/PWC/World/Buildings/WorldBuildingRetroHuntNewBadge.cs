namespace PWC.World.Buildings;

public class WorldBuildingRetroHuntNewBadge : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <Start>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldBuildingRetroHuntNewBadge <>4__this; //Field offset: 0x20

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
		public <Start>d__6(int <>1__state) { }

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

	private const string SERVER_HUNT_DATA_RESOURCES_PATH = "Achievements/SeverDependentHunts"; //Field offset: 0x0
	private static HuntData[] _serverHunts; //Field offset: 0x0
	[SerializeField]
	private WorldBuildingType _buildingType; //Field offset: 0x20
	[SerializeField]
	private GameObject _view; //Field offset: 0x28
	private WorldBuilding _trackedBuilding; //Field offset: 0x30
	private string _activeHuntGuid; //Field offset: 0x38

	public WorldBuildingRetroHuntNewBadge() { }

	private void Dismiss() { }

	private string GetDismissedKey(string huntGuid) { }

	private void OnBuildingEntered(WorldBuilding building, LevelType levelType) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<Start>d__6))]
	private IEnumerator Start() { }

}

