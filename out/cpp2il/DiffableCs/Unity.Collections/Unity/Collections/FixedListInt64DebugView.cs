namespace Unity.Collections;

[Obsolete("FixedListInt64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<int>", True)]
internal sealed class FixedListInt64DebugView
{
	private FixedList64Bytes<Int32> m_List; //Field offset: 0x10

	public Int32[] Items
	{
		 get { } //Length: 72
	}

	public FixedListInt64DebugView(FixedList64Bytes<Int32> list) { }

	public Int32[] get_Items() { }

}

