namespace PWC.Level;

public class LevelClothingItem : LevelItem, ILevelClothingItem, IPDPrefabPackSpawn, ILevelSpawnDuringGameplay, IInteractableItem, IMultiplayer_NetworkIdentityBase, ILevelMakerUIMenuItem
{
	public const string HANGED_SUFFIX = "__Hanged"; //Field offset: 0x0
	public const string FOLDED_SUFFIX = "__Folded"; //Field offset: 0x0
	public const string COLOR_SUFFIX = "_Color"; //Field offset: 0x0
	[SerializeField]
	protected SpineType _spineType; //Field offset: 0x344
	private Nullable<Int32> _categoryType; //Field offset: 0x348
	protected string _skinName; //Field offset: 0x350
	protected bool _isDressed; //Field offset: 0x358
	protected bool _didInit; //Field offset: 0x359
	[CompilerGenerated]
	private Item <ClothingMapItem>k__BackingField; //Field offset: 0x360
	[CompilerGenerated]
	private AvatarSpineColoringConfig <ColoringConfig>k__BackingField; //Field offset: 0x368
	[CompilerGenerated]
	private Color[] <Colors>k__BackingField; //Field offset: 0x380
	[CompilerGenerated]
	private bool <IsRestoredClothingItem>k__BackingField; //Field offset: 0x388

	public private override Item ClothingMapItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override AvatarSpineColoringConfig ColoringConfig
	{
		[CompilerGenerated]
		 get { } //Length: 24
		[CompilerGenerated]
		private set { } //Length: 32
	}

	public private override Color[] Colors
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public override bool IsRestoredClothingItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelClothingItem() { }

	public virtual void AddToCustomRestoreDataBeforeDestroyWhileInGameplay() { }

	protected override void ApplyColors() { }

	protected void AssignColoringAndMapData() { }

	protected virtual void Awake() { }

	protected void EnsureColors() { }

	[CompilerGenerated]
	public override Item get_ClothingMapItem() { }

	[CompilerGenerated]
	public override AvatarSpineColoringConfig get_ColoringConfig() { }

	[CompilerGenerated]
	public override Color[] get_Colors() { }

	[CompilerGenerated]
	public override bool get_IsRestoredClothingItem() { }

	public override int GetCategoryType() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public override string GetSkinName() { }

	public override SpineType GetSpineType() { }

	private string GetSpriteNameFromSprite(SpriteRenderer spriteRenderer) { }

	public override void InitIfNeeded() { }

	protected void InitMaterial(Material material) { }

	public override void Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	public virtual void Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnLevelPostInit() { }

	private override LevelItem PWC.Level.ILevelClothingItem.GetLevelItem() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private override void PWC.PersistentData.IPDPrefabPackSpawn.OnSpawnFromPDPrefabPack() { }

	[CompilerGenerated]
	private void set_ClothingMapItem(Item value) { }

	[CompilerGenerated]
	private void set_ColoringConfig(AvatarSpineColoringConfig value) { }

	[CompilerGenerated]
	private void set_Colors(Color[] value) { }

	[CompilerGenerated]
	public override void set_IsRestoredClothingItem(bool value) { }

	public void SetColors(Color[] colors) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSkinName(string skinName) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

	public virtual bool TryDropInteractionWithCharacter(LevelCharacter character, out MPEventIdentifierData mpData) { }

	public Sprite TryLoadSpriteFromAssets(string fullName) { }

}

