namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class GoogleFinishTransactionService : IGoogleFinishTransactionService
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		[Nullable(0)]
		public string purchaseToken; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		[NullableContext(0)]
		internal bool <FindPurchase>b__0(IGooglePurchase purchase) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		public Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished; //Field offset: 0x10
		[Nullable(0)]
		public IGooglePurchase purchase; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		[NullableContext(0)]
		internal void <FinishTransactionForPurchase>b__0(IGoogleBillingResult result) { }

		[NullableContext(0)]
		internal void <FinishTransactionForPurchase>b__1(IGoogleBillingResult result) { }

	}

	[CompilerGenerated]
	private struct <FindPurchase>d__4 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		[Nullable(0)]
		public AsyncTaskMethodBuilder<IGooglePurchase> <>t__builder; //Field offset: 0x8
		[Nullable(0)]
		public string purchaseToken; //Field offset: 0x20
		[Nullable(0)]
		public GoogleFinishTransactionService <>4__this; //Field offset: 0x28
		[Nullable(0)]
		private <>c__DisplayClass4_0 <>8__1; //Field offset: 0x30
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		private TaskAwaiter<List`1<IGooglePurchase>> <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <FinishTransaction>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		[Nullable(0)]
		public GoogleFinishTransactionService <>4__this; //Field offset: 0x28
		[Nullable(0)]
		public string purchaseToken; //Field offset: 0x30
		[Nullable(0)]
		public ProductDefinition product; //Field offset: 0x38
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1, 1})]
		public Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished; //Field offset: 0x40
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		private TaskAwaiter<IGooglePurchase> <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private readonly IGoogleBillingClient m_BillingClient; //Field offset: 0x10
	private readonly IGoogleQueryPurchasesService m_GoogleQueryPurchasesService; //Field offset: 0x18

	internal GoogleFinishTransactionService(IGoogleBillingClient billingClient, IGoogleQueryPurchasesService googleQueryPurchasesService) { }

	[AsyncStateMachine(typeof(<FindPurchase>d__4))]
	private Task<IGooglePurchase> FindPurchase(string purchaseToken) { }

	[AsyncStateMachine(typeof(<FinishTransaction>d__3))]
	public override void FinishTransaction(ProductDefinition product, string purchaseToken, Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished) { }

	private void FinishTransactionForPurchase(IGooglePurchase purchase, ProductDefinition product, string purchaseToken, Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished) { }

}

