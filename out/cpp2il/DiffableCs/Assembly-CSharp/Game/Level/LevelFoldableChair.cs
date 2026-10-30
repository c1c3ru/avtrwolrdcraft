namespace Game.Level;

[AddComponentMenu(null)]
public class LevelFoldableChair : LevelItem
{
	[SerializeField]
	private bool _isFolded; //Field offset: 0x342
	[SerializeField]
	private Sprite _unfoldedSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _foldedSprite; //Field offset: 0x350
	[SerializeField]
	private List<LevelAreaBase> _unfoldedAreas; //Field offset: 0x358
	[SerializeField]
	private List<LevelAreaBase> _foldedAreas; //Field offset: 0x360
	[SerializeField]
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x368
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x370
	[SerializeField]
	private LevelDropArea _topDropArea; //Field offset: 0x378
	[SerializeField]
	private string _openSoundName; //Field offset: 0x380
	[SerializeField]
	private string _closeSoundName; //Field offset: 0x388
	[SerializeField]
	private float _volume; //Field offset: 0x390

	public LevelFoldableChair() { }

	[CompilerGenerated]
	private void <OnPointerClickInternal>b__12_0(LevelAreaBase unfoldedArea) { }

	[CompilerGenerated]
	private void <OnPointerClickInternal>b__12_1(LevelAreaBase foldedArea) { }

	[CompilerGenerated]
	private void <SetPersistentData>b__15_0(LevelAreaBase unfoldedArea) { }

	[CompilerGenerated]
	private void <SetPersistentData>b__15_1(LevelAreaBase foldedArea) { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

