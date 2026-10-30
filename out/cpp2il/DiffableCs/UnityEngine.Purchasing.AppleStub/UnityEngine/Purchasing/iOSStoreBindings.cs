namespace UnityEngine.Purchasing;

internal class iOSStoreBindings : INativeAppleStore, INativeStore
{

	public override string appReceipt
	{
		 get { } //Length: 56
	}

	public override double appReceiptModificationDate
	{
		 get { } //Length: 56
	}

	public override bool canMakePayments
	{
		 get { } //Length: 56
	}

	public override bool simulateAskToBuy
	{
		 get { } //Length: 56
		 set { } //Length: 56
	}

	public iOSStoreBindings() { }

	public override void AddTransactionObserver() { }

	public override void ContinuePromotionalPurchases() { }

	public override void FetchStorePromotionOrder() { }

	public override void FetchStorePromotionVisibility(string productId) { }

	public override void FinishTransaction(string productJSON, string transactionID) { }

	public override string get_appReceipt() { }

	public override double get_appReceiptModificationDate() { }

	public override bool get_canMakePayments() { }

	public override bool get_simulateAskToBuy() { }

	public override string GetTransactionReceiptForProductId(string productId) { }

	public override void InterceptPromotionalPurchases() { }

	public override void PresentCodeRedemptionSheet() { }

	public override void Purchase(string productJSON, string developerPayload) { }

	public override void RefreshAppReceipt() { }

	public override void RestoreTransactions() { }

	public override void RetrieveProducts(string json) { }

	public override void set_simulateAskToBuy(bool value) { }

	public override void SetApplicationUsername(string applicationUsername) { }

	public override void SetStorePromotionOrder(string json) { }

	public override void SetStorePromotionVisibility(string productId, string visibility) { }

	public override void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback) { }

}

