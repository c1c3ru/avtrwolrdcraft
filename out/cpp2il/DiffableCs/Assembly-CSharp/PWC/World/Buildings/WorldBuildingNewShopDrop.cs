namespace PWC.World.Buildings;

public class WorldBuildingNewShopDrop : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <Start>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldBuildingNewShopDrop <>4__this; //Field offset: 0x20
		private int <tryCounter>5__2; //Field offset: 0x28

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
		public <Start>d__8(int <>1__state) { }

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

	private enum SignType
	{
		None = 0,
		New = 1,
		LastChance = 2,
	}

	[SerializeField]
	private GameObject _newSignView; //Field offset: 0x20
	[SerializeField]
	private GameObject _lastChanceSignView; //Field offset: 0x28
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x30
	private string _lastDropName; //Field offset: 0x38
	private string _nextDropName; //Field offset: 0x40
	private long _currentTime; //Field offset: 0x48
	private ClothesDropDataMap _dataMap; //Field offset: 0x50

	public WorldBuildingNewShopDrop() { }

	private void Init() { }

	private bool IsLastChance(long endTime) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<Start>d__8))]
	private IEnumerator Start() { }

	private void UpdateSign(SignType signType) { }

}

