namespace UnityEngine.Purchasing.Interfaces;

internal interface IGoogleFinishTransactionService
{

	public void FinishTransaction(ProductDefinition product, string purchaseToken, Action<IGoogleBillingResult, IGooglePurchase> onTransactionFinished) { }

}

