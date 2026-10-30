namespace Game.Level;

public class LevelLockedDoorKeyCardHandler : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _lockedDoor; //Field offset: 0x58
	[SerializeField]
	private Sprite _lockedState; //Field offset: 0x60
	[SerializeField]
	private Sprite _unlockedState; //Field offset: 0x68
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x70
	[SerializeField]
	private string _soundName; //Field offset: 0x78
	[SerializeField]
	public UnityEvent OnUnlockAction; //Field offset: 0x80
	[SerializeField]
	private bool _isUnlockedOnce; //Field offset: 0x88
	private bool _isUnlocked; //Field offset: 0x89

	public LevelLockedDoorKeyCardHandler() { }

	protected virtual void Awake() { }

	public void ForceLock() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public bool IsUnlocked() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UnlockDoor() { }

}

