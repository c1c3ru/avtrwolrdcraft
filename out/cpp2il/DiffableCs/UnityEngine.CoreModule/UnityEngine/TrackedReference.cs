namespace UnityEngine;

[UsedByNativeCode]
public class TrackedReference
{
	internal IntPtr m_Ptr; //Field offset: 0x10

	protected TrackedReference() { }

	public virtual bool Equals(object o) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(TrackedReference x, TrackedReference y) { }

}

