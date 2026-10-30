namespace UnityEngine.Purchasing;

internal interface IFakeExtensions : IStoreExtension
{

	public string unavailableProductId
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string get_unavailableProductId() { }

	public void set_unavailableProductId(string value) { }

}

