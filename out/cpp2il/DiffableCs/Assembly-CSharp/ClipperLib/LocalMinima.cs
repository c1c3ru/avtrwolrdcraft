namespace ClipperLib;

internal class LocalMinima
{
	internal long Y; //Field offset: 0x10
	internal TEdge LeftBound; //Field offset: 0x18
	internal TEdge RightBound; //Field offset: 0x20
	internal LocalMinima Next; //Field offset: 0x28

	public LocalMinima() { }

}

