namespace UnityEngine.Purchasing;

public class FakeAmazonExtensions : IAmazonExtensions, IStoreExtension, IAmazonConfiguration, IStoreConfiguration
{

	public override string amazonUserId
	{
		 get { } //Length: 64
	}

	public FakeAmazonExtensions() { }

	public override string get_amazonUserId() { }

	public override void NotifyUnableToFulfillUnavailableProduct(string transactionID) { }

	public override void WriteSandboxJSON(HashSet<ProductDefinition> products) { }

}

