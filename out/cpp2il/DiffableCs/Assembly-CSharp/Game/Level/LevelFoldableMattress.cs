namespace Game.Level;

[AddComponentMenu(null)]
public class LevelFoldableMattress : LevelItem, ILevelFoldableable
{
	[SerializeField]
	private bool _isFolded; //Field offset: 0x342
	[SerializeField]
	private Sprite _unfoldedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _foldedSprite; //Field offset: 0x350
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x358
	[SerializeField]
	private string _unfoldSoundName; //Field offset: 0x360
	[SerializeField]
	private string _foldSoundName; //Field offset: 0x368
	[SerializeField]
	private float _volume; //Field offset: 0x370

	public LevelFoldableMattress() { }

	protected virtual void Awake() { }

	private void CanDropAreaConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	private override bool PWC.Level.ILevelFoldableable.GetIsFolded() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

