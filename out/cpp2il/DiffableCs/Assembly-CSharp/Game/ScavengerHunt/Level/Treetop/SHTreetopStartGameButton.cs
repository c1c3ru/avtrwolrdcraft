namespace Game.ScavengerHunt.Level.Treetop;

public class SHTreetopStartGameButton : InteractableItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40
	[SerializeField]
	private Sprite _pressedSprite; //Field offset: 0x48
	[SerializeField]
	private Sprite _unpressedSprite; //Field offset: 0x50
	private SHTreetopManager _manager; //Field offset: 0x58

	public SHTreetopStartGameButton() { }

	private bool IsGameRunning() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void SetManager(SHTreetopManager manager) { }

	public void SyncAppearance(ScavengerHuntTypeHandler handler) { }

}

