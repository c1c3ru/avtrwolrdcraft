namespace PWC.Level;

public class LevelUIScrollCharacterItem : GameUIElement, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public int avatarId; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal bool <OnPointerClick>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_1
	{
		public ILevelAvatar childAvatar; //Field offset: 0x10

		public <>c__DisplayClass16_1() { }

		internal bool <OnPointerClick>b__1(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private static Action OnCharacterSpawnOnDragAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnSyncAvatarPhoneStateAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<Int32> OnCharacterPreConsumedAction; //Field offset: 0x10
	private ContactsPage _pageParent; //Field offset: 0x28
	private ContactsThumb _thumb; //Field offset: 0x30

	public static event Action<Int32> OnCharacterPreConsumedAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action OnCharacterSpawnOnDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static event Action OnSyncAvatarPhoneStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public LevelUIScrollCharacterItem() { }

	[CompilerGenerated]
	public static void add_OnCharacterPreConsumedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void add_OnCharacterSpawnOnDragAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnSyncAvatarPhoneStateAction(Action value) { }

	private void Awake() { }

	private bool Multiplayer_CanSpawnAvatar() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnCharacterPreConsumedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnCharacterSpawnOnDragAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnSyncAvatarPhoneStateAction(Action value) { }

}

