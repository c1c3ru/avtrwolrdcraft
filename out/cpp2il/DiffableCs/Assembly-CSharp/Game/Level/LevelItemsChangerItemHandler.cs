namespace Game.Level;

public class LevelItemsChangerItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <StartChangingIfNeeded>b__0(PDPrefabReference prefab) { }

	}

	[CompilerGenerated]
	private sealed class <Changing>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelItemsChangerItemHandler <>4__this; //Field offset: 0x20

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
		public <Changing>d__20(int <>1__state) { }

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

	private const float CHANGING_TIME = 10; //Field offset: 0x0
	[SerializeField]
	private UnityEvent _startChangingEvent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _finishChangingEvent; //Field offset: 0x28
	[FormerlySerializedAs("_pickUpChangingEvent")]
	[SerializeField]
	private UnityEvent _stopChangingEvent; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference[] _changingItemsReference; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference[] _resultItemsReference; //Field offset: 0x40
	[SerializeField]
	private LevelSingleItemDropArea _dropArea; //Field offset: 0x48
	[SerializeField]
	private LevelSpineDoor _door; //Field offset: 0x50
	[SerializeField]
	private string _changedItemSound; //Field offset: 0x58
	private LevelItem _changingItem; //Field offset: 0x60
	private int _changingItemIndex; //Field offset: 0x68

	public LevelItemsChangerItemHandler() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Changing>d__20))]
	private IEnumerator Changing() { }

	private void OnBeginSpineDoorAnimation(bool isOpen) { }

	private void OnDestroy() { }

	private void OnEndSpineDoorAnimation(bool isOpen) { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private bool StartChangingIfNeeded(LevelItem levelItem) { }

	private void StopChanging() { }

}

