namespace Unity.Collections;

[Obsolete("FixedListByte64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<byte>", True)]
internal sealed class FixedListByte64DebugView
{
	private FixedList64Bytes<Byte> m_List; //Field offset: 0x10

	public Byte[] Items
	{
		 get { } //Length: 72
	}

	public FixedListByte64DebugView(FixedList64Bytes<Byte> list) { }

	public Byte[] get_Items() { }

}

