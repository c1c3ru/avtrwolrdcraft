namespace Game.Level;

public class Level50thAnniversarySecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelItem> <>9__23_0; //Field offset: 0x8
		public static Predicate<LevelItem> <>9__23_1; //Field offset: 0x10
		public static Predicate<LevelItem> <>9__24_0; //Field offset: 0x18
		public static Predicate<LevelItem> <>9__24_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <CheckForSolved>b__24_0(LevelItem item) { }

		internal bool <CheckForSolved>b__24_1(LevelItem item) { }

		internal bool <OnItemPickUpFromTable>b__23_0(LevelItem item) { }

		internal bool <OnItemPickUpFromTable>b__23_1(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public string prefabName; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal bool <CheckForSolved>b__4(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_1
	{
		public string prefabName; //Field offset: 0x10

		public <>c__DisplayClass24_1() { }

		internal bool <CheckForSolved>b__5(LevelItem item) { }

	}

	private const int OLD_FEMALE_ID = 100597; //Field offset: 0x0
	private const int OLD_MALE_ID = 100596; //Field offset: 0x0
	private const int YANG_FEMALE_ID = 100594; //Field offset: 0x0
	private const int YANG_MALE_ID = 100595; //Field offset: 0x0
	[SerializeField]
	private LevelSitArea _rightSitArea; //Field offset: 0x20
	[SerializeField]
	private LevelSitArea _leftSitArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _tableDropArea; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onSecretSolvedEvent; //Field offset: 0x38
	private bool _isSolved; //Field offset: 0x40
	private ILevelAvatar _avatarOnRightSit; //Field offset: 0x48
	private ILevelAvatar _avatarOnLeftSit; //Field offset: 0x50
	private List<LevelItem> _itemsOnTableRightSide; //Field offset: 0x58
	private List<LevelItem> _itemsOnTableLeftSide; //Field offset: 0x60
	private string _plateOnLeftSideSceneID; //Field offset: 0x68
	private string _plateOnRightSideSceneID; //Field offset: 0x70

	public Level50thAnniversarySecret() { }

	[CompilerGenerated]
	private bool <CheckForSolved>g__FindOnLeftSide|24_2(string prefabName) { }

	[CompilerGenerated]
	private bool <CheckForSolved>g__FindOnRightSide|24_3(string prefabName) { }

	private void Awake() { }

	private void ChangeAvatarsToOldVersions() { }

	private void ChangeAvatarsToYongVersions() { }

	private void ChangeToCharacter(ILevelAvatar avatar, int previousAvatarID, int newAvatarID) { }

	private bool CheckForSolved() { }

	private void DropAvatarOnChair(LevelAvatarRestAreaBase sit, ILevelAvatar avatar) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDropOnPlate(LevelItem _) { }

	private void OnItemEndDropOnTable(LevelItem levelItem) { }

	private void OnItemPickUpFromPlate(LevelItem _) { }

	private void OnItemPickUpFromTable(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void PickUpAvatarFromChair(LevelAvatarRestAreaBase sit, ILevelAvatar avatar) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

