namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafePtrListTDebugView
{
	private UnsafePtrList<T> Data; //Field offset: 0x0

	public T*[] Items
	{
		 get { } //Length: 172
	}

	public UnsafePtrListTDebugView`1(UnsafePtrList<T> data) { }

	public T*[] get_Items() { }

}

