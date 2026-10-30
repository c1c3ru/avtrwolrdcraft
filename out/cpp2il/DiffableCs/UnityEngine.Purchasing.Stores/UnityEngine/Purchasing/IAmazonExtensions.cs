namespace UnityEngine.Purchasing;

public interface IAmazonExtensions : IStoreExtension
{

	public string amazonUserId
	{
		 get { } //Length: 0
	}

	public string get_amazonUserId() { }

	public void NotifyUnableToFulfillUnavailableProduct(string transactionID) { }

}

