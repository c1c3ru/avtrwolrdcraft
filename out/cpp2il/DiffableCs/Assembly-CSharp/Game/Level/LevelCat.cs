namespace Game.Level;

public class LevelCat : LevelAnimal, ILevelAvatar, ILevelHasClothingHandler
{
	internal enum CatType
	{
		Cat_A = 0,
		Cat_C = 4,
		Cat_D = 5,
		Cat_E = 6,
		Cat_F = 8,
		Cat_B = 9,
		Cat_G = 10,
		Cat_H = 11,
	}

	[SerializeField]
	protected Transform _parentForScale; //Field offset: 0x400
	private readonly String[] _idleAnimations; //Field offset: 0x408
	private bool _didChangeSpineType; //Field offset: 0x410
	private CatSpineSkinsManager _skinsManager; //Field offset: 0x418
	private LevelCatClothingHandler _clothingHandler; //Field offset: 0x420
	[CompilerGenerated]
	private Action<LevelItem> <OnPutItemInBoneAction>k__BackingField; //Field offset: 0x428
	[CompilerGenerated]
	private AvatarSizeType <MySizeType>k__BackingField; //Field offset: 0x430
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x434
	[CompilerGenerated]
	private bool <IsNewAvatar>k__BackingField; //Field offset: 0x438

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

	public LevelCat() { }

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

	private string GetCatOldPrefabName(int id) { }

	protected virtual String[] GetIdleAnimations() { }

	public override LevelAvatarClothingHandler GetLevelAvatarClothingHandler() { }

	public override LevelItem GetLevelItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override void Init(int id = -1) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	protected virtual void OnLevelPrePostInit() { }

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

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

