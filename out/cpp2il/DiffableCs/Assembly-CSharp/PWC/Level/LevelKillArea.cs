namespace PWC.Level;

public class LevelKillArea : LevelDropArea, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase, ILevelMakerDisabledWhileInEditMode
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelItem> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnLevelPrePostInit>b__26_0(LevelItem x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public string sceneName; //Field offset: 0x10
		public LevelKillArea <>4__this; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <OnLevelPrePostInit>b__1(LevelItem item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_1
	{
		public LevelItem item; //Field offset: 0x10
		public <>c__DisplayClass26_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass26_1() { }

		internal void <OnLevelPrePostInit>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_2
	{
		public bool didSortInfrontFront; //Field offset: 0x10
		public <>c__DisplayClass26_1 CS$<>8__locals2; //Field offset: 0x18

		public <>c__DisplayClass26_2() { }

		internal void <OnLevelPrePostInit>b__2(float time) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public bool didSortBehindFront; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public LevelKillArea <>4__this; //Field offset: 0x20

		public <>c__DisplayClass28_0() { }

		internal void <KillItem>b__0(float time) { }

		internal void <KillItem>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public bool didSortInfrontFront; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public LevelKillArea <>4__this; //Field offset: 0x20

		public <>c__DisplayClass37_0() { }

		internal void <ForceClick>b__0(float time) { }

		internal void <ForceClick>b__1() { }

	}

	internal class EventWithArguments
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_0
		{
			public string guid; //Field offset: 0x10

			public <>c__DisplayClass2_0() { }

			internal bool <TryInvoke>b__0(PDPrefabReference x) { }

		}

		[Header("Conditions")]
		public List<PDPrefabReference> pDPrefabReferences; //Field offset: 0x10
		[Header("Event")]
		[Space]
		public UnityEvent<LevelItem> Event; //Field offset: 0x18

		public EventWithArguments() { }

		public bool TryInvoke(LevelItem item) { }

	}

	internal class Multiplayer_Data
	{
		public string sceneGuid; //Field offset: 0x10
		public PJVector2 fromPosition; //Field offset: 0x18

		public Multiplayer_Data() { }

	}

	[SerializeField]
	private SpriteRenderer _frontSprite; //Field offset: 0xD8
	[SerializeField]
	private CShape _touchShape; //Field offset: 0xE0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xE8
	[SerializeField]
	private string _soundName; //Field offset: 0xF0
	[SerializeField]
	private float _volume; //Field offset: 0xF8
	[SerializeField]
	private float _restoringTweenOffset; //Field offset: 0xFC
	[Header("On Kill")]
	[SerializeField]
	[Space]
	protected EventWithArguments[] _onKillItemArgs; //Field offset: 0x100
	[SerializeField]
	protected EventWithArguments[] _onEndKillItemArgs; //Field offset: 0x108
	[Header("On Restore")]
	[SerializeField]
	[Space]
	protected EventWithArguments[] _onRestoreItemWithArgs; //Field offset: 0x110
	protected readonly List<LevelItem> _itemsToDestroy; //Field offset: 0x118
	public UnityEvent onKillItemEvent; //Field offset: 0x120
	public UnityEvent onRestoreItemEvent; //Field offset: 0x128
	[CompilerGenerated]
	private LevelItem <LastKilledItem>k__BackingField; //Field offset: 0x130
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x138
	private LevelMakerItem _parentMakerItem; //Field offset: 0x140

	public private LevelItem LastKilledItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public virtual float MaxItemsWidth
	{
		 get { } //Length: 12
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelKillArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual bool CanItemFallOnSelf(LevelItem levelItem) { }

	public void ForceClick() { }

	[CompilerGenerated]
	public LevelItem get_LastKilledItem() { }

	public virtual float get_MaxItemsWidth() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	protected override Vector2 GetTweenDestinationOffset() { }

	protected override Vector2 GetTweenRestoringDestinationOffset() { }

	public override void KillItem(LevelItem levelItem, bool allowMultiplayerEvents = true) { }

	private void Multiplayer_KillItem(LevelItem levelItem) { }

	private void OnBeforeDestroyMakerItem(LevelMakerItem levelMakerItem) { }

	private void OnBeforeSceneLoadStage1() { }

	protected virtual void OnDestroy() { }

	protected void OnLevelPrePostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void OnPointerClickBeforeRestoringItem() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	protected override void OnPostKillItem(LevelItem levelItem) { }

	protected override void PlaySound() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object dataObject) { }

	[CompilerGenerated]
	private void set_LastKilledItem(LevelItem value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void TouchShapeSetActive() { }

}

