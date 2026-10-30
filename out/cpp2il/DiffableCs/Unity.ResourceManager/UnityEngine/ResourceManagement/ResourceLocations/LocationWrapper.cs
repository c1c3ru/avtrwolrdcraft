namespace UnityEngine.ResourceManagement.ResourceLocations;

internal class LocationWrapper : IResourceLocation
{
	private IResourceLocation m_InternalLocation; //Field offset: 0x10

	public override object Data
	{
		 get { } //Length: 164
	}

	public override IList<IResourceLocation> Dependencies
	{
		 get { } //Length: 164
	}

	public override int DependencyHashCode
	{
		 get { } //Length: 164
	}

	public override bool HasDependencies
	{
		 get { } //Length: 164
	}

	public override string InternalId
	{
		 get { } //Length: 160
	}

	public override string PrimaryKey
	{
		 get { } //Length: 164
	}

	public override string ProviderId
	{
		 get { } //Length: 164
	}

	public override Type ResourceType
	{
		 get { } //Length: 164
	}

	public LocationWrapper(IResourceLocation location) { }

	public override object get_Data() { }

	public override IList<IResourceLocation> get_Dependencies() { }

	public override int get_DependencyHashCode() { }

	public override bool get_HasDependencies() { }

	public override string get_InternalId() { }

	public override string get_PrimaryKey() { }

	public override string get_ProviderId() { }

	public override Type get_ResourceType() { }

	public override int Hash(Type resultType) { }

}

