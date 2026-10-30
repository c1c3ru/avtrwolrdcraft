namespace PWC.Level.Maker;

[CreateAssetMenu(menuName = "AvatarWorld/Level/Maker/ItemsCategoriesData")]
public class LevelMakerItemsCategoriesData : ScriptableObject
{
	internal class AllData
	{
		internal class Node
		{
			[JsonIgnore]
			public Node parentNode; //Field offset: 0x10
			[JsonIgnore]
			public string name; //Field offset: 0x18
			public bool isComingSoon; //Field offset: 0x20
			public Dictionary<String, Node> nodes; //Field offset: 0x28
			public List<String> packNames; //Field offset: 0x30

			public Node() { }

			public void FillMissingData(List<Node> flatNodesListToFill) { }

			public void GetAllPackNamesRecursive(List<String> listToFill) { }

			public void GetCategoriesPathList(List<String> categoriesPathList) { }

			public bool TryGetNodeInside(List<String> nodeNamesPath, out Node node) { }

		}

		[JsonIgnore]
		public List<Node> flatNodesList; //Field offset: 0x10
		public Node rootNode; //Field offset: 0x18
		public Dictionary<String, CategoryData> packs; //Field offset: 0x20

		public AllData() { }

		public void FillMissingData() { }

	}

	internal class CategoryData
	{
		public string packName; //Field offset: 0x10
		public string packPrefabGuid; //Field offset: 0x18
		public string iconName; //Field offset: 0x20
		public string iconBGName; //Field offset: 0x28
		public string tagName; //Field offset: 0x30
		public bool hasProperLayoutData; //Field offset: 0x38
		public bool isPremium; //Field offset: 0x39
		public List<PrefabData> prefabDatas; //Field offset: 0x40

		public CategoryData() { }

	}

	internal enum DataType
	{
		None = 0,
		LevelMaker = 1,
		UGC = 2,
	}

	internal class PrefabData
	{
		public string section; //Field offset: 0x10
		public string prefabName; //Field offset: 0x18
		public Vector2 itemSize; //Field offset: 0x20
		public int maxCount; //Field offset: 0x28

		public PrefabData() { }

		public PrefabData CreateCopy() { }

	}

	private static readonly Dictionary<DataType, LevelMakerItemsCategoriesData> _instances; //Field offset: 0x0
	[SerializeField]
	private TextAsset _itemsCategoriesTextAsset; //Field offset: 0x18
	[SerializeField]
	private List<TextAsset> _itemsPacksTextAssets; //Field offset: 0x20
	private HashSet<String> _hashedPrefabGuids; //Field offset: 0x28
	private AllData _parsedData; //Field offset: 0x30

	private static LevelMakerItemsCategoriesData() { }

	public LevelMakerItemsCategoriesData() { }

	private void EnsureData() { }

	public static LevelMakerItemsCategoriesData GetData(DataType dataType) { }

	public AllData GetParsedData() { }

	public bool IsMenuContainsPack(string packName) { }

	public bool IsMenuContainsPrefab(string prefabGuid) { }

	public bool TryGetPrefabsInPack(string packName, out List<String>& prefabGuids) { }

}

