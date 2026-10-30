namespace Unity.Collections;

public interface IUTF8Bytes
{

	public bool IsEmpty
	{
		 get { } //Length: 0
	}

	public bool get_IsEmpty() { }

	public Byte* GetUnsafePtr() { }

	public bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

