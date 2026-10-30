namespace Unity.Collections;

[Obsolete("FixedListFloat128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<float>", True)]
internal sealed class FixedListFloat128DebugView
{
	private FixedList128Bytes<Single> m_List; //Field offset: 0x10

	public Single[] Items
	{
		 get { } //Length: 72
	}

	public FixedListFloat128DebugView(FixedList128Bytes<Single> list) { }

	public Single[] get_Items() { }

}

