namespace PWC.Level;

public class LevelClothingItemHandler : MonoBehaviour, ILevelClothingItem, IInteractableItem, IMultiplayer_NetworkIdentityBase, IInteractableItem
{
	[SerializeField]
	protected SpineType _spineType; //Field offset: 0x20
	[SerializeField]
	protected string _skinName; //Field offset: 0x28
	private Nullable<Int32> _categoryType; //Field offset: 0x30
	protected bool _isDressed; //Field offset: 0x38
	private LevelItem _levelItem; //Field offset: 0x40
	[CompilerGenerated]
	private readonly Item <PWC.Level.ILevelClothingItem.ClothingMapItem>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private bool <IsRestoredClothingItem>k__BackingField; //Field offset: 0x54

	public override bool IsRestoredClothingItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private override Item PWC.Level.ILevelClothingItem.ClothingMapItem
	{
		[CompilerGenerated]
		private get { } //Length: 8
	}

	private override AvatarSpineColoringConfig PWC.Level.ILevelClothingItem.ColoringConfig
	{
		private get { } //Length: 12
	}

	private override Color[] PWC.Level.ILevelClothingItem.Colors
	{
		private get { } //Length: 8
	}

	public LevelClothingItemHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public override bool get_IsRestoredClothingItem() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public static string GetBulkDataKey(int avatarId, string skinName) { }

	public override int GetCategoryType() { }

	public override string GetSkinName() { }

	private string Multiplayer_GetKey() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	[CompilerGenerated]
	private override Item PWC.Level.ILevelClothingItem.get_ClothingMapItem() { }

	private override AvatarSpineColoringConfig PWC.Level.ILevelClothingItem.get_ColoringConfig() { }

	private override Color[] PWC.Level.ILevelClothingItem.get_Colors() { }

	private override LevelItem PWC.Level.ILevelClothingItem.GetLevelItem() { }

	private override SpineType PWC.Level.ILevelClothingItem.GetSpineType() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropCharacterInteraction.IInteractableItem.Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	private void SaveBulkData(ILevelEntity levelEntity) { }

	[CompilerGenerated]
	public override void set_IsRestoredClothingItem(bool value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	public void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

