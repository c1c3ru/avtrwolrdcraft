namespace PWC.Level;

public abstract class LevelAvatarClothingAreaBase : LevelConsumerAreaBase, ILevelCanWearClothing, IBeginDragHandler, IEventSystemHandler, IDragHandler, ILevelSpawnDuringGameplay, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private bool _allowDragOffClothing; //Field offset: 0x51
	private int _pointerId; //Field offset: 0x54
	[CompilerGenerated]
	private HashSet<Int32> <ClothingTypesHashed>k__BackingField; //Field offset: 0x58
	private Int32[] _intClothingTypes; //Field offset: 0x60
	private LevelAvatarClothingHandler _clothingHandler; //Field offset: 0x68
	protected SpineType _spineType; //Field offset: 0x70
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x74

	public private HashSet<Int32> ClothingTypesHashed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelAvatarClothingAreaBase() { }

	[CompilerGenerated]
	private void <OnBeginDrag>b__25_0(int categoryType, string skinName) { }

	protected virtual void Awake() { }

	private void EnsureClothingHandler() { }

	[CompilerGenerated]
	public HashSet<Int32> get_ClothingTypesHashed() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public Vector2 GetPointerPosition() { }

	private Vector2 GetPointerScreenPosition() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	private void OnCurrentSkinsSynced() { }

	protected virtual void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	protected override void OnPutClothing(string skinName) { }

	private void OnReadyPostLoad() { }

	protected override void OnRemoveClothing(string skinName) { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	private void set_ClothingTypesHashed(HashSet<Int32> value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void SetAllowDragOffClothing(bool value) { }

	protected void SetClothingTypes(T[] clothingTypes) { }

	private void SyncCShape() { }

	public override bool TryPutClothing(ILevelClothingItem clothingItem) { }

}

