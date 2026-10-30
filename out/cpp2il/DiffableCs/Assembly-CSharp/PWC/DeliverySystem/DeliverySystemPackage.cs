namespace PWC.DeliverySystem;

public class DeliverySystemPackage
{
	internal class Item
	{
		public string prefabGuid; //Field offset: 0x10
		public int amount; //Field offset: 0x18

		public Item() { }

	}

	public string sceneName; //Field offset: 0x10
	public long orderTime; //Field offset: 0x18
	public float duration; //Field offset: 0x20
	public List<Item> items; //Field offset: 0x28
	public string boxPrefabGuid; //Field offset: 0x30

	public DeliverySystemPackage() { }

	public bool DidPassDuration() { }

	public float GetTimeLeft() { }

	public void SetOrderTimeAsNow() { }

}

