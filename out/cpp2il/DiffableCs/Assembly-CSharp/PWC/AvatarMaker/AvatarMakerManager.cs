namespace PWC.AvatarMaker;

public class AvatarMakerManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__39 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerManager <>4__this; //Field offset: 0x20

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
		public <Start>d__39(int <>1__state) { }

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

	private class MakerHistoryStack
	{
		private readonly LinkedList<MakerExecuteActionBase> _actions; //Field offset: 0x10

		public int Count
		{
			 get { } //Length: 72
		}

		public MakerHistoryStack() { }

		public void Clear() { }

		public int get_Count() { }

		public void Push(MakerExecuteActionBase action) { }

		public bool TryPop(out MakerExecuteActionBase action) { }

	}

	private const int MAX_HISTORY_ACTIONS = 16; //Field offset: 0x0
	public static int CurrentCharacterID; //Field offset: 0x0
	public static Nullable<Int32> ForceFocusOnCategoryTypeOnNextStart; //Field offset: 0x4
	private static AvatarType _avatarType; //Field offset: 0xC
	[CompilerGenerated]
	private static AvatarMakerManager <Instance>k__BackingField; //Field offset: 0x10
	public static string CurrentExpansionPackNameOnInit; //Field offset: 0x18
	[SerializeField]
	protected Transform _menuParent; //Field offset: 0x20
	[SerializeField]
	protected Transform _avatarParent; //Field offset: 0x28
	[SerializeField]
	private Button _undoButton; //Field offset: 0x30
	[SerializeField]
	private Button _redoButton; //Field offset: 0x38
	protected bool _isNewAvatar; //Field offset: 0x40
	private GameObject _backgroundGameobject; //Field offset: 0x48
	protected AvatarMakerMenu _menu; //Field offset: 0x50
	protected AvatarMakerAvatarManagerBase _avatar; //Field offset: 0x58
	protected SpineType _localSpineType; //Field offset: 0x60
	private string _breed; //Field offset: 0x68
	private readonly MakerHistoryStack _undoStack; //Field offset: 0x70
	private readonly MakerHistoryStack _redoStack; //Field offset: 0x78
	private AvatarSpineData _avatarSpineDataOnEnter; //Field offset: 0x80
	private LevelAvatarData _levelAvatarDataOnEnter; //Field offset: 0x88
	private bool _wasNewAvatarOnEnter; //Field offset: 0x90
	private bool _didChangeAvatar; //Field offset: 0x91
	private GamePopup _revertPopup; //Field offset: 0x98
	private readonly Dictionary<String, AvatarSpineData> _sessionSpineDataByKey; //Field offset: 0xA0
	[CompilerGenerated]
	private SpineType <CurrentSpineType>k__BackingField; //Field offset: 0xA8

	public AvatarMakerAvatarManagerBase Avatar
	{
		 get { } //Length: 8
	}

	public GameObject Background
	{
		 get { } //Length: 8
	}

	private string BackgroundMusicName
	{
		private get { } //Length: 68
	}

	public SpineType CurrentSpineType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private static AvatarMakerManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public AvatarMakerMenu Menu
	{
		 get { } //Length: 8
	}

	public AvatarMakerManager() { }

	[CompilerGenerated]
	private void <ChangeBreedType>b__61_0() { }

	[CompilerGenerated]
	private void <ChangeSpineType>b__59_0() { }

	[CompilerGenerated]
	private void <TryRestoreSessionSpineData>b__57_0() { }

	private void AddActionToHistory(MakerExecuteActionBase executeAction) { }

	private void Awake() { }

	public void BackButton() { }

	public void ChangeBreedType(string breed) { }

	public void ChangeSpineType(SpineType spineType, AvatarSizeType sizeType) { }

	public void ClearHistory() { }

	public void DoneButton() { }

	private void EnsureUndoButtons() { }

	private void ExecuteHistoryAction(MakerHistoryStack actionsToExecute, MakerHistoryStack actionsToReverse) { }

	public AvatarMakerAvatarManagerBase get_Avatar() { }

	public GameObject get_Background() { }

	private string get_BackgroundMusicName() { }

	[CompilerGenerated]
	public SpineType get_CurrentSpineType() { }

	[CompilerGenerated]
	public static AvatarMakerManager get_Instance() { }

	public AvatarMakerMenu get_Menu() { }

	protected override string GetAvatarPrefabPath() { }

	public static AvatarType GetAvatarType() { }

	public string GetBreed() { }

	protected override string GetMenuPrefabPath() { }

	private static string GetSpineSessionKey(SpineType spineType) { }

	private string GetVariantSessionKey(SpineType spineType, AvatarSizeType sizeType, string breed) { }

	protected override void Init() { }

	private void LeaveToLobby(bool skipSave = false) { }

	public void MarkAvatarChanged() { }

	private bool OnAndroidBack() { }

	private void OnApplicationPause(bool pause) { }

	private void OnAvatarRebuilt(AvatarSpineData avatarSpineData) { }

	protected override void OnDestroy() { }

	private void OnRevertPopupAnswer(bool didKeepChanges) { }

	private void OnRevertPopupCancelled() { }

	private void OnSkinColored(Color displayColor, Color[] colors) { }

	private void OnSlotChanged(TemplateRestoreData templateRestoreData) { }

	private void OnTemplateColored(int categoryType, Color[] previousColors) { }

	private void PlayBackgroundMusicIfNeeded() { }

	protected override void PlayDoneButtonSound() { }

	public void RandomButton() { }

	public void RedoButton() { }

	private void RememberCurrentSpineData() { }

	private void ResetSpineData(SpineType spineType, AvatarSizeType sizeType) { }

	protected override void ResolveCurrentSpineType() { }

	public void RestoreAvatarSpineData(AvatarSpineData avatarSpineData) { }

	private void RestoreLevelAvatarDataOnEnter() { }

	private void SaveCharacterData() { }

	[CompilerGenerated]
	protected void set_CurrentSpineType(SpineType value) { }

	[CompilerGenerated]
	private static void set_Instance(AvatarMakerManager value) { }

	public static void SetAvatarType(AvatarType categoryType) { }

	[IteratorStateMachine(typeof(<Start>d__39))]
	protected override IEnumerator Start() { }

	private bool TryPresentRevertPopup() { }

	public bool TryRestoreSessionSize(AvatarSizeType sizeType) { }

	private bool TryRestoreSessionSpineData(string key, bool isNewAvatar, Nullable<Int32> categoryTypeToFocusOn = null) { }

	private bool TryRestoreSessionSpineType(SpineType spineType, AvatarSizeType sizeType) { }

	public void UndoButton() { }

	private void UnsubscribeFromRevertPopup() { }

	private void UpdateMakerBG() { }

}

