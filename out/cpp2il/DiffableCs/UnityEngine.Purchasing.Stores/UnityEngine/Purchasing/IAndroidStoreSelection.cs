namespace UnityEngine.Purchasing;

public interface IAndroidStoreSelection : IStoreConfiguration
{

	public AppStore appStore
	{
		 get { } //Length: 0
	}

	public AppStore get_appStore() { }

}

