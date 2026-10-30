namespace Game.Level;

public class LevelOnPairInteractionEvent : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private int _mainAvatarID; //Field offset: 0x20
	[SerializeField]
	private int _pairAvatarID; //Field offset: 0x24
	[SerializeField]
	private UnityEvent _onInteractionEvents; //Field offset: 0x28
	[SerializeField]
	private string _mainAvatarAnimationName; //Field offset: 0x30
	[SerializeField]
	private string _pairAvatarAnimationName; //Field offset: 0x38
	[SerializeField]
	private bool _isOneTime; //Field offset: 0x40
	private ILevelAvatar _mainAvatar; //Field offset: 0x48
	private bool _didIneractionHappened; //Field offset: 0x50

	public LevelOnPairInteractionEvent() { }

	private void Awake() { }

	private void FindAvatarsInScene(ILevelAvatar avatar) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void HandleDropEvents(LevelDropActionArea dropArea, LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void PlayAvatarsAnimations(ILevelAvatar mainAvatar, ILevelAvatar pairAvatar) { }

	private void RegisterToEndDropEvent(LevelCharacter character) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UnregisterToEndDropEvent(LevelItem levelItem) { }

}

