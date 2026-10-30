namespace PWC.Level;

public class LevelFryArea : LevelSingleItemDropArea, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected GameObject _onState; //Field offset: 0xD8
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0xE0
	[SerializeField]
	protected string _soundName; //Field offset: 0xE8
	[SerializeField]
	protected float _volume; //Field offset: 0xF0
	protected bool _isOn; //Field offset: 0xF4

	public override bool IsOn
	{
		 get { } //Length: 8
	}

	public LevelFryArea() { }

	protected virtual void Awake() { }

	public override bool get_IsOn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected override void SyncSound() { }

	private void SyncState(bool value) { }

	public void ToggleState() { }

}

