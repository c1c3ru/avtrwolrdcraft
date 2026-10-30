namespace PWC.Level;

public class LevelLockedDoorHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private bool _shakeOnOpenTrial; //Field offset: 0x28
	[SerializeField]
	private string _shakeSoundName; //Field offset: 0x30
	[SerializeField]
	private LevelItem _optionalLevelItem; //Field offset: 0x38
	[SerializeField]
	private string _openWithKeySound; //Field offset: 0x40
	[SerializeField]
	private bool _isLocked; //Field offset: 0x48
	private bool _isAnimatingShake; //Field offset: 0x49

	public LevelLockedDoorHandler() { }

	[CompilerGenerated]
	private bool <Awake>b__7_0() { }

	[CompilerGenerated]
	private void <PlayAnimateShake>b__10_0() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnFailedToOpenDoor() { }

	public void PlayAnimateShake() { }

	public void SetLockState(bool state) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

