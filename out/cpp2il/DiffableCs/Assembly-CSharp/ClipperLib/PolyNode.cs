namespace ClipperLib;

public class PolyNode
{
	internal PolyNode m_Parent; //Field offset: 0x10
	internal List<IntPoint> m_polygon; //Field offset: 0x18
	internal int m_Index; //Field offset: 0x20
	internal JoinType m_jointype; //Field offset: 0x24
	internal EndType m_endtype; //Field offset: 0x28
	internal List<PolyNode> m_Childs; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsOpen>k__BackingField; //Field offset: 0x38

	public int ChildCount
	{
		 get { } //Length: 72
	}

	public List<PolyNode> Childs
	{
		 get { } //Length: 8
	}

	public List<IntPoint> Contour
	{
		 get { } //Length: 8
	}

	public bool IsHole
	{
		 get { } //Length: 28
	}

	public bool IsOpen
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public PolyNode Parent
	{
		 get { } //Length: 8
	}

	public PolyNode() { }

	internal void AddChild(PolyNode Child) { }

	public int get_ChildCount() { }

	public List<PolyNode> get_Childs() { }

	public List<IntPoint> get_Contour() { }

	public bool get_IsHole() { }

	[CompilerGenerated]
	public bool get_IsOpen() { }

	public PolyNode get_Parent() { }

	public PolyNode GetNext() { }

	internal PolyNode GetNextSiblingUp() { }

	private bool IsHoleNode() { }

	[CompilerGenerated]
	public void set_IsOpen(bool value) { }

}

