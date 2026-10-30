namespace Unity.Collections;

[Obsolete("FixedListByte128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<byte>", True)]
internal sealed class FixedListByte128DebugView
{
	private FixedList128Bytes<Byte> m_List; //Field offset: 0x10

	public Byte[] Items
	{
		 get { } //Length: 72
	}

	public FixedListByte128DebugView(FixedList128Bytes<Byte> list) { }

	public Byte[] get_Items() { }

}

