namespace Game.Level;

public class LevelHorse : LevelAnimal, ILevelAvatar, ILevelHasClothingHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAHandlerBase> <>9__32_0; //Field offset: 0x8
		public static Predicate<LevelCAHandlerBase> <>9__36_0; //Field offset: 0x10
		public static Predicate<LevelCAHandlerBase> <>9__41_0; //Field offset: 0x18
		public static Predicate<LevelCAHandlerBase> <>9__43_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <OnDestroy>b__43_0(LevelCAHandlerBase x) { }

		internal bool <OnItemPickUp>b__41_0(LevelCAHandlerBase x) { }

		internal bool <OnPostSaveProgress>b__36_0(LevelCAHandlerBase x) { }

		internal bool <UpdateRider>b__32_0(LevelCAHandlerBase x) { }

	}

	internal enum HorseType
	{
		Horse_A = 0,
		Horse_B = 1,
	}

	[SerializeField]
	protected Transform _parentForScale; //Field offset: 0x400
	[SerializeField]
	private LevelDropArea _saddleDropArea; //Field offset: 0x408
	[SerializeField]
	private LevelHorseClothingArea _saddleClothingArea; //Field offset: 0x410
	[SerializeField]
	private LevelReactionOfAvatarsOnCAAnimationHandler _riderReactionHandler; //Field offset: 0x418
	[SerializeField]
	private float _noSaddleOffset; //Field offset: 0x420
	private String[] _idleAnimations; //Field offset: 0x428
	private bool _didChangeSpineType; //Field offset: 0x430
	private HorseSpineSkinsManager _skinsManager; //Field offset: 0x438
	private LevelHorseClothingHandler _clothingHandler; //Field offset: 0x440
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x448
	[CompilerGenerated]
	private AvatarSizeType <MySizeType>k__BackingField; //Field offset: 0x450
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x454
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x458
	public ILevelAvatar _currentRider; //Field offset: 0x460
	private bool _hasSaddle; //Field offset: 0x468

	public private override int ID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override bool IsNewAvatar
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private AvatarSizeType MySizeType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override Action<LevelItem> OnPutItemInBoneAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public LevelHorse() { }

	public void AddAnimationToRider(string animationName, bool isLoop) { }

	protected virtual void Awake() { }

	public virtual bool CanBeDroppedOn(LevelDropArea dropArea) { }

	protected virtual bool CanSit() { }

	public override void DestroyAvatar(bool releaseChildrenItems) { }

	private void EnsureOnReadyPostLoad() { }

	[CompilerGenerated]
	public override int get_ID() { }

	[CompilerGenerated]
	public override bool get_IsNewAvatar() { }

	[CompilerGenerated]
	public AvatarSizeType get_MySizeType() { }

	[CompilerGenerated]
	public override Action<LevelItem> get_OnPutItemInBoneAction() { }

	protected virtual String[] GetIdleAnimations() { }

	public override LevelAvatarClothingHandler GetLevelAvatarClothingHandler() { }

	public override LevelItem GetLevelItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual bool HasSwimmingAnimations() { }

	public override void Init(int id = -1) { }

	private void OnAnimationBegin(LevelCAHandlerBase arg1, ICATarget arg2, LevelCAConfig arg3) { }

	private void OnAnimationEnd(LevelCAHandlerBase arg1, ICATarget arg2, LevelCAConfig arg3) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	private void OnItemEndDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void OnLevelPrePostInit() { }

	private void OnPostSaveProgress(Scene scene) { }

	private void OnPutClothing(string skin) { }

	private void OnRemoveClothing(string skin) { }

	public virtual void OnSpawnDuringGameplay() { }

	private bool OverrideCharacterPlayProperIdleAnimation() { }

	public override void PlayProperIdleAnimation() { }

	private override AvatarSpineSkinsManagerBase PWC.Level.ILevelAvatar.GetSkinsManager() { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	[CompilerGenerated]
	public override void set_IsNewAvatar(bool value) { }

	[CompilerGenerated]
	private void set_MySizeType(AvatarSizeType value) { }

	[CompilerGenerated]
	public override void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	public void SetAnimationToRider(string animationName, bool isLoop) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdateRider(ILevelAvatar avatar) { }

	private void UpdateRiderOffsetPoisition() { }

}

