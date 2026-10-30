namespace Game.Level;

public class LevelSecretAvatarPutClothingsListener : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public int avatarID; //Field offset: 0x10
		public string clothingTypeName; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal bool <OnPutClothing>b__0(string category) { }

		internal bool <OnPutClothing>b__1(ILevelAvatar x) { }

		internal bool <OnPutClothing>b__2(LevelCharacter x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_1
	{
		public PDPrefab[] pdPrefabParents; //Field offset: 0x10

		public <>c__DisplayClass16_1() { }

		internal bool <OnPutClothing>b__3(PDPrefabReference prefRef) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_2
	{
		public PDPrefabReference prefRef; //Field offset: 0x10

		public <>c__DisplayClass16_2() { }

		internal bool <OnPutClothing>b__4(PDPrefab parent) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public string clothingTypeName; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <OnRemoveClothing>b__0(string x) { }

		internal bool <OnRemoveClothing>b__1(string category) { }

		internal bool <OnRemoveClothing>b__2(string x) { }

	}

	[SerializeField]
	private String[] _solvingCategories; //Field offset: 0x20
	[SerializeField]
	private String[] _solvingSkins; //Field offset: 0x28
	[SerializeField]
	public UnityEvent onSecretSolvedEvent; //Field offset: 0x30
	[SerializeField]
	private bool _allTogether; //Field offset: 0x38
	[SerializeField]
	private bool _isSpecificID; //Field offset: 0x39
	[ConditionalField("_isSpecificID", True, True, (array) null)]
	[SerializeField]
	private int _avatarID; //Field offset: 0x3C
	[SerializeField]
	private List<PDPrefabReference> _pdPrefabReferencesList; //Field offset: 0x40
	private Dictionary<Int32, HashSet`1<String>> _avatars; //Field offset: 0x48
	private bool _isSolved; //Field offset: 0x50
	private HashSet<String> _solvingSkinsHash; //Field offset: 0x58

	public LevelSecretAvatarPutClothingsListener() { }

	private void Awake() { }

	public void CheckAllAvatars() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private HashSet<String> GetSkinsWorn(int avatarID) { }

	private void OnAfterAvatarSpawnAction(ILevelAvatar avatar) { }

	private void OnColorSkin(int avatarID, string skinName, Color[] colors) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPutClothing(int avatarID, string skinName) { }

	private void OnRemoveClothing(int avatarID, string skinName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private bool TryAddSkinToSkinsWorn(int avatarID, string skinName) { }

}

