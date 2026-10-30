namespace PazuCore.RemoteAssetsGC;

public class RemoteAssetsGCData : ISerializationCallbackReceiver
{
	private class Item
	{
		public string key; //Field offset: 0x10
		public List<String> assetsNames; //Field offset: 0x18

		public Item() { }

	}

	[SerializeField]
	private List<Item> _items; //Field offset: 0x10
	public Dictionary<String, HashSet`1<String>> HashedData; //Field offset: 0x18

	public RemoteAssetsGCData() { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

}

