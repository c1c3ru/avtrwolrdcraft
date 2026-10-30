namespace Unity.Collections;

[Obsolete("FixedListInt128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<int>", True)]
internal sealed class FixedListInt128DebugView
{
	private FixedList128Bytes<Int32> m_List; //Field offset: 0x10

	public Int32[] Items
	{
		 get { } //Length: 72
	}

	public FixedListInt128DebugView(FixedList128Bytes<Int32> list) { }

	public Int32[] get_Items() { }

}

