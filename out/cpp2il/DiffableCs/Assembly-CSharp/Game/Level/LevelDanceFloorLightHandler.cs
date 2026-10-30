namespace Game.Level;

public class LevelDanceFloorLightHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private int _delimiter; //Field offset: 0x28
	[SerializeField]
	private Sprite _firstLightBase; //Field offset: 0x30
	[SerializeField]
	private Sprite _secondLightBase; //Field offset: 0x38
	[SerializeField]
	private LevelColorChangingLight _levelColorChangingLight; //Field offset: 0x40
	[SerializeField]
	private Sprite _reflectionFirstLightBase; //Field offset: 0x48
	[SerializeField]
	private Sprite _reflectionSecondLightBase; //Field offset: 0x50
	[SerializeField]
	private SpriteRenderer _reflectionSpriteRenderer; //Field offset: 0x58

	public LevelDanceFloorLightHandler() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

