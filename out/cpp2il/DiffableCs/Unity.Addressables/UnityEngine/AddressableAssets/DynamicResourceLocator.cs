namespace UnityEngine.AddressableAssets;

internal class DynamicResourceLocator : IResourceLocator
{
	private AddressablesImpl m_Addressables; //Field offset: 0x10
	private string m_AtlasSpriteProviderId; //Field offset: 0x18

	public IEnumerable<IResourceLocation> AllLocations
	{
		 get { } //Length: 68
	}

	private string AtlasSpriteProviderId
	{
		private get { } //Length: 1120
	}

	public override IEnumerable<Object> Keys
	{
		 get { } //Length: 68
	}

	public override string LocatorId
	{
		 get { } //Length: 64
	}

	public DynamicResourceLocator(AddressablesImpl addr) { }

	internal void CreateDynamicLocations(Type type, IList<IResourceLocation> locations, string locName, string subKey, IResourceLocation mainLoc) { }

	public IEnumerable<IResourceLocation> get_AllLocations() { }

	private string get_AtlasSpriteProviderId() { }

	public override IEnumerable<Object> get_Keys() { }

	public override string get_LocatorId() { }

	public override bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

}

