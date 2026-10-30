namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPriceText : AFCLocalizedText
{
	[CompilerGenerated]
	private sealed class <GetProductInfo>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AFCPriceText <>4__this; //Field offset: 0x20
		private string <productName>5__2; //Field offset: 0x28
		private string <originalLocalizedText>5__3; //Field offset: 0x30
		private string <loadingString>5__4; //Field offset: 0x38
		private int <counter>5__5; //Field offset: 0x40
		private bool <showLoadingDots>5__6; //Field offset: 0x44
		private WaitForSeconds <waitForPrice>5__7; //Field offset: 0x48

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
		public <GetProductInfo>d__5(int <>1__state) { }

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

	private const string LAST_LOCAL_PRICE = "PazuCore_AFCPrice_LastLocalPrice"; //Field offset: 0x0
	private const string LAST_TRIAL_PERIOD = "PazuCore_AFCPrice_LastTrialPeriod"; //Field offset: 0x0
	[SerializeField]
	private string _noTrialKey; //Field offset: 0x50

	public AFCPriceText() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0() { }

	protected virtual void GetLocalizedText() { }

	[IteratorStateMachine(typeof(<GetProductInfo>d__5))]
	private IEnumerator GetProductInfo() { }

	protected virtual void OnGetLocalizedText() { }

}

