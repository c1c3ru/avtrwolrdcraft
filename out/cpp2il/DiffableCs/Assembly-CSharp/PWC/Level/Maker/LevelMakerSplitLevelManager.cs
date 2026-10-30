namespace PWC.Level.Maker;

public class LevelMakerSplitLevelManager : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Boolean> OnSplitLevelModeChangeAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnPreChangeContentAction; //Field offset: 0x8
	[CompilerGenerated]
	private static LevelMakerSplitLevelManager <Instance>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private LevelMakerSplitLevelCamera _splitLevelCamera; //Field offset: 0x20
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x28
	private string _currentLevelName; //Field offset: 0x30
	private LevelMakerSplitLevelContent _currentLevelContent; //Field offset: 0x38
	private bool _isSplitLevelVisible; //Field offset: 0x40

	public static event Action OnPreChangeContentAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action<Boolean> OnSplitLevelModeChangeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private static LevelMakerSplitLevelManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public LevelMakerSplitLevelManager() { }

	[CompilerGenerated]
	public static void add_OnPreChangeContentAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnSplitLevelModeChangeAction(Action<Boolean> value) { }

	private void Awake() { }

	private void DestroyCurrentLevelContent() { }

	[CompilerGenerated]
	public static LevelMakerSplitLevelManager get_Instance() { }

	public LevelMakerSplitLevelCamera GetSplitLevelCamera() { }

	public bool IsSplitLevelVisible() { }

	private void LoadCurrentLevel() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnPreChangeContentAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnSplitLevelModeChangeAction(Action<Boolean> value) { }

	private void SaveCurrentData() { }

	[CompilerGenerated]
	private static void set_Instance(LevelMakerSplitLevelManager value) { }

	public void SetLevel(string levelName) { }

	public void SetSplitLevelVisible(bool value) { }

	private void SpawnLevelContent(string levelName) { }

	private bool TryOverrideGetFileName(Scene scene, out string fileName) { }

}

