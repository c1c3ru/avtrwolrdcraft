namespace Game.Level.MovingTraingBackground;

public class LevelStationManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelStationButton> <>9__16_0; //Field offset: 0x8
		public static Action<LevelStationButton> <>9__19_0; //Field offset: 0x10
		public static Action<LevelStationButton> <>9__19_1; //Field offset: 0x18
		public static Action<LevelStationButton> <>9__20_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <OnButtonClick>b__16_0(LevelStationButton button) { }

		internal void <OnTransitionEndStop>b__19_0(LevelStationButton button) { }

		internal void <OnTransitionEndStop>b__19_1(LevelStationButton button) { }

		internal void <SyncButtons>b__20_0(LevelStationButton button) { }

	}

	[CompilerGenerated]
	private static Action<Int32> UpdateClickedButton; //Field offset: 0x0
	[SerializeField]
	private GameObject _exitButton; //Field offset: 0x20
	[SerializeField]
	private List<LevelStationButton> _buttons; //Field offset: 0x28
	[SerializeField]
	private MovingBG _movingBG; //Field offset: 0x30
	[SerializeField]
	private LevelToggleableSprite[] _stopButtons; //Field offset: 0x38
	[SerializeField]
	private bool _allowExitDuringTransition; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onTransitionStart; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onTransitionEndStart; //Field offset: 0x50
	[SerializeField]
	private UnityEvent _onTransitionEnd; //Field offset: 0x58
	private LevelToggleableSprite _exitButtonToggleableSprite; //Field offset: 0x60
	private LevelLevelSwitcher _exitButtonLevelSwitcher; //Field offset: 0x68
	private int _currentStationIndex; //Field offset: 0x70

	public static event Action<Int32> UpdateClickedButton
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelStationManager() { }

	[CompilerGenerated]
	public static void add_UpdateClickedButton(Action<Int32> value) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnButtonClick(int buttonIndex) { }

	private void OnDestroy() { }

	private void OnStopButtonClick(int _) { }

	private void OnTransitionEndStart() { }

	private void OnTransitionEndStop() { }

	[CompilerGenerated]
	public static void remove_UpdateClickedButton(Action<Int32> value) { }

	private void SetExitButtonState(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncButtons() { }

	private void UpdateExitDestination() { }

}

