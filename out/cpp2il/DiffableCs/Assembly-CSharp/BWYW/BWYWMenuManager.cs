namespace BWYW;

public class BWYWMenuManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass100_0
	{
		public Vector2 localPosition; //Field offset: 0x10
		public RectTransform button; //Field offset: 0x18
		public BWYWMenuManager <>4__this; //Field offset: 0x20

		public <>c__DisplayClass100_0() { }

		internal void <AnimateButton>b__0(float localXPosition) { }

		internal void <AnimateButton>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass80_0
	{
		public ScrollFocusController controller; //Field offset: 0x0
		public ScrollPoint scrollPointToStartFrom; //Field offset: 0x0
		public BWYWMenuManager <>4__this; //Field offset: 0x0

		public <>c__DisplayClass80_0`1() { }

		internal void <FinalizeSetup>b__0(T slot) { }

		internal void <FinalizeSetup>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass83_0() { }

		internal void <OnChooseSkillPressed>b__0(BWYWSkillSlot x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass86_0
	{
		public string sceneToLoad; //Field offset: 0x10

		public <>c__DisplayClass86_0() { }

		internal void <OnGiftClaim>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <Init>d__67 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BWYWMenuManager <>4__this; //Field offset: 0x20

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
		public <Init>d__67(int <>1__state) { }

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

	private enum FTUEType
	{
		TASK_REVEAL = 0,
		TASK_CLAIM = 1,
		GIFT_CLAIM = 2,
	}

	private const int GIFTS_PER_DAY = 2; //Field offset: 0x0
	private const int HIP_HOP_AVATAR_ID = 100520; //Field offset: 0x0
	private const string DEFAULT_PREVIOUS_SCENE_NAME = "World"; //Field offset: 0x0
	public const string FTUE_CLAIM_GIFT_GUID = "BWYWMenuManagerFTUEClaimGiftGuid"; //Field offset: 0x0
	public const string FTUE_CLAIM_TASK_GUID = "BWYWMenuManagerFTUEClaimTaskGuid"; //Field offset: 0x0
	public const string FTUE_REVEAL_TASK_GUID = "BWYWMenuManagerFTUERevealTaskGuid"; //Field offset: 0x0
	[CompilerGenerated]
	private static BWYWMenuManager <Instance>k__BackingField; //Field offset: 0x0
	public static string PreviousSceneID; //Field offset: 0x8
	public static bool IsTasksDisplay; //Field offset: 0x10
	public static bool IsShowSkillChooseScreen; //Field offset: 0x11
	[SerializeField]
	private RectTransform _canvas; //Field offset: 0x20
	[SerializeField]
	private ScrollFocusController _scrollFocusController; //Field offset: 0x28
	[SerializeField]
	private ScrollFocusController _giftsScrollFocusController; //Field offset: 0x30
	[SerializeField]
	private ScrollFocusController _SkillsScrollFocusController; //Field offset: 0x38
	[SerializeField]
	private GameObject _tasksContent; //Field offset: 0x40
	[SerializeField]
	private GameObject _backButton; //Field offset: 0x48
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x50
	[SerializeField]
	private BWYWTaskSlot _taskSlotPrefab; //Field offset: 0x58
	[SerializeField]
	private GameUIElement _tasksContainerPrefab; //Field offset: 0x60
	[SerializeField]
	private BWYWFinalTaskSlot _finalTaskSlotPrefab; //Field offset: 0x68
	[SerializeField]
	private BWYWGiftSlot _giftSlotPrefab; //Field offset: 0x70
	[SerializeField]
	private BWYWFinalGiftSlot _finalGiftSlotPrefab; //Field offset: 0x78
	[SerializeField]
	private BWYWEmptySlot _emptySlotPrefab; //Field offset: 0x80
	[SerializeField]
	private BWYWSeparetorSlot _daySeparatorSlotPrefab; //Field offset: 0x88
	[SerializeField]
	private BWYWSkillSlot _skillSlotPrefab; //Field offset: 0x90
	[SerializeField]
	private BWYWTimerPanel _timerPanel; //Field offset: 0x98
	[SerializeField]
	private RectTransform _rewardsButton; //Field offset: 0xA0
	[SerializeField]
	private RectTransform _tasksButton; //Field offset: 0xA8
	[SerializeField]
	private BWYWSkillLevelProgressBarManager _progressBarManager; //Field offset: 0xB0
	[SerializeField]
	private BWYWMenuCharactersManager _charactersManager; //Field offset: 0xB8
	[SerializeField]
	private GameObject _taskNotClaimedNotification; //Field offset: 0xC0
	[SerializeField]
	private GameObject _giftNotClaimedNotification; //Field offset: 0xC8
	[SerializeField]
	private GameObject _tintOverlay; //Field offset: 0xD0
	[SerializeField]
	private GameObject _skillsCanvas; //Field offset: 0xD8
	[SerializeField]
	private Image _activateButton; //Field offset: 0xE0
	[SerializeField]
	private Sprite _activateButtonActivatedSprite; //Field offset: 0xE8
	[SerializeField]
	private Sprite _activateButtonDeactivatedSprite; //Field offset: 0xF0
	[SerializeField]
	private Image _background; //Field offset: 0xF8
	private UIItemPool<BWYWTaskSlot> _tasksItemsPool; //Field offset: 0x100
	private UIItemPool<GameUIElement> _tasksContainerPool; //Field offset: 0x108
	private float _tasksSpacing; //Field offset: 0x110
	private ScrollPoint _focusedScrollPoint; //Field offset: 0x118
	private int _numOfDays; //Field offset: 0x120
	private List<BWYWSlotBase> _slots; //Field offset: 0x128
	private List<BWYWSkillSlot> _skillSlots; //Field offset: 0x130
	private bool _isAnimatingTabsSwitch; //Field offset: 0x138
	private BWYWSkillMap _map; //Field offset: 0x140
	private BWYWGiftData _giftsData; //Field offset: 0x148
	private bool _shouldUseTaskRevealFTUE; //Field offset: 0x150
	private bool _shouldUseTaskClaimFTUE; //Field offset: 0x151
	private bool _shouldUseGiftClaimFTUE; //Field offset: 0x152
	private bool _isUsingFTUE; //Field offset: 0x153
	private bool _isOfflinePopUpActive; //Field offset: 0x154
	private bool _isGiftBeingClaimed; //Field offset: 0x155
	private int _secondsToNextDay; //Field offset: 0x158
	private bool _isTimerOn; //Field offset: 0x15C
	private BWYWTimerPanel _countdownPanel; //Field offset: 0x160
	private Coroutine _timerCoroutine; //Field offset: 0x168
	private SkillType _currentSkillType; //Field offset: 0x170
	private int _currentChapter; //Field offset: 0x174

	public private static BWYWMenuManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 104
	}

	private static BWYWMenuManager() { }

	public BWYWMenuManager() { }

	[CompilerGenerated]
	private void <OnTaskClaim>b__90_0() { }

	[CompilerGenerated]
	private void <ResetGiftsOfChapter>b__98_0() { }

	[CompilerGenerated]
	private void <SetupSkillsMenu>b__79_0(BWYWSkillSlot x) { }

	[CompilerGenerated]
	private void <SetupTimerIfNeeded>b__76_0() { }

	private void AnimateButton(bool isTaskButton, bool isChosen, bool isSnap = false) { }

	private void Awake() { }

	public void BackButton() { }

	private bool CanGiftBeClaimed(int giftId) { }

	public void ChangeToTab(bool isTaskTab) { }

	private void CheckFTUE() { }

	private void ClearSlots() { }

	private void FinalizeSetup(int slotToFocus, List<T> slots, ScrollFocusController controller) { }

	public static void ForceTimerEnd() { }

	[CompilerGenerated]
	public static BWYWMenuManager get_Instance() { }

	[IteratorStateMachine(typeof(<Init>d__67))]
	private IEnumerator Init() { }

	private void InitFTUE() { }

	private void InitMenu(bool updateCharacters) { }

	private bool IsUseFTUE(FTUEType type) { }

	public void MoveToScrollPoint(ScrollPoint scrollPoint, ScrollFocusController controller = null) { }

	public void OnActivateSkillPress() { }

	private bool OnAndroidBack() { }

	private void OnBeginDrag() { }

	public void OnChangeToGiftTab() { }

	public void OnChangeToTasksTab() { }

	private void OnChooseSkillPressed(int id) { }

	private void OnClockTick() { }

	private void OnCountdownEnd() { }

	private void OnDestroy() { }

	private void OnFinalTaskSlotClick(int taskId) { }

	private void OnFocus(ScrollPoint scrollPoint) { }

	private void OnFocusLost(ScrollPoint scrollPoint) { }

	private void OnGiftClaim(int giftId) { }

	private void OnSkillSlotClickAction(int id) { }

	private void OnSlotClick(int taskId) { }

	public void OnTaskClaim(int taskId) { }

	private void ProcessDayPassed() { }

	private void ResetGiftsOfChapter() { }

	public void RestoreInteractabilityAfterFTUE() { }

	[CompilerGenerated]
	private static void set_Instance(BWYWMenuManager value) { }

	private void SetButtonPressed() { }

	public void SetSkillType(SkillType skillType) { }

	private void SetupGifts() { }

	public void SetupSkillsMenu() { }

	private void SetupTasks() { }

	public void SetupTimer() { }

	private void SetupTimerIfNeeded() { }

	private void Start() { }

	public void StopTimer() { }

	private void ToggleTimer(bool isActive) { }

	private void UpdateActivateButtonState() { }

	private void UpdateClaimsNotifications() { }

}

