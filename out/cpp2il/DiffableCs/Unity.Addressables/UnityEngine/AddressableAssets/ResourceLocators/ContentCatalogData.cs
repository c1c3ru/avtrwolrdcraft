namespace UnityEngine.AddressableAssets.ResourceLocators;

public class ContentCatalogData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<IResourceLocation, String> <>9__48_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <GetData>b__48_0(IResourceLocation d) { }

	}

	private struct Bucket
	{
		public int dataOffset; //Field offset: 0x0
		public Int32[] entries; //Field offset: 0x8

	}

	private class CompactLocation : IResourceLocation
	{
		private ResourceLocationMap m_Locator; //Field offset: 0x10
		private string m_InternalId; //Field offset: 0x18
		private string m_ProviderId; //Field offset: 0x20
		private object m_Dependency; //Field offset: 0x28
		private object m_Data; //Field offset: 0x30
		private int m_HashCode; //Field offset: 0x38
		private int m_DependencyHashCode; //Field offset: 0x3C
		private string m_PrimaryKey; //Field offset: 0x40
		private Type m_Type; //Field offset: 0x48

		public override object Data
		{
			 get { } //Length: 8
		}

		public override IList<IResourceLocation> Dependencies
		{
			 get { } //Length: 180
		}

		public override int DependencyHashCode
		{
			 get { } //Length: 8
		}

		public override bool HasDependencies
		{
			 get { } //Length: 16
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

		public CompactLocation(ResourceLocationMap locator, string internalId, string providerId, object dependencyKey, object data, int depHash, string primaryKey, Type type) { }

		public override object get_Data() { }

		public override IList<IResourceLocation> get_Dependencies() { }

		public override int get_DependencyHashCode() { }

		public override bool get_HasDependencies() { }

		public override string get_InternalId() { }

		public override string get_PrimaryKey() { }

		public override string get_ProviderId() { }

		public override Type get_ResourceType() { }

		public override int Hash(Type t) { }

		public void set_PrimaryKey(string value) { }

		public virtual string ToString() { }

	}

	private static int kMagic; //Field offset: 0x0
	private const int kVersion = 1; //Field offset: 0x0
	private const int k_EntryDataItemPerEntry = 7; //Field offset: 0x0
	private const int kBytesPerInt32 = 4; //Field offset: 0x0
	public string LocalHash; //Field offset: 0x10
	internal IResourceLocation location; //Field offset: 0x18
	[SerializeField]
	internal string m_LocatorId; //Field offset: 0x20
	[SerializeField]
	internal string m_BuildResultHash; //Field offset: 0x28
	[SerializeField]
	private ObjectInitializationData m_InstanceProviderData; //Field offset: 0x30
	[SerializeField]
	private ObjectInitializationData m_SceneProviderData; //Field offset: 0x60
	[SerializeField]
	internal List<ObjectInitializationData> m_ResourceProviderData; //Field offset: 0x90
	private IList<ContentCatalogDataEntry> m_Entries; //Field offset: 0x98
	[FormerlySerializedAs("m_providerIds")]
	[SerializeField]
	internal String[] m_ProviderIds; //Field offset: 0xA0
	[FormerlySerializedAs("m_internalIds")]
	[SerializeField]
	internal String[] m_InternalIds; //Field offset: 0xA8
	[FormerlySerializedAs("m_keyDataString")]
	[SerializeField]
	internal string m_KeyDataString; //Field offset: 0xB0
	[FormerlySerializedAs("m_bucketDataString")]
	[SerializeField]
	internal string m_BucketDataString; //Field offset: 0xB8
	[FormerlySerializedAs("m_entryDataString")]
	[SerializeField]
	internal string m_EntryDataString; //Field offset: 0xC0
	[FormerlySerializedAs("m_extraDataString")]
	[SerializeField]
	internal string m_ExtraDataString; //Field offset: 0xC8
	[SerializeField]
	internal SerializedType[] m_resourceTypes; //Field offset: 0xD0
	[SerializeField]
	private String[] m_InternalIdPrefixes; //Field offset: 0xD8

	public string BuildResultHash
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ObjectInitializationData InstanceProviderData
	{
		 get { } //Length: 20
		 set { } //Length: 32
	}

	public String[] InternalIds
	{
		 get { } //Length: 8
	}

	public internal string ProviderId
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public String[] ProviderIds
	{
		 get { } //Length: 8
	}

	public List<ObjectInitializationData> ResourceProviderData
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ObjectInitializationData SceneProviderData
	{
		 get { } //Length: 20
		 set { } //Length: 32
	}

	private static ContentCatalogData() { }

	public ContentCatalogData() { }

	public ContentCatalogData(string id) { }

	internal void CleanData() { }

	internal ResourceLocationMap CreateCustomLocator(string overrideId = "", string providerSuffix = null) { }

	public ResourceLocationMap CreateLocator(string providerSuffix = null) { }

	internal static string ExpandInternalId(String[] internalIdPrefixes, string v) { }

	public string get_BuildResultHash() { }

	public ObjectInitializationData get_InstanceProviderData() { }

	public String[] get_InternalIds() { }

	public string get_ProviderId() { }

	public String[] get_ProviderIds() { }

	public List<ObjectInitializationData> get_ResourceProviderData() { }

	public ObjectInitializationData get_SceneProviderData() { }

	internal IList<ContentCatalogDataEntry> GetData() { }

	internal static ContentCatalogData LoadFromFile(string path, int cacheSize = 1024) { }

	internal void SaveToFile(string path) { }

	public void set_BuildResultHash(string value) { }

	public void set_InstanceProviderData(ObjectInitializationData value) { }

	internal void set_ProviderId(string value) { }

	public void set_ResourceProviderData(List<ObjectInitializationData> value) { }

	public void set_SceneProviderData(ObjectInitializationData value) { }

}

