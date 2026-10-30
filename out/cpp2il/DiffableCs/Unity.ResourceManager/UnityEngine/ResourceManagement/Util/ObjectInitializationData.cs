namespace UnityEngine.ResourceManagement.Util;

public struct ObjectInitializationData
{
	[FormerlySerializedAs("m_id")]
	[SerializeField]
	private string m_Id; //Field offset: 0x0
	[FormerlySerializedAs("m_objectType")]
	[SerializeField]
	private SerializedType m_ObjectType; //Field offset: 0x8
	[FormerlySerializedAs("m_data")]
	[SerializeField]
	private string m_Data; //Field offset: 0x28

	public string Data
	{
		 get { } //Length: 8
	}

	public string Id
	{
		 get { } //Length: 8
	}

	public SerializedType ObjectType
	{
		 get { } //Length: 16
	}

	public TObject CreateInstance(string idOverride = null) { }

	public string get_Data() { }

	public string get_Id() { }

	public SerializedType get_ObjectType() { }

	public AsyncOperationHandle GetAsyncInitHandle(ResourceManager rm, string idOverride = null) { }

	public virtual string ToString() { }

}

