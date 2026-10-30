namespace PWC.PersistentData;

[CreateAssetMenu(menuName = "AvatarWorld/PD/PDTextBulkData")]
public class PDTextBulkData : ScriptableObject
{
	internal class ClothingItemsBySpineType
	{
		public SpineType spineType; //Field offset: 0x10
		public List<LevelClothingItemPD> clothingPD; //Field offset: 0x18

		public ClothingItemsBySpineType() { }

	}

	[SerializeField]
	private TextAsset _textAsset; //Field offset: 0x18
	[SerializeField]
	private List<ClothingItemsBySpineType> _clothingItemsBySpineType; //Field offset: 0x20
	private BulkData _bulkData; //Field offset: 0x28

	public PDTextBulkData() { }

	public List<LevelClothingItemPD> GetClothingItemsPD(SpineType type) { }

	public bool TryClothingSkinNames(out Dictionary<SpineType, List`1<String>>& skinNames) { }

	public bool TryGetBulkData(out BulkData bulkData) { }

	public bool TryGetPrefabGuids(out List<String>& prefabGuids) { }

	public bool TryGetSceneObjectGuids(out List<String>& sceneObjectGuids) { }

	public bool TryLoadSceneElementsPDFromBulkData(out List<GameObject>& sceneElementList) { }

	public bool TrySpawn(out List<PDPrefab>& prefabList, bool allowMultiplayerEvent = true) { }

}

