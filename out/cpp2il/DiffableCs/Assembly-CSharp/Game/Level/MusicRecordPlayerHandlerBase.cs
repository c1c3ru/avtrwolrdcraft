namespace Game.Level;

public abstract class MusicRecordPlayerHandlerBase : LevelConsumerAreaBase, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	protected SpriteRenderer _recordOnPlayer; //Field offset: 0x58
	protected LevelMusicRecord _currentRecord; //Field offset: 0x60

	protected MusicRecordPlayerHandlerBase() { }

	public abstract void OnPointerClick(PointerEventData eventData) { }

	protected abstract bool OnPreBeginDrag(GameObject receiver, PointerEventData eventData) { }

	protected abstract bool OnPreClick(GameObject receiver, PointerEventData eventData) { }

	protected override bool OnPreEndDrag(GameObject receiver, PointerEventData eventData) { }

	public override void PutRecord(LevelMusicRecord record, bool forceTurnOn = true) { }

	protected override void SetRecord(bool onPlayer) { }

}

