namespace PWC.Level;

public class LevelActionOnAnimationDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x28
	[SerializeField]
	private LevelRamp[] _ramps; //Field offset: 0x30
	[SerializeField]
	private SkeletonDataAsset _skeletonDataAsset; //Field offset: 0x38
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private String[] _animationsNames; //Field offset: 0x40
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private String[] _animationsNamesEnd; //Field offset: 0x48
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private String[] _animationsNamesEvent; //Field offset: 0x50
	[SerializeField]
	private UnityEvent _action; //Field offset: 0x58
	[SerializeField]
	private UnityEvent _actionEnd; //Field offset: 0x60
	[SerializeField]
	private UnityEvent _actionEvent; //Field offset: 0x68
	[SerializeField]
	private bool _isAnimationInHierarchySolves; //Field offset: 0x70
	[SerializeField]
	private bool _isSolvedOneTime; //Field offset: 0x71
	[SerializeField]
	private bool _isRadiusDependent; //Field offset: 0x72
	[ConditionalField("_isRadiusDependent", True, True, (array) null)]
	[SerializeField]
	private GameObject _radiusDependentObject; //Field offset: 0x78
	[ConditionalField("_isRadiusDependent", True, True, (array) null)]
	[SerializeField]
	private float _minDistance; //Field offset: 0x80
	[SerializeField]
	private int _avatarID; //Field offset: 0x84
	private bool _isSolved; //Field offset: 0x88
	private Dictionary<Int32, SkeletonAnimation> AvatarsToSkeletonDataDictionary; //Field offset: 0x90

	private void _dropArea_OnAllHierarchyChildrenDropAreaItemEndDropAction(LevelDropArea arg1, LevelItem arg2) { }

	private void _dropArea_OnAllHierarchyChildrenDropAreaItemPickUpAction(LevelDropArea arg1, LevelItem arg2) { }

	public LevelActionOnAnimationDropAreaHandler() { }

	private void AddListenerToAvatar(ILevelAvatar avatar) { }

	private void Awake() { }

	private void CheckIfAnimationHappened(TrackEntry trackEntry, String[] animationNames, UnityEvent action) { }

	private bool CheckIfAnimationIsPlayedNearObject() { }

	private void CheckIfDoorCanBeUnlocked(TrackEntry trackEntry) { }

	private void CheckIfDoorCanBeUnlockedEnd(TrackEntry trackEntry) { }

	private void CheckIfDoorCanBeUnlockedEvent(TrackEntry trackEntry, Event e) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsAnimationsExists(SkeletonAnimation skeletonAnimation) { }

	private bool IsCorrectSpineType(ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemEndDropAction(LevelItem levelItem) { }

	private void OnItemEndDropActionForRestArea(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnItemEndSlideAction(LevelItem levelItem) { }

	private void OnItemPickUpAction(LevelItem levelItem) { }

	private void OnItemPickUpActionForRestArea(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnItemStartSlideAction(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void RemoveListenerOfAvatar(ILevelAvatar avatar) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SitArea_OnAvatarEndDropAction(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private bool TryGenerateSpineTypeFromSkeletonDataAssetName(SkeletonDataAsset skeletonDataAsset, out SpineType spineType) { }

}

