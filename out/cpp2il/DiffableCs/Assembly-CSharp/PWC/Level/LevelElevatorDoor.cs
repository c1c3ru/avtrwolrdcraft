namespace PWC.Level;

public class LevelElevatorDoor : MonoBehaviour
{
	[SerializeField]
	private bool _isClosed; //Field offset: 0x20
	[SerializeField]
	private LevelUndroppableArea _leftDoor; //Field offset: 0x28
	[SerializeField]
	private float _leftDoorClosedX; //Field offset: 0x30
	[SerializeField]
	private float _leftDoorOpenedX; //Field offset: 0x34
	[SerializeField]
	private LevelUndroppableArea _rightDoor; //Field offset: 0x38
	[SerializeField]
	private float _rightDoorClosedX; //Field offset: 0x40
	[SerializeField]
	private float _rightDoorOpenedX; //Field offset: 0x44
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	private int _tweenID; //Field offset: 0x50

	public LevelElevatorDoor() { }

	[CompilerGenerated]
	private void <Animate>b__11_0(float t) { }

	private void Animate(bool value, Action onCompleteAction) { }

	public void Close(Action onCompleteAction = null) { }

	public void Open(Action onCompleteAction = null) { }

	public void SetClose() { }

}

