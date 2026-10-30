namespace UnityEngine.ResourceManagement.ResourceLocations;

public class ResourceLocationBase : IResourceLocation
{
	private string m_Name; //Field offset: 0x10
	private string m_Id; //Field offset: 0x18
	private string m_ProviderId; //Field offset: 0x20
	private object m_Data; //Field offset: 0x28
	private int m_DependencyHashCode; //Field offset: 0x30
	private int m_HashCode; //Field offset: 0x34
	private Type m_Type; //Field offset: 0x38
	private List<IResourceLocation> m_Dependencies; //Field offset: 0x40
	private string m_PrimaryKey; //Field offset: 0x48

	public override object Data
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override IList<IResourceLocation> Dependencies
	{
		 get { } //Length: 8
	}

	public override int DependencyHashCode
	{
		 get { } //Length: 8
	}

	public override bool HasDependencies
	{
		 get { } //Length: 84
	}

	public override string InternalId
	{
		 get { } //Length: 8
	}

	public override string PrimaryKey
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string ProviderId
	{
		 get { } //Length: 8
	}

	public override Type ResourceType
	{
		 get { } //Length: 8
	}

	public ResourceLocationBase(string name, string id, string providerId, Type t, IResourceLocation[] dependencies) { }

	public void ComputeDependencyHash() { }

	public override object get_Data() { }

	public override IList<IResourceLocation> get_Dependencies() { }

	public override int get_DependencyHashCode() { }

	public override bool get_HasDependencies() { }

	public override string get_InternalId() { }

	public override string get_PrimaryKey() { }

	public override string get_ProviderId() { }

	public override Type get_ResourceType() { }

	public override int Hash(Type t) { }

	public void set_Data(object value) { }

	public void set_PrimaryKey(string value) { }

	public virtual string ToString() { }

}

