namespace UnityEngine.Purchasing;

public class AmazonAppStoreStoreExtensions : IAmazonExtensions, IStoreExtension, IAmazonConfiguration, IStoreConfiguration
{
	private readonly AndroidJavaObject android; //Field offset: 0x10

	public override string amazonUserId
	{
		 get { } //Length: 208
	}

	public AmazonAppStoreStoreExtensions(AndroidJavaObject a) { }

	public override string get_amazonUserId() { }

	public override void NotifyUnableToFulfillUnavailableProduct(string transactionID) { }

	public override void WriteSandboxJSON(HashSet<ProductDefinition> products) { }

}

