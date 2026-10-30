namespace Game.Level.RacingGame;

public class LevelRacingGameMoveButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private MoveType _moveType; //Field offset: 0x20
	[SerializeField]
	private LevelRacingGamePlayerCar _playerCar; //Field offset: 0x28
	[SerializeField]
	private CShape _CShape; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x48
	[SerializeField]
	private Sprite _pressedSprite; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _soundName; //Field offset: 0x60
	private LevelRacingGameManager _manager; //Field offset: 0x68

	public LevelRacingGameMoveButton() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__11_0() { }

	public void Init(LevelRacingGameManager manager) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void ToggleCShapeEnable(bool value) { }

	public void ToggleOnOffSprite(bool value) { }

	private void TogglePressedSprite(bool value) { }

}

