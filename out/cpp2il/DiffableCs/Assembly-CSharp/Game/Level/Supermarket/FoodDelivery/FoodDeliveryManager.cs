namespace Game.Level.Supermarket.FoodDelivery;

public class FoodDeliveryManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public FoodDeliveryManager <>4__this; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18
		public Action <>9__3; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass23_0() { }

		internal void <OnGameCompleted>b__0() { }

		internal void <OnGameCompleted>b__1() { }

		internal void <OnGameCompleted>b__2() { }

		internal void <OnGameCompleted>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <Timer>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FoodDeliveryManager <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <Timer>d__25(int <>1__state) { }

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
	private FoodDeliveryTimer _timer; //Field offset: 0x20
	[SerializeField]
	private FoodDeliveryItemsPreview _itemsPreview; //Field offset: 0x28
	[SerializeField]
	private FoodDeliveryDrone _drone; //Field offset: 0x30
	[SerializeField]
	private GameObject _cartIcon; //Field offset: 0x38
	[SerializeField]
	private GameObject _droneIcon; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	private PDPrefabReference[] _goodOutcomesBank; //Field offset: 0x50
	[SerializeField]
	private PDPrefabReference[] _badOutcomesBank; //Field offset: 0x58
	[SerializeField]
	private PDPrefabReference[] _itemsBank; //Field offset: 0x60
	private HashSet<String> _currentGameItemsPrefabGuids; //Field offset: 0x68
	private int _timeLeft; //Field offset: 0x70
	private bool _isGameRunning; //Field offset: 0x74
	private int _currentTimerStage; //Field offset: 0x78

	public FoodDeliveryManager() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnGameCompleted() { }

	private void OnItemEndDrop(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnItemPickUp(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void OnRequiredItemAdded(PDPrefab pdPrefab) { }

	private void OnRequiredItemRemoved(PDPrefab pdPrefab) { }

	private void OnTimeLeftChanged(int timeLeft) { }

	private void OnTimeUp() { }

	public void StartNextGame() { }

	private void SyncLevelWithGame() { }

	[IteratorStateMachine(typeof(<Timer>d__25))]
	private IEnumerator Timer() { }

}

