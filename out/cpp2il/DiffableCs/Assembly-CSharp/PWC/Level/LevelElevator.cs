namespace PWC.Level;

public class LevelElevator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelElevator <>4__this; //Field offset: 0x10
		public bool isInsideRemoteCall; //Field offset: 0x18
		public int index; //Field offset: 0x1C
		public Action <>9__2; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass10_0() { }

		internal void <OnElevatorButtonClick>b__0() { }

		internal void <OnElevatorButtonClick>b__1() { }

		internal void <OnElevatorButtonClick>b__2() { }

	}

	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private LevelCrossLevelDropArea _crossDropArea; //Field offset: 0x28
	[SerializeField]
	private LevelElevatorDoor _door; //Field offset: 0x30
	[SerializeField]
	private LevelElevatorButton[] _buttons; //Field offset: 0x38
	[SerializeField]
	private bool _isEnabled; //Field offset: 0x40

	public LevelElevator() { }

	[CompilerGenerated]
	private void <OnLevelPostInit>b__7_0() { }

	private void Awake() { }

	private void ButtonsSetActive(bool value) { }

	private void OnDestroy() { }

	public void OnElevatorButtonClick(int index) { }

	private void OnLevelPostInit() { }

	private void PlayMovingSound(Action onCompleteAction) { }

}

