namespace Unity.Collections;

[Obsolete("FixedListFloat64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<float>", True)]
internal sealed class FixedListFloat64DebugView
{
	private FixedList64Bytes<Single> m_List; //Field offset: 0x10

	public Single[] Items
	{
		 get { } //Length: 72
	}

	public FixedListFloat64DebugView(FixedList64Bytes<Single> list) { }

	public Single[] get_Items() { }

}

