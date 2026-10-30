namespace PWC.GamePopups;

public class RefundGamePopup : GamePopup
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string op; //Field offset: 0x10
		public RefundGamePopup <>4__this; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <OnButtonPress>b__0(string respoonseText) { }

	}

	private const string FAILED_MESSAGE = "We couldn't add the Coins to your account"; //Field offset: 0x0
	private PackCurrencyRefundable _refundableData; //Field offset: 0x48
	private Action _onRefundSuccess; //Field offset: 0x50
	private bool _isTweenActive; //Field offset: 0x58

	public RefundGamePopup() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(bool value) { }

	protected virtual void Awake() { }

	public void InitRefundPopup(PackCurrencyRefundable refundableData, Action onRefundSuccess) { }

	public virtual void OnButtonPress(bool value) { }

}

