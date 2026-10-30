namespace Game.Level;

[AddComponentMenu(null)]
public class LevelMakeupBox : LevelItem
{
	[SerializeField]
	private bool _isOpen; //Field offset: 0x342
	[SerializeField]
	private SpriteRenderer _frontSpriteRenderer; //Field offset: 0x348
	[SerializeField]
	private CShape _frontCShape; //Field offset: 0x350
	[SerializeField]
	private Sprite _openedState; //Field offset: 0x358
	[SerializeField]
	private Sprite _closedState; //Field offset: 0x360

	public LevelMakeupBox() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void SetFrontSprite() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

