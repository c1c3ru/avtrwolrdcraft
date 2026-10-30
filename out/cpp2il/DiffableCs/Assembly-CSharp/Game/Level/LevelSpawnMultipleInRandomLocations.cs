namespace Game.Level;

public class LevelSpawnMultipleInRandomLocations : MonoBehaviour
{
	internal class Config
	{
		public String[] items; //Field offset: 0x10

		public Config() { }

	}

	[SerializeField]
	private int _minNumberOfItemsToSpawn; //Field offset: 0x20
	[SerializeField]
	private int _maxNumberOfItemsToSpawn; //Field offset: 0x24
	[SerializeField]
	private PDPrefabReference[] _prefabs; //Field offset: 0x28
	[SerializeField]
	protected TextAsset _textAsset; //Field offset: 0x30
	[SerializeField]
	private Transform[] _locations; //Field offset: 0x38
	private List<PDPrefabReference> _refrences; //Field offset: 0x40
	private List<Int32> _indexs; //Field offset: 0x48
	private String[] _clothes; //Field offset: 0x50

	public LevelSpawnMultipleInRandomLocations() { }

	private void Awake() { }

	public void DestroyAndSpawnNewItems() { }

	private void DestroyCurrentItems() { }

	private void GetClothesIfNeeded() { }

	private void GetLocationsIndexesOrderIfNeeded() { }

	private void GetPrefabsIfNeeded() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void SpawnItem() { }

}

