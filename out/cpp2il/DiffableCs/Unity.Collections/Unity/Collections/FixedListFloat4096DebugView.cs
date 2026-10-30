namespace Unity.Collections;

[Obsolete("FixedListFloat4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<float>", True)]
internal sealed class FixedListFloat4096DebugView
{
	private FixedList4096Bytes<Single> m_List; //Field offset: 0x10

	public Single[] Items
	{
		 get { } //Length: 72
	}

	public FixedListFloat4096DebugView(FixedList4096Bytes<Single> list) { }

	public Single[] get_Items() { }

}

