namespace Game.Level;

public class LevelMetalDetectorItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private Sprite _turnedOffSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _turnedOnFarSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _turnedOnCloseSprite; //Field offset: 0x40
	[SerializeField]
	private LevelDigAreaDetector _levelDigAreaDetectorFar; //Field offset: 0x48
	[SerializeField]
	private LevelDigAreaDetector _levelDigAreaDetectorClose; //Field offset: 0x50
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _onSound; //Field offset: 0x60
	[SerializeField]
	private string _offSound; //Field offset: 0x68
	[SerializeField]
	private string _staticLoopSound; //Field offset: 0x70
	[SerializeField]
	private string _fastLoopSound; //Field offset: 0x78
	[SerializeField]
	private string _foundSound; //Field offset: 0x80
	private bool _isHeld; //Field offset: 0x88

	public LevelMetalDetectorItemHandler() { }

	private void Awake() { }

	public void CheckForStateUpdate() { }

	private void OnBeginDrag(DragDropItemBase dragDropItemBase, PointerEventData pointerEvenData) { }

	private void OnBeginLandAction(LevelDropArea levelDropArea) { }

	private void OnDestroy() { }

}

