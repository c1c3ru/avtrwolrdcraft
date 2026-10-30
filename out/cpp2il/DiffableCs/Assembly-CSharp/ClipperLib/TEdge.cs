namespace ClipperLib;

internal class TEdge
{
	internal IntPoint Bot; //Field offset: 0x10
	internal IntPoint Curr; //Field offset: 0x20
	internal IntPoint Top; //Field offset: 0x30
	internal IntPoint Delta; //Field offset: 0x40
	internal double Dx; //Field offset: 0x50
	internal PolyType PolyTyp; //Field offset: 0x58
	internal EdgeSide Side; //Field offset: 0x5C
	internal int WindDelta; //Field offset: 0x60
	internal int WindCnt; //Field offset: 0x64
	internal int WindCnt2; //Field offset: 0x68
	internal int OutIdx; //Field offset: 0x6C
	internal TEdge Next; //Field offset: 0x70
	internal TEdge Prev; //Field offset: 0x78
	internal TEdge NextInLML; //Field offset: 0x80
	internal TEdge NextInAEL; //Field offset: 0x88
	internal TEdge PrevInAEL; //Field offset: 0x90
	internal TEdge NextInSEL; //Field offset: 0x98
	internal TEdge PrevInSEL; //Field offset: 0xA0

	public TEdge() { }

}

