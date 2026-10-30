namespace PWC.Level;

public class LevelFryDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected GameObject _onState; //Field offset: 0x20
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	protected string _soundName; //Field offset: 0x30
	[SerializeField]
	protected float _volume; //Field offset: 0x38
	protected bool _isOn; //Field offset: 0x3C
	private LevelDropArea _dropArea; //Field offset: 0x40

	public override bool IsOn
	{
		 get { } //Length: 8
	}

	public LevelFryDropAreaHandler() { }

	private void Awake() { }

	public override bool get_IsOn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected override void SyncSound() { }

	private void SyncState(bool value) { }

	public void ToggleState() { }

}

