namespace UnityEngine.ResourceManagement.ResourceProviders;

public struct InstantiationParameters
{
	private Vector3 m_Position; //Field offset: 0x0
	private Quaternion m_Rotation; //Field offset: 0xC
	private Transform m_Parent; //Field offset: 0x20
	private bool m_InstantiateInWorldPosition; //Field offset: 0x28
	private bool m_SetPositionRotation; //Field offset: 0x29

	public bool InstantiateInWorldPosition
	{
		 get { } //Length: 8
	}

	public Transform Parent
	{
		 get { } //Length: 8
	}

	public Vector3 Position
	{
		 get { } //Length: 12
	}

	public Quaternion Rotation
	{
		 get { } //Length: 12
	}

	public bool SetPositionRotation
	{
		 get { } //Length: 8
	}

	public InstantiationParameters(Transform parent, bool instantiateInWorldSpace) { }

	public InstantiationParameters(Vector3 position, Quaternion rotation, Transform parent) { }

	public bool get_InstantiateInWorldPosition() { }

	public Transform get_Parent() { }

	public Vector3 get_Position() { }

	public Quaternion get_Rotation() { }

	public bool get_SetPositionRotation() { }

	public TObject Instantiate(TObject source) { }

}

