namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyEmptySlot : AvatarMakerLobbySlot
{
	[CompilerGenerated]
	private static Action OnEmptySlotClickAction; //Field offset: 0x0
	[SerializeField]
	private NonDrawingGraphic _nonDrawingGraphic; //Field offset: 0x48
	[SerializeField]
	private Image _avatarImage; //Field offset: 0x50

	public static event Action OnEmptySlotClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public AvatarMakerLobbyEmptySlot() { }

	[CompilerGenerated]
	public static void add_OnEmptySlotClickAction(Action value) { }

	protected virtual void Awake() { }

	private void Init() { }

	protected virtual bool OnClickInternal() { }

	[CompilerGenerated]
	public static void remove_OnEmptySlotClickAction(Action value) { }

}

