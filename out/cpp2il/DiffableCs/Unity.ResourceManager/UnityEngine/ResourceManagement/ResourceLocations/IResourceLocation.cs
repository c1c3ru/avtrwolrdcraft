namespace UnityEngine.ResourceManagement.ResourceLocations;

public interface IResourceLocation
{

	public object Data
	{
		 get { } //Length: 0
	}

	public IList<IResourceLocation> Dependencies
	{
		 get { } //Length: 0
	}

	public int DependencyHashCode
	{
		 get { } //Length: 0
	}

	public bool HasDependencies
	{
		 get { } //Length: 0
	}

	public string InternalId
	{
		 get { } //Length: 0
	}

	public string PrimaryKey
	{
		 get { } //Length: 0
	}

	public string ProviderId
	{
		 get { } //Length: 0
	}

	public Type ResourceType
	{
		 get { } //Length: 0
	}

	public object get_Data() { }

	public IList<IResourceLocation> get_Dependencies() { }

	public int get_DependencyHashCode() { }

	public bool get_HasDependencies() { }

	public string get_InternalId() { }

	public string get_PrimaryKey() { }

	public string get_ProviderId() { }

	public Type get_ResourceType() { }

	public int Hash(Type resultType) { }

}

