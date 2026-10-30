namespace PWC.Level.Maker.Customization;

public abstract class LevelMakerCustomizationObjectHandlerBase : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, ILevelSpawnDuringGameplay, IMultiplayer_IgnoreInputEvents, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public LevelMakerCustomizationObjectHandlerBase <>4__this; //Field offset: 0x10
		public string category; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal bool <GetConfigs>b__0(LevelMakerCustomizationHandlerBase x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public Multiplayer_EventData eventData; //Field offset: 0x10

		public <>c__DisplayClass34_0() { }

		internal bool <PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage>b__0(LevelMakerCustomizationHandlerBase x) { }

		internal bool <PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage>b__1(LevelMakerCustomizationHandlerBase x) { }

	}

	internal class Multiplayer_EventData
	{
		internal enum Type
		{
			None = 0,
			Color = 1,
			Texture = 2,
		}

		public Type type; //Field offset: 0x10
		[JsonProperty("cat")]
		public string category; //Field offset: 0x18
		[JsonProperty("tPath")]
		public string texturePath; //Field offset: 0x20
		public PJColor32 color; //Field offset: 0x28

		public Multiplayer_EventData() { }

	}

	[CompilerGenerated]
	private static int <LastPointerDownFrameCount>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelMakerCustomizationObjectHandlerBase> OnPointerClickAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<LevelMakerCustomizationObjectHandlerBase> OnDestroyAction; //Field offset: 0x10
	[SerializeField]
	private LevelMakerCustomizationHandlerBase[] _handlers; //Field offset: 0x20
	private readonly Dictionary<String, LevelMakerCCBase[]> _configsForCategories; //Field offset: 0x28
	protected Vector2 _lastPointerClickPosition; //Field offset: 0x30
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x38

	public static event Action<LevelMakerCustomizationObjectHandlerBase> OnDestroyAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelMakerCustomizationObjectHandlerBase> OnPointerClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private static int LastPointerDownFrameCount
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 76
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected LevelMakerCustomizationObjectHandlerBase() { }

	[CompilerGenerated]
	public static void add_OnDestroyAction(Action<LevelMakerCustomizationObjectHandlerBase> value) { }

	[CompilerGenerated]
	public static void add_OnPointerClickAction(Action<LevelMakerCustomizationObjectHandlerBase> value) { }

	protected override void Awake() { }

	[CompilerGenerated]
	public static int get_LastPointerDownFrameCount() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public abstract Bounds GetBoundsForMenu() { }

	public LevelMakerCCBase[] GetConfigs(string category) { }

	public LevelMakerCustomizationHandlerBase[] GetHandlers() { }

	public GameCameraBase GetMyCurrentCamera() { }

	public void Multiplayer_SendEvent(Multiplayer_EventData eventData) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnMakerModeChanged(bool isInMakerMode) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void OnPointerClick(Vector2 position) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	public void RemoteClick() { }

	[CompilerGenerated]
	public static void remove_OnDestroyAction(Action<LevelMakerCustomizationObjectHandlerBase> value) { }

	[CompilerGenerated]
	public static void remove_OnPointerClickAction(Action<LevelMakerCustomizationObjectHandlerBase> value) { }

	[CompilerGenerated]
	private static void set_LastPointerDownFrameCount(int value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void SetMakerMode(bool isInMakerMode) { }

}

