namespace PWC;

public static class TimeDamper
{
	internal class Item
	{
		public bool isEnabled; //Field offset: 0x10
		public float savedTime; //Field offset: 0x14
		public float duration; //Field offset: 0x18

		public Item() { }

	}

	private static readonly Dictionary<String, Item> _items; //Field offset: 0x0

	private static TimeDamper() { }

	public static void Set(string key, float duration) { }

	public static bool TryDamp(string key) { }

}

