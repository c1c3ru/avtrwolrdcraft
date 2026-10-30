namespace Game.Level;

public class LevelFoldableItem : LevelItem, ILevelFoldableable
{
	[SerializeField]
	protected bool _isFolded; //Field offset: 0x342
	[SerializeField]
	private Sprite _unfoldedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _foldedSprite; //Field offset: 0x350
	[SerializeField]
	protected List<GameObject> _unfoldedObjects; //Field offset: 0x358
	[SerializeField]
	private List<GameObject> _foldedObjects; //Field offset: 0x360
	[SerializeField]
	private string _soundName; //Field offset: 0x368
	[SerializeField]
	private float _volume; //Field offset: 0x370
	private List<IItemsHolderArea> _unfoldedItemsHolderAreas; //Field offset: 0x378
	private List<IItemsHolderArea> _foldedItemsHolderAreas; //Field offset: 0x380
	protected bool _shouldPerformBasicDropOnClick; //Field offset: 0x388

	public bool IsFolded
	{
		 get { } //Length: 8
	}

	public LevelFoldableItem() { }

	[CompilerGenerated]
	private void <SyncGameObjectsToState>b__20_0(GameObject unfoldedObject) { }

	[CompilerGenerated]
	private void <SyncGameObjectsToState>b__20_1(GameObject foldedObject) { }

	protected virtual void Awake() { }

	private void EnsureAreas() { }

	private void EnsureItemsHolderArea(List<GameObject> fromList, ref List<IItemsHolderArea>& areas) { }

	public bool get_IsFolded() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	private override bool PWC.Level.ILevelFoldableable.GetIsFolded() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetState(bool isFolded) { }

	private void SyncGameObjectsToState() { }

	private void SyncState() { }

	protected override void ToggleState() { }

}

