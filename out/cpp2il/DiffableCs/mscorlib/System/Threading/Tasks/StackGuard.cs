namespace System.Threading.Tasks;

internal class StackGuard
{
	private const int MAX_UNCHECKED_INLINING_DEPTH = 20; //Field offset: 0x0
	private int m_inliningDepth; //Field offset: 0x10

	public StackGuard() { }

	internal void EndInliningScope() { }

	internal bool TryBeginInliningScope() { }

}

