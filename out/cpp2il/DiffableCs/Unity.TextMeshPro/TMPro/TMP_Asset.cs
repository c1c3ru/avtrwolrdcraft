namespace TMPro;

public abstract class TMP_Asset : ScriptableObject
{
	private int m_InstanceID; //Field offset: 0x18
	public int hashCode; //Field offset: 0x1C
	public Material material; //Field offset: 0x20
	public int materialHashCode; //Field offset: 0x28

	public int instanceID
	{
		 get { } //Length: 40
	}

	protected TMP_Asset() { }

	public int get_instanceID() { }

}

