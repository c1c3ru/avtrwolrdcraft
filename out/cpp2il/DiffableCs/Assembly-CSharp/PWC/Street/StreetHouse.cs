namespace PWC.Street;

public class StreetHouse : InteractableItem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<StreetHouseLevel> <>9__25_1; //Field offset: 0x8
		public static Action<StreetHouseLevel> <>9__25_3; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Init>b__25_1(StreetHouseLevel level) { }

		internal void <Init>b__25_3(StreetHouseLevel level) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public SkeletonAnimation spine; //Field offset: 0x10
		public StreetHouse <>4__this; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal void <Init>b__2(TrackEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public Color color; //Field offset: 0x10
		public StreetHouse <>4__this; //Field offset: 0x20

		public <>c__DisplayClass30_0() { }

		internal void <FadeClosed>b__0(float alphaValue) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public Color color; //Field offset: 0x10
		public StreetHouse <>4__this; //Field offset: 0x20

		public <>c__DisplayClass31_0() { }

		internal void <OnBackgroundPlanetClick>b__0(float alphaValue) { }

	}

	[CompilerGenerated]
	private static bool <IsSpineAnimating>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<StreetHouse> OnHouseEligibleForDeletionAction; //Field offset: 0x8
	[CompilerGenerated]
	private string <ID>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private bool <IsCentered>k__BackingField; //Field offset: 0x48
	[SerializeField]
	private WorldMakerBuildingType _buildingType; //Field offset: 0x4C
	[SerializeField]
	private SpriteRenderer _closed; //Field offset: 0x50
	[SerializeField]
	private SpriteRenderer _windowLights; //Field offset: 0x58
	[SerializeField]
	private List<StreetHouseLevel> _levels; //Field offset: 0x60
	private SpriteRenderer[] _spriteRenderers; //Field offset: 0x68

	public static event Action<StreetHouse> OnHouseEligibleForDeletionAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public WorldMakerBuildingType BuildingType
	{
		 get { } //Length: 8
	}

	public private string ID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsCentered
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private static bool IsSpineAnimating
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public List<StreetHouseLevel> Levels
	{
		 get { } //Length: 8
	}

	public StreetHouse() { }

	[CompilerGenerated]
	private void <Init>b__25_0(StreetHouseLevel level) { }

	[CompilerGenerated]
	public static void add_OnHouseEligibleForDeletionAction(Action<StreetHouse> value) { }

	protected virtual void Awake() { }

	private void FadeClosed(bool value) { }

	public WorldMakerBuildingType get_BuildingType() { }

	[CompilerGenerated]
	public string get_ID() { }

	[CompilerGenerated]
	public bool get_IsCentered() { }

	[CompilerGenerated]
	public static bool get_IsSpineAnimating() { }

	public List<StreetHouseLevel> get_Levels() { }

	public void Init(string id, float xPosition, bool isNew) { }

	private void OnBackgroundPlanetClick() { }

	private void OnCameraBeginDrag() { }

	protected virtual void OnDestroy() { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public virtual void OnPointerUp(PointerEventData eventData) { }

	private void OnTweenToXPositionComplete(StreetHouse house) { }

	[CompilerGenerated]
	public static void remove_OnHouseEligibleForDeletionAction(Action<StreetHouse> value) { }

	[CompilerGenerated]
	private void set_ID(string value) { }

	[CompilerGenerated]
	protected void set_IsCentered(bool value) { }

	[CompilerGenerated]
	private static void set_IsSpineAnimating(bool value) { }

}

