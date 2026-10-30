namespace Unity.Collections.LowLevel.Unsafe;

[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
public struct Words
{
	private int Index; //Field offset: 0x0

	public void SetFixedString(ref T value) { }

	public void SetString(string value) { }

	public void ToFixedString(ref T value) { }

	public virtual string ToString() { }

}

