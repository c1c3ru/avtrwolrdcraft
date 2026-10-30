namespace Game.Level;

public class LevelItemsAutoPlayAnimationOnAvatar : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private string _animationName; //Field offset: 0x28
	[SerializeField]
	private bool _isSpecificAvatar; //Field offset: 0x30
	[ConditionalField("_isSpecificAvatar", True, True, (array) null)]
	[SerializeField]
	private int _avatarID; //Field offset: 0x34
	[SerializeField]
	private AvatarHandType _forceHandType; //Field offset: 0x38
	[SerializeField]
	private bool _isOneTimeUse; //Field offset: 0x3C
	[SerializeField]
	public UnityEvent OnAnimationEndAction; //Field offset: 0x40
	private bool _isSwitchingHand; //Field offset: 0x48
	private bool _isAnimationEndHappened; //Field offset: 0x49

	public LevelItemsAutoPlayAnimationOnAvatar() { }

	private void Awake() { }

	private void EnsureHand(ILevelHasHands target, AvatarHandType characterHandType) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	private void OnDestroy() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

