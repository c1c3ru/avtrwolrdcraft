namespace UnityEngine.AddressableAssets.ResourceLocators;

public class LegacyResourcesLocator : IResourceLocator
{

	public override IEnumerable<Object> Keys
	{
		 get { } //Length: 8
	}

	public override string LocatorId
	{
		 get { } //Length: 64
	}

	public LegacyResourcesLocator() { }

	public override IEnumerable<Object> get_Keys() { }

	public override string get_LocatorId() { }

	public override bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

}

