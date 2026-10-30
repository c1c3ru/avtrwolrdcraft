namespace Game.Level;

[AddComponentMenu(null)]
public class LevelPaperStack : InteractableItem, IPointerClickHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	private LevelSpawn _paperPrefab; //Field offset: 0x48
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x50
	private LevelPaperItemHandler _currentDraggedPapaer; //Field offset: 0x58

	public LevelPaperStack() { }

	private LevelPaperItemHandler CreateNewPaper() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

