namespace Spine;

public abstract class VertexAttachment : Attachment
{
	private static int nextID; //Field offset: 0x0
	private static readonly object nextIdLock; //Field offset: 0x8
	internal readonly int id; //Field offset: 0x18
	internal VertexAttachment timelineAttachment; //Field offset: 0x20
	internal Int32[] bones; //Field offset: 0x28
	internal Single[] vertices; //Field offset: 0x30
	internal int worldVerticesLength; //Field offset: 0x38

	public Int32[] Bones
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Id
	{
		 get { } //Length: 8
	}

	public VertexAttachment TimelineAttachment
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Single[] Vertices
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int WorldVerticesLength
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static VertexAttachment() { }

	public VertexAttachment(string name) { }

	public VertexAttachment(VertexAttachment other) { }

	public void ComputeWorldVertices(Slot slot, Single[] worldVertices) { }

	public override void ComputeWorldVertices(Slot slot, int start, int count, Single[] worldVertices, int offset, int stride = 2) { }

	public Int32[] get_Bones() { }

	public int get_Id() { }

	public VertexAttachment get_TimelineAttachment() { }

	public Single[] get_Vertices() { }

	public int get_WorldVerticesLength() { }

	public void set_Bones(Int32[] value) { }

	public void set_TimelineAttachment(VertexAttachment value) { }

	public void set_Vertices(Single[] value) { }

	public void set_WorldVerticesLength(int value) { }

}

