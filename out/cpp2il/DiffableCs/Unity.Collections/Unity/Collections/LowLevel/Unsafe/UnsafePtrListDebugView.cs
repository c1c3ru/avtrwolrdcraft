namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafePtrListDebugView
{
	private UnsafePtrList Data; //Field offset: 0x10

	public IntPtr[] Items
	{
		 get { } //Length: 160
	}

	public UnsafePtrListDebugView(UnsafePtrList data) { }

	public IntPtr[] get_Items() { }

}

