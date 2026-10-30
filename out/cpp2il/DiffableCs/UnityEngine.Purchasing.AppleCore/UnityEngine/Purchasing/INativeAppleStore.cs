namespace UnityEngine.Purchasing;

internal interface INativeAppleStore : INativeStore
{

	public string appReceipt
	{
		 get { } //Length: 0
	}

	public double appReceiptModificationDate
	{
		 get { } //Length: 0
	}

	public bool canMakePayments
	{
		 get { } //Length: 0
	}

	public bool simulateAskToBuy
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public void AddTransactionObserver() { }

	public void ContinuePromotionalPurchases() { }

	public void FetchStorePromotionOrder() { }

	public void FetchStorePromotionVisibility(string productId) { }

	public string get_appReceipt() { }

	public double get_appReceiptModificationDate() { }

	public bool get_canMakePayments() { }

	public bool get_simulateAskToBuy() { }

	public string GetTransactionReceiptForProductId(string productId) { }

	public void InterceptPromotionalPurchases() { }

	public void PresentCodeRedemptionSheet() { }

	public void RefreshAppReceipt() { }

	public void RestoreTransactions() { }

	public void set_simulateAskToBuy(bool value) { }

	public void SetApplicationUsername(string applicationUsername) { }

	public void SetStorePromotionOrder(string json) { }

	public void SetStorePromotionVisibility(string productId, string visibility) { }

	public void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback) { }

}

