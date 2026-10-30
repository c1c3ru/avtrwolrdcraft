namespace ClipperLib;

internal class OutPt
{
	internal int Idx; //Field offset: 0x10
	internal IntPoint Pt; //Field offset: 0x18
	internal OutPt Next; //Field offset: 0x28
	internal OutPt Prev; //Field offset: 0x30

	public OutPt() { }

}

