namespace Game.Level;

public class MovingBoat : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private float _targetXPositionLeft; //Field offset: 0x20
	[SerializeField]
	private float _targetXPositionRight; //Field offset: 0x24
	[SerializeField]
	private float _movementSpeed; //Field offset: 0x28
	[SerializeField]
	private bool _isMovingRight; //Field offset: 0x2C
	[SerializeField]
	private string _soundName; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38

	public MovingBoat() { }

	[CompilerGenerated]
	private void <StartMovingLeft>b__9_0() { }

	[CompilerGenerated]
	private void <StartMovingRight>b__10_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void StartMovingLeft() { }

	private void StartMovingRight() { }

	private void StartMovment() { }

}

