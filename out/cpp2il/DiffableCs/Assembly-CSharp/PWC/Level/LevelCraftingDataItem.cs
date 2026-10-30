namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Crafting Data Item")]
public class LevelCraftingDataItem : ScriptableObject
{
	internal class Result
	{
		public LevelCraftingType type; //Field offset: 0x10
		public Sprite hudThumb; //Field offset: 0x18
		public PDPrefabReference[] outcomes; //Field offset: 0x20

		public Result() { }

		public PDPrefab GetOutcomePrefab(int index) { }

	}

	public LevelCraftingToolType toolType; //Field offset: 0x18
	public List<Result> results; //Field offset: 0x20
	public List<LevelCraftingDataItem> linkedDataList; //Field offset: 0x28
	private Dictionary<LevelCraftingType, Result> _hashedResults; //Field offset: 0x30

	public LevelCraftingDataItem() { }

	private void InitCollectionIfNeeded() { }

	public bool TryGetCraftingOutcomes(LevelCraftingType craftingType, out Result result) { }

}

