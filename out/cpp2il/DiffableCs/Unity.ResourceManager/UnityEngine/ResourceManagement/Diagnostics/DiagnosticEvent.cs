namespace UnityEngine.ResourceManagement.Diagnostics;

public struct DiagnosticEvent
{
	[SerializeField]
	private string m_Graph; //Field offset: 0x0
	[SerializeField]
	private Int32[] m_Dependencies; //Field offset: 0x8
	[SerializeField]
	private int m_ObjectId; //Field offset: 0x10
	[SerializeField]
	private string m_DisplayName; //Field offset: 0x18
	[SerializeField]
	private int m_Stream; //Field offset: 0x20
	[SerializeField]
	private int m_Frame; //Field offset: 0x24
	[SerializeField]
	private int m_Value; //Field offset: 0x28

	public Int32[] Dependencies
	{
		 get { } //Length: 8
	}

	public string DisplayName
	{
		 get { } //Length: 8
	}

	public int Frame
	{
		 get { } //Length: 8
	}

	public string Graph
	{
		 get { } //Length: 8
	}

	public int ObjectId
	{
		 get { } //Length: 8
	}

	public int Stream
	{
		 get { } //Length: 8
	}

	public int Value
	{
		 get { } //Length: 8
	}

	public DiagnosticEvent(string graph, string name, int id, int stream, int frame, int value, Int32[] deps) { }

	public static DiagnosticEvent Deserialize(Byte[] data) { }

	public Int32[] get_Dependencies() { }

	public string get_DisplayName() { }

	public int get_Frame() { }

	public string get_Graph() { }

	public int get_ObjectId() { }

	public int get_Stream() { }

	public int get_Value() { }

	internal Byte[] Serialize() { }

}

