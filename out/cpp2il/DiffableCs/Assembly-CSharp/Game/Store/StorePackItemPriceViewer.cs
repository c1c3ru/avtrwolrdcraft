namespace Game.Store;

public class StorePackItemPriceViewer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadPrice>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string productName; //Field offset: 0x20
		public StorePackItemPriceViewer <>4__this; //Field offset: 0x28
		private string <price>5__2; //Field offset: 0x30

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
		public <LoadPrice>d__14(int <>1__state) { }

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
	private GameObject _priceBadge; //Field offset: 0x20
	[SerializeField]
	private Text _priceText; //Field offset: 0x28
	[SerializeField]
	private Text _isoCodeText; //Field offset: 0x30
	[SerializeField]
	private GameObject _pazuCurrencyIcon; //Field offset: 0x38
	[SerializeField]
	private Text _discountOriginalPriceText; //Field offset: 0x40
	[SerializeField]
	private GameObject[] _discountGameObjects; //Field offset: 0x48
	[SerializeField]
	private Text _discountText; //Field offset: 0x50
	private Coroutine _loadPriceCoroutine; //Field offset: 0x58
	private Item _itemData; //Field offset: 0x60
	private AutoShrinkText _textShrinker; //Field offset: 0x68

	public StorePackItemPriceViewer() { }

	private static string GetDiscountPercentage(Discount discount) { }

	public void Hide() { }

	public void Init(Item itemData) { }

	public void InitAvatarPassMode() { }

	[IteratorStateMachine(typeof(<LoadPrice>d__14))]
	private IEnumerator LoadPrice(string productName) { }

	private void SetPriceText(string text) { }

}

