namespace Game.Level;

public class LevelHiddenDoorPlush : LevelItem
{
	[CompilerGenerated]
	private static Action<HiddenDoorPlushType, Boolean> OnPlushInteractionAction; //Field offset: 0x0
	[SerializeField]
	private HiddenDoorPlushType _plushType; //Field offset: 0x344
	private bool _isOnRightPlatform; //Field offset: 0x348

	public static event Action<HiddenDoorPlushType, Boolean> OnPlushInteractionAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelHiddenDoorPlush() { }

	[CompilerGenerated]
	public static void add_OnPlushInteractionAction(Action<HiddenDoorPlushType, Boolean> value) { }

	private void CallOnPlushInteractionActionIfNeeded(HiddenDoorPlushType plushType, bool value) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	protected virtual void OnLevelPostInit() { }

	[CompilerGenerated]
	public static void remove_OnPlushInteractionAction(Action<HiddenDoorPlushType, Boolean> value) { }

}

