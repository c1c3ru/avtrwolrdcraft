namespace UnityEngine.Purchasing;

[Nullable(0)]
[NullableContext(1)]
internal class FakeAppleConfiguration : IAppleConfiguration, IStoreConfiguration
{

	public override string appReceipt
	{
		 get { } //Length: 64
	}

	public override bool canMakePayments
	{
		 get { } //Length: 8
	}

	public FakeAppleConfiguration() { }

	public override string get_appReceipt() { }

	public override bool get_canMakePayments() { }

	public override void SetApplePromotionalPurchaseInterceptorCallback(Action<Product> callback) { }

	public override void SetEntitlementsRevokedListener(Action<List`1<Product>> callback) { }

}

