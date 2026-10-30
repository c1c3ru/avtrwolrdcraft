namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<AvatarMakerLobbySlot> <>9__43_2; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <DeleteButton>b__43_2(AvatarMakerLobbySlot s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public AvatarType avatarType; //Field offset: 0x10
		public AvatarMakerLobbyManager <>4__this; //Field offset: 0x18
		public ScrollPoint scrollPointToStartFrom; //Field offset: 0x20

		public <>c__DisplayClass32_0() { }

		internal bool <SetupCharacters>b__0(int id) { }

		internal void <SetupCharacters>b__1(AvatarMakerLobbySlot character) { }

		internal void <SetupCharacters>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public ScrollPoint scrollPoint; //Field offset: 0x10

		public <>c__DisplayClass35_0() { }

		internal bool <SetPlatformSizeFor>b__0(AvatarMakerLobbySlot s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public AvatarMakerLobbyManager <>4__this; //Field offset: 0x10
		public AvatarMakerLobbyFilledSlot characterToDelete; //Field offset: 0x18
		public AvatarMakerLobbySlot slot; //Field offset: 0x20
		public Action <>9__3; //Field offset: 0x28

		public <>c__DisplayClass43_0() { }

		internal bool <DeleteButton>b__0(AvatarMakerLobbySlot character) { }

		internal void <DeleteButton>b__1() { }

		internal void <DeleteButton>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_1
	{
		public ScrollPoint scrollPoint; //Field offset: 0x10

		public <>c__DisplayClass43_1() { }

		internal bool <DeleteButton>b__4(AvatarMakerLobbySlot character) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerLobbyManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__25(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static AvatarMakerLobbyManager <Instance>k__BackingField; //Field offset: 0x0
	public const string EMPTY_SLOT_FTUE_GUID = "AvatarMakerLobbyManagerEmptySlotFTUEGuid"; //Field offset: 0x0
	private const string DEFAULT_PREVIOUS_SCENE_NAME = "World"; //Field offset: 0x0
	private const int SPACE_BETWEEN_AVATARS_SLOTS = 175; //Field offset: 0x0
	private const int SPACE_BETWEEN_VEHICLES_SLOTS = 300; //Field offset: 0x0
	private const int EXTRA_WIDTH_PER_FILLED_CAR_SLOT = 300; //Field offset: 0x0
	public static string PreviousSceneID; //Field offset: 0x8
	[SerializeField]
	private RectTransform _canvas; //Field offset: 0x20
	[SerializeField]
	private ScrollFocusController _scrollFocusController; //Field offset: 0x28
	[SerializeField]
	private AvatarMakerLobbyPlatform _platform; //Field offset: 0x30
	[SerializeField]
	private GameObject _backButton; //Field offset: 0x38
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x40
	[SerializeField]
	private AvatarMakerLobbyEmptySlot _emptySlotPrefab; //Field offset: 0x48
	[SerializeField]
	private AvatarMakerLobbyBannerSlot _bannerSlotPrefab; //Field offset: 0x50
	[SerializeField]
	private SerializableDictionaryBase<SpineType, AvatarMakerLobbyFilledSlot> _filledSlotPrefabBySpineType; //Field offset: 0x58
	[SerializeField]
	private HorizontalLayoutGroup _slotsLayoutGroup; //Field offset: 0x60
	private List<AvatarMakerLobbySlot> _slots; //Field offset: 0x68
	private ScrollPoint _focusedScrollPoint; //Field offset: 0x70
	private bool _isDeletingCharacter; //Field offset: 0x78
	private bool _shouldUseFTUE; //Field offset: 0x79
	private int _numberOfAvatars; //Field offset: 0x7C

	public private static AvatarMakerLobbyManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 104
	}

	private static AvatarMakerLobbyManager() { }

	public AvatarMakerLobbyManager() { }

	private void AddWidthForFilledCarSlots(int numberOfFilledSlots) { }

	private void Awake() { }

	public void BackButton() { }

	public void DeleteButton() { }

	[CompilerGenerated]
	public static AvatarMakerLobbyManager get_Instance() { }

	public static string GetMakerSceneName() { }

	private int GetNumOfBigVehicles() { }

	private static AvatarMakerLobbyPlatformSize GetPlatformSizeFor(AvatarMakerLobbySlot slot) { }

	public void MoveToScrollPoint(ScrollPoint scrollPoint) { }

	private bool OnAndroidBack() { }

	private void OnBeginDrag() { }

	private void OnDestroy() { }

	private void OnEmptySlotClick() { }

	private void OnFilledSlotClick(int characterID) { }

	private void OnFocus(ScrollPoint scrollPoint) { }

	private void OnFocusLost(ScrollPoint scrollPoint) { }

	public static void OpenScene(AvatarType avatarType) { }

	private void PerformFTUECheck() { }

	private void RefreshSlotsLayout() { }

	[CompilerGenerated]
	private static void set_Instance(AvatarMakerLobbyManager value) { }

	private void SetPlatformSizeFor(ScrollPoint scrollPoint, bool immediate = false) { }

	private void SetupCharacters() { }

	private void SetupScrollRectContent() { }

	private void SetupSlotsLayout() { }

	[IteratorStateMachine(typeof(<Start>d__25))]
	private IEnumerator Start() { }

}

