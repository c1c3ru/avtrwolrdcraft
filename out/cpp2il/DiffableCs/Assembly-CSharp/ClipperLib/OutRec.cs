namespace ClipperLib;

internal class OutRec
{
	internal int Idx; //Field offset: 0x10
	internal bool IsHole; //Field offset: 0x14
	internal bool IsOpen; //Field offset: 0x15
	internal OutRec FirstLeft; //Field offset: 0x18
	internal OutPt Pts; //Field offset: 0x20
	internal OutPt BottomPt; //Field offset: 0x28
	internal PolyNode PolyNode; //Field offset: 0x30

	public OutRec() { }

}

