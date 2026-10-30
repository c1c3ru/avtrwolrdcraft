namespace Game.Store;

public class StoreClaimableItemsWidget : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreClaimableItemsWidget <>4__this; //Field offset: 0x20
		private CanvasGroup <canvasGroup>5__2; //Field offset: 0x28
		private WaitForSeconds <wait>5__3; //Field offset: 0x30

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
		public <Start>d__12(int <>1__state) { }

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

	internal enum Type
	{
		None = 0,
		Home = 1,
		World1 = 2,
		World2 = 3,
	}

	private static readonly Dictionary<Type, Int32> _widgetsIndexes; //Field offset: 0x0
	private static List<Int32> _currentlyShownItemsIndexes; //Field offset: 0x8
	[SerializeField]
	private Type _type; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Image _smallBadge; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onHaveItemsEvent; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onNoItemsEvent; //Field offset: 0x40
	[CompilerGenerated]
	private int <PackItemIndex>k__BackingField; //Field offset: 0x48

	public private int PackItemIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private static StoreClaimableItemsWidget() { }

	public StoreClaimableItemsWidget() { }

	[CompilerGenerated]
	public int get_PackItemIndex() { }

	private void HideSmallBadgeIfNeeded(Item itemData) { }

	private void InitWidget() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private void set_PackItemIndex(int value) { }

	[IteratorStateMachine(typeof(<Start>d__12))]
	private IEnumerator Start() { }

}

