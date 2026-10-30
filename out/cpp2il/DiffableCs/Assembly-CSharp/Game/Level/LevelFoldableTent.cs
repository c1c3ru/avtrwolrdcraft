namespace Game.Level;

public class LevelFoldableTent : LevelItem
{
	[SerializeField]
	private bool _isFolded; //Field offset: 0x342
	[SerializeField]
	private Sprite _unfoldedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _foldedSprite; //Field offset: 0x350
	[SerializeField]
	private List<GameObject> _unfoldedObjects; //Field offset: 0x358
	[SerializeField]
	private List<LevelAreaBase> _unfoldedAreas; //Field offset: 0x360
	[SerializeField]
	private List<GameObject> _foldedObjects; //Field offset: 0x368
	[SerializeField]
	private List<LevelAreaBase> _foldedAreas; //Field offset: 0x370
	[SerializeField]
	private LevelTentSleepArea _tentSleepArea; //Field offset: 0x378
	[SerializeField]
	private LevelDropArea _insideDropArea; //Field offset: 0x380
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x388
	[SerializeField]
	private string _soundName; //Field offset: 0x390
	[SerializeField]
	private float _volume; //Field offset: 0x398

	public LevelFoldableTent() { }

	[CompilerGenerated]
	private void <SetFoldedState>b__15_0(GameObject unfoldedObject) { }

	[CompilerGenerated]
	private void <SetFoldedState>b__15_1(LevelAreaBase unfoldedArea) { }

	[CompilerGenerated]
	private void <SetFoldedState>b__15_2(GameObject foldedObject) { }

	[CompilerGenerated]
	private void <SetFoldedState>b__15_3(LevelAreaBase foldedArea) { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	private void SetFoldedState() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

