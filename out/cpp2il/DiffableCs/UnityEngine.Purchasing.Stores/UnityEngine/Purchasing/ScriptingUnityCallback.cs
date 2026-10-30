namespace UnityEngine.Purchasing;

internal class ScriptingUnityCallback : IUnityCallback
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public ScriptingUnityCallback <>4__this; //Field offset: 0x10
		public string json; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <OnSetupFailed>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public ScriptingUnityCallback <>4__this; //Field offset: 0x10
		public string json; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <OnProductsRetrieved>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public ScriptingUnityCallback <>4__this; //Field offset: 0x10
		public string id; //Field offset: 0x18
		public string receipt; //Field offset: 0x20
		public string transactionID; //Field offset: 0x28

		public <>c__DisplayClass5_0() { }

		internal void <OnPurchaseSucceeded>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public ScriptingUnityCallback <>4__this; //Field offset: 0x10
		public string json; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <OnPurchaseFailed>b__0() { }

	}

	private readonly IUnityCallback forwardTo; //Field offset: 0x10
	private readonly IUtil util; //Field offset: 0x18

	public ScriptingUnityCallback(IUnityCallback forwardTo, IUtil util) { }

	public override void OnProductsRetrieved(string json) { }

	public override void OnPurchaseFailed(string json) { }

	public override void OnPurchaseSucceeded(string id, string receipt, string transactionID) { }

	public override void OnSetupFailed(string json) { }

}

