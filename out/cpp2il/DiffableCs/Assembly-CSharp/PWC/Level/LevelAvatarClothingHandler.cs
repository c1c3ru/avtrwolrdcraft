namespace PWC.Level;

public class LevelAvatarClothingHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int32, Vector2, Boolean> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <.ctor>b__27_0(int x, Vector2 y) { }

	}

	internal class Multiplayer_DragClothingData
	{
		public int categoryType; //Field offset: 0x10
		public string skinName; //Field offset: 0x18

		public Multiplayer_DragClothingData() { }

	}

	[CompilerGenerated]
	private static Action<Int32, String> OnPutClothingStaticAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Int32, String> OnRemoveClothingStaticAction; //Field offset: 0x8
	private readonly Dictionary<Int32, String> _currentSkins; //Field offset: 0x10
	protected readonly AvatarSpineSkinsManagerBase _avatarSpineSkinsManager; //Field offset: 0x18
	private readonly Transform _owner; //Field offset: 0x20
	private readonly SpineType _spineType; //Field offset: 0x28
	private AvatarSizeType _sizeType; //Field offset: 0x2C
	private bool _isClothingLocked; //Field offset: 0x30
	private MPDataGeneratorHandle _mpDataGeneratorHandle; //Field offset: 0x38
	private readonly Func<Int32, Vector2, Boolean> _canPickUpClothingAction; //Field offset: 0x40
	private readonly ICATarget _ownerCATarget; //Field offset: 0x48
	private readonly LevelSkinCATargetHandler _skinCATargetHandler; //Field offset: 0x50
	[CompilerGenerated]
	private Action<String> OnPutClothingAction; //Field offset: 0x58
	[CompilerGenerated]
	private Action<String> OnRemoveClothingAction; //Field offset: 0x60
	[CompilerGenerated]
	private Action OnCurrentSkinsSyncedAction; //Field offset: 0x68

	public event Action OnCurrentSkinsSyncedAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action<String> OnPutClothingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action<Int32, String> OnPutClothingStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public event Action<String> OnRemoveClothingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action<Int32, String> OnRemoveClothingStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public IReadOnlyDictionary<Int32, String> CurrentSkins
	{
		 get { } //Length: 8
	}

	public LevelAvatarClothingHandler(SpineType spineType, Transform owner, AvatarSpineSkinsManagerBase avatarSpineSkinsManager, Func<Int32, Vector2, Boolean> canPickUpClothingAction = null, ICATarget ownerCATarget = null) { }

	[CompilerGenerated]
	private void <PutClothing>b__34_0(string removedSkinName) { }

	[CompilerGenerated]
	public void add_OnCurrentSkinsSyncedAction(Action value) { }

	[CompilerGenerated]
	public void add_OnPutClothingAction(Action<String> value) { }

	[CompilerGenerated]
	public static void add_OnPutClothingStaticAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public void add_OnRemoveClothingAction(Action<String> value) { }

	[CompilerGenerated]
	public static void add_OnRemoveClothingStaticAction(Action<Int32, String> value) { }

	public IReadOnlyDictionary<Int32, String> get_CurrentSkins() { }

	public SpineType GetSpineType() { }

	public void Multiplayer_DragOutClothing(int categoryType, string skinName) { }

	public void PutClothing(int categoryType, string skinName, PWSpriteColorType colorType = 0, Color[] colors = null, bool throwExistingClothingItem = true) { }

	[CompilerGenerated]
	public void remove_OnCurrentSkinsSyncedAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnPutClothingAction(Action<String> value) { }

	[CompilerGenerated]
	public static void remove_OnPutClothingStaticAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public void remove_OnRemoveClothingAction(Action<String> value) { }

	[CompilerGenerated]
	public static void remove_OnRemoveClothingStaticAction(Action<Int32, String> value) { }

	public void SetClothingLocked(bool isLocked) { }

	public void SetSizeType(AvatarSizeType sizeType) { }

	private ILevelClothingItem SpawnClothingItem(int categoryType, string skinName) { }

	public void SyncCurrentSkins() { }

	protected override void ThrowExistingClothingItemWhenPutClothing(int clothingType, int parentCategoryType) { }

	public bool TryDragOutClothing(int categoryType, PointerEventData eventData, Vector2 pointerPosition, Action<Int32, String> onSuccessAction = null) { }

	private bool TryDragOutExistingClothingItems(int clothingType, PointerEventData eventData, Vector2 pointerPosition, out int currentCategoryType, Action<Int32, String> onSuccessAction = null) { }

	public bool TryPutClothing(int categoryType, string skinName, PWSpriteColorType colorType = 0, Color[] colors = null, bool throwExistingClothingItem = true) { }

	public bool TryRemoveSkinAndThrowClothingItem(int clothingType, bool ignoreChildCategories = true, bool initiateChainEvent = false) { }

	public bool TryRemoveSkinAndThrowClothingItem(int clothingType, out ILevelClothingItem clothingItem, bool ignoreChildCategories = true, bool initiateChainEvent = false) { }

	protected bool TryThrowExistingClothingItem(int clothingType) { }

	protected bool TryThrowExistingClothingItem(int clothingType, out int removedCategoryType) { }

	protected bool TryThrowExistingClothingItem(int clothingType, out int removedCategoryType, out ILevelClothingItem clothingItem) { }

}

