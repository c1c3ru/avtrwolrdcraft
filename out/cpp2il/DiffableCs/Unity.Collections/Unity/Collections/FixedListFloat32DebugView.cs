namespace Unity.Collections;

[Obsolete("FixedListFloat32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<float>", True)]
internal sealed class FixedListFloat32DebugView
{
	private FixedList32Bytes<Single> m_List; //Field offset: 0x10

	public Single[] Items
	{
		 get { } //Length: 72
	}

	public FixedListFloat32DebugView(FixedList32Bytes<Single> list) { }

	public Single[] get_Items() { }

}

