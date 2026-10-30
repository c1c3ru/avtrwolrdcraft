namespace PWC.Level;

public class LevelCharactersRandomizer : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public List<Int32> characterIdsToClean; //Field offset: 0x10
		public int i; //Field offset: 0x18
		public Predicate<LevelCharacter> <>9__0; //Field offset: 0x20

		public <>c__DisplayClass23_0() { }

		internal bool <ClearCharactersFromScene>b__0(LevelCharacter x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass25_0
	{
		public LevelCharactersRandomizer <>4__this; //Field offset: 0x0
		public int characterId; //Field offset: 0x8
		public PDPrefabReference prefabOverride; //Field offset: 0x10
		public List<String> resultSceneGuids; //Field offset: 0x18

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public PDPrefab pdPrefabInstance; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal void <SpawnCharacter>b__0(PDPrefab spawn) { }

	}

	internal class CharactersConfig
	{
		public Int32[] ids; //Field offset: 0x10

		public CharactersConfig() { }

	}

	internal class ClothesConfig
	{
		internal class Set
		{
			public String[] items; //Field offset: 0x10

			public Set() { }

		}

		public Set[] sets; //Field offset: 0x10

		public ClothesConfig() { }

	}

	[SerializeField]
	private int _interval; //Field offset: 0x20
	[SerializeField]
	private int _minCount; //Field offset: 0x24
	[SerializeField]
	private int _maxCount; //Field offset: 0x28
	[SerializeField]
	private bool _useOrderedSpawn; //Field offset: 0x2C
	[SerializeField]
	private TextAsset _charactersFile; //Field offset: 0x30
	[SerializeField]
	private TextAsset _clothesFile; //Field offset: 0x38
	[SerializeField]
	private Transform[] _points; //Field offset: 0x40
	[SerializeField]
	private SerializableDictionaryBase<Int32, PDPrefabReference> _prefabOverrides; //Field offset: 0x48
	[SerializeField]
	private String[] levelCharacterAnimations; //Field offset: 0x50
	private long _lastShuffleDateTime; //Field offset: 0x58
	private bool _didTimePass; //Field offset: 0x60
	private Int32[] _characterIds; //Field offset: 0x68
	private String[] _itemSceneGuids; //Field offset: 0x70
	[CompilerGenerated]
	private Action<List`1<LevelCharacter>> OnCharactersChangedAction; //Field offset: 0x78

	public event Action<List`1<LevelCharacter>> OnCharactersChangedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCharactersRandomizer() { }

	[CompilerGenerated]
	private LevelCharacter <PlaceCharacterInScene>g__Spawn|25_0(Vector2 position, ref <>c__DisplayClass25_0 unnamed_param_1) { }

	[CompilerGenerated]
	public void add_OnCharactersChangedAction(Action<List`1<LevelCharacter>> value) { }

	private void Awake() { }

	private void ClearCharactersFromScene(List<Int32> characterIdsToClean) { }

	private void ClearItemsFromScene(String[] itemsSceneGuidsToClean) { }

	private void FillDisposableOnLevelResetSceneGuids(HashSet<String> sceneGuids) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void HandleCAHandlers(List<LevelCharacter> characters) { }

	private void HandleClothes(List<LevelCharacter> characters, TextAsset clothesFile) { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private LevelCharacter PlaceCharacterInScene(Transform point, int characterId, PDPrefabReference prefabOverride, List<String> resultSceneGuids) { }

	[CompilerGenerated]
	public void remove_OnCharactersChangedAction(Action<List`1<LevelCharacter>> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ShuffleCharacters() { }

	private LevelCharacter SpawnCharacter(int characterId, Vector2 position, PDPrefabReference prefabOverride, List<String> resultSceneGuids) { }

}

