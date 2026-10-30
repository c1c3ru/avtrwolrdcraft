namespace Game.Level;

public class LevelCatEatingSign : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private LevelItem _gift; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onCatSignEatingEvent; //Field offset: 0x40
	private LevelCharacter _sittingCharacter; //Field offset: 0x48
	private LevelItem _foodItem; //Field offset: 0x50
	private bool _hasFood; //Field offset: 0x58
	private bool _giftTaken; //Field offset: 0x59

	public LevelCatEatingSign() { }

	[CompilerGenerated]
	private void <CatAttemptsToEat>b__13_0() { }

	private void Awake() { }

	private void CatAttemptsToEat(TrackEntry trackEntry) { }

	private void CatChecksForFood(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnCharacterEndDropAction(LevelAvatarRestAreaBase levelCharacterRestAreaBase, ILevelAvatar avatar) { }

	private void OnCharacterPickUpAction(LevelAvatarRestAreaBase levelCharacterRestAreaBase, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void PlaySoundIfNeeded(TrackEntry trackEntry, Event e) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

