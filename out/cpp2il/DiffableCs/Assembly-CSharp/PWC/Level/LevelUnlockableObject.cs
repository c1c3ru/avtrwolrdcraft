namespace PWC.Level;

public class LevelUnlockableObject : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelConsumerAreaBase> <>9__21_0; //Field offset: 0x8
		public static Predicate<LevelConsumerAreaBase> <>9__21_1; //Field offset: 0x10
		public static Action<LevelConsumerAreaBase> <>9__22_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <SyncState>b__22_0(LevelConsumerAreaBase consumerArea) { }

		internal bool <UpdateUnlockIndicator>b__21_0(LevelConsumerAreaBase dropArea) { }

		internal bool <UpdateUnlockIndicator>b__21_1(LevelConsumerAreaBase dropArea) { }

	}

	[SerializeField]
	private bool _lockItemsOnceInside; //Field offset: 0x20
	[SerializeField]
	private bool _onceUnlockedKeepUnlocked; //Field offset: 0x21
	[SerializeField]
	public UnityEvent OnUnlockedAction; //Field offset: 0x28
	[SerializeField]
	public UnityEvent OnRelockedAction; //Field offset: 0x30
	[SerializeField]
	private LevelConsumerAreaBase[] _dropAreas; //Field offset: 0x38
	[SerializeField]
	private LevelConsumerAreaBase[] _emptyDropAreas; //Field offset: 0x40
	[SerializeField]
	private bool _isPoofAndDestroy; //Field offset: 0x48
	[SerializeField]
	private bool _isUnlocked; //Field offset: 0x49
	[SerializeField]
	private bool _unlockedActionOnLoad; //Field offset: 0x4A
	public Func<Boolean> PerformCustomUnlockTestAction; //Field offset: 0x50
	[CompilerGenerated]
	private Action<LevelItem> OnItemConsumedAction; //Field offset: 0x58

	public event Action<LevelItem> OnItemConsumedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelConsumerAreaBase[] ConsumerAreas
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool IsUnlocked
	{
		 get { } //Length: 8
	}

	public LevelUnlockableObject() { }

	[CompilerGenerated]
	public void add_OnItemConsumedAction(Action<LevelItem> value) { }

	private void Awake() { }

	public LevelConsumerAreaBase[] get_ConsumerAreas() { }

	public bool get_IsUnlocked() { }

	public LevelItem GetFirstChildItemFromConsumerArea(int index) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAvatarRestAreaConsumed(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnAvatarRestAreaPickUp(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemConsumed(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnPostLevelInit() { }

	[CompilerGenerated]
	public void remove_OnItemConsumedAction(Action<LevelItem> value) { }

	public void set_ConsumerAreas(LevelConsumerAreaBase[] value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncState() { }

	private void UpdateUnlockIndicator() { }

}

