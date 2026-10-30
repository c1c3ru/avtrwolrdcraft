namespace UnityEngine.AddressableAssets.ResourceLocators;

public class ResourceLocationMap : IResourceLocator
{
	[CompilerGenerated]
	private string <LocatorId>k__BackingField; //Field offset: 0x10
	private Dictionary<Object, IList`1<IResourceLocation>> locations; //Field offset: 0x18

	public override IEnumerable<Object> Keys
	{
		 get { } //Length: 80
	}

	public Dictionary<Object, IList`1<IResourceLocation>> Locations
	{
		 get { } //Length: 8
	}

	public private override string LocatorId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ResourceLocationMap(string id, int capacity = 0) { }

	public ResourceLocationMap(string id, IList<ResourceLocationData> locations) { }

	public void Add(object key, IResourceLocation location) { }

	public void Add(object key, IList<IResourceLocation> locations) { }

	public override IEnumerable<Object> get_Keys() { }

	public Dictionary<Object, IList`1<IResourceLocation>> get_Locations() { }

	[CompilerGenerated]
	public override string get_LocatorId() { }

	public override bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

	[CompilerGenerated]
	private void set_LocatorId(string value) { }

}

