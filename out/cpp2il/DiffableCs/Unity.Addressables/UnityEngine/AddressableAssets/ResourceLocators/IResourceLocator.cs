namespace UnityEngine.AddressableAssets.ResourceLocators;

public interface IResourceLocator
{

	public IEnumerable<Object> Keys
	{
		 get { } //Length: 0
	}

	public string LocatorId
	{
		 get { } //Length: 0
	}

	public IEnumerable<Object> get_Keys() { }

	public string get_LocatorId() { }

	public bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

}

