namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyFilledSlot : AvatarMakerLobbySlot
{
	[CompilerGenerated]
	private static Action<Int32> OnFilledSlotClickAction; //Field offset: 0x0
	[CompilerGenerated]
	private int <CharacterID>k__BackingField; //Field offset: 0x44
	[SerializeField]
	private AvatarMakerLobbyFilledSlotAnimationsHandler _animationsHandler; //Field offset: 0x48
	[SerializeField]
	private AvatarSpineSkinsManagerBase _skinsManager; //Field offset: 0x50
	[SerializeField]
	private string _idleAnimationName; //Field offset: 0x58
	[SerializeField]
	private string _onFocusAnimationName; //Field offset: 0x60
	private AnimationsSetParams _handWaving; //Field offset: 0x68

	public static event Action<Int32> OnFilledSlotClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private int CharacterID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	protected AvatarSpineSkinsManagerBase SkinsManager
	{
		 get { } //Length: 8
	}

	public AvatarMakerLobbyFilledSlot() { }

	[CompilerGenerated]
	public static void add_OnFilledSlotClickAction(Action<Int32> value) { }

	private void AnimateHandWaving() { }

	[CompilerGenerated]
	public int get_CharacterID() { }

	protected AvatarSpineSkinsManagerBase get_SkinsManager() { }

	public override void Init(int characterID) { }

	protected virtual void OnBeginDrag() { }

	protected virtual bool OnClickInternal() { }

	protected virtual void OnFocus(ScrollPoint scrollPoint) { }

	protected virtual void OnFocusLost(ScrollPoint scrollPoint) { }

	[CompilerGenerated]
	public static void remove_OnFilledSlotClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	private void set_CharacterID(int value) { }

	private void SetIdle() { }

}

