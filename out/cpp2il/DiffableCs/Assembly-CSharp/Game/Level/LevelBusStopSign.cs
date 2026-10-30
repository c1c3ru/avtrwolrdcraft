namespace Game.Level;

public class LevelBusStopSign : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <FlickerLight>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelBusStopSign <>4__this; //Field offset: 0x20

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
		public <FlickerLight>d__13(int <>1__state) { }

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

	private static Dictionary<BusType, LevelBusStopSign> _allStations; //Field offset: 0x0
	private static BusType _currentBusInStation; //Field offset: 0x8
	[SerializeField]
	private string _signClickSound; //Field offset: 0x20
	[SerializeField]
	private LevelLight _levelLight; //Field offset: 0x28
	[SerializeField]
	private BusType _busType; //Field offset: 0x30
	private LevelBus _bus; //Field offset: 0x38
	private Coroutine _flickerCoroutine; //Field offset: 0x40

	private static LevelBusStopSign() { }

	public LevelBusStopSign() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<FlickerLight>d__13))]
	private IEnumerator FlickerLight() { }

	private void OnBusLeaveStation() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public static void SetBusInStation(BusType busType) { }

	public static void UpdateAllStopSignStates() { }

	private void UpdateStationState() { }

}

