namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Avatar Clothing Map")]
public class LevelAvatarClothingMap : ScriptableObject
{
	internal class Item
	{
		[Flags]
		internal enum FlagType
		{
			None = 0,
			IsSpecific = 1,
			IsColorable = 2,
			HasFoldedState = 4,
			HasHangedState = 8,
			HasFoldedStateST = 16,
			HasHangedStateST = 32,
		}

		public string skin; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18
		public FlagType flags; //Field offset: 0x20
		private string _skinNameForStates; //Field offset: 0x28

		public Item() { }

		private void EnsureSkinNameForStates() { }

		public string GetFoldedState() { }

		public string GetFoldedStateST() { }

		public string GetHangedState() { }

		public string GetHangedStateST() { }

		public bool HasFoldedState() { }

		public bool HasFoldedStateST() { }

		public bool HasHangedState() { }

		public bool HasHangedStateST() { }

		public bool IsColorable() { }

		public bool IsSpecific() { }

	}

	public List<Item> items; //Field offset: 0x18
	private Dictionary<String, Item> _dictionary; //Field offset: 0x20

	public LevelAvatarClothingMap() { }

	public bool TryGetData(string skinName, out Item dataItem) { }

}

