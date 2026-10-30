namespace Game.Level;

public class LevelDog : LevelAnimal, ILevelAvatar, ILevelHasClothingHandler
{
	internal enum DogType
	{
		Dog_A = 0,
		Dog_B = 1,
		Dog_C = 2,
		Dog_D = 3,
		Dog_E = 4,
		Dog_F = 6,
		Dog_G = 7,
		Dog_H = 8,
		Dog_I = 9,
		Dog_J = 10,
		Dog_M = 11,
		Dog_N = 12,
		Dog_K = 13,
		Dog_O = 14,
		Dog_P = 15,
		Dog_Q = 16,
	}

	public static readonly List<LevelDog> List; //Field offset: 0x0
	[SerializeField]
	protected Transform _parentForScale; //Field offset: 0x400
	[SerializeField]
	private LevelDropArea _mouthDropArea; //Field offset: 0x408
	private String[] _idleAnimations; //Field offset: 0x410
	private bool _didChangeSpineType; //Field offset: 0x418
	private DogSpineSkinsManager _skinsManager; //Field offset: 0x420
	private LevelDogClothingHandler _clothingHandler; //Field offset: 0x428
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x430
	[CompilerGenerated]
	private AvatarSizeType <MySizeType>k__BackingField; //Field offset: 0x438
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x43C
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x440

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

	private static LevelDog() { }

	public LevelDog() { }

	protected virtual void Awake() { }

	public override void DestroyAvatar(bool releaseChildrenItems) { }

	[CompilerGenerated]
	public override int get_ID() { }

	[CompilerGenerated]
	public override bool get_IsNewAvatar() { }

	[CompilerGenerated]
	public AvatarSizeType get_MySizeType() { }

	[CompilerGenerated]
	public override Action<LevelItem> get_OnPutItemInBoneAction() { }

	private string GetDogOldPrefabName(int id) { }

	protected virtual String[] GetIdleAnimations() { }

	public override LevelAvatarClothingHandler GetLevelAvatarClothingHandler() { }

	public override LevelItem GetLevelItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override void Init(int id = -1) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	protected virtual void OnLevelPrePostInit() { }

	public override void PlayProperIdleAnimation() { }

	public void PutInMouth(LevelItem levelItem, bool snap = false) { }

	private override AvatarSpineSkinsManagerBase PWC.Level.ILevelAvatar.GetSkinsManager() { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	[CompilerGenerated]
	public override void set_IsNewAvatar(bool value) { }

	[CompilerGenerated]
	private void set_MySizeType(AvatarSizeType value) { }

	[CompilerGenerated]
	public override void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

