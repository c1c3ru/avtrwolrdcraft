namespace UnityEngine.Purchasing;

internal sealed class UnityPurchasingCallback : MulticastDelegate
{

	public UnityPurchasingCallback(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(string subject, string payload, string receipt, string transactionId, string originalTransactionId, bool isRestored, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(string subject, string payload, string receipt, string transactionId, string originalTransactionId, bool isRestored) { }

}

