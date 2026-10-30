namespace Game.Level;

public class LevelFoldableSleepingBag : LevelItem
{
	[SerializeField]
	private bool _isFolded; //Field offset: 0x342
	[SerializeField]
	private Sprite _unfoldedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _foldedSprite; //Field offset: 0x350
	[SerializeField]
	private GameObject _front; //Field offset: 0x358
	[SerializeField]
	private LevelSleepingBagSleepArea _sleepingBagSleepArea; //Field offset: 0x360
	[SerializeField]
	private string _soundName; //Field offset: 0x368
	[SerializeField]
	private float _volume; //Field offset: 0x370

	public LevelFoldableSleepingBag() { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

