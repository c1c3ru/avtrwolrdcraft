namespace Game.Level;

[RequireComponent(typeof(SkeletonAnimation))]
public class LevelSeesaw : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelSeesawSit _leftSeesawSit; //Field offset: 0x20
	[SerializeField]
	private LevelSeesawSit _rightSeesawSit; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	private bool _haveCharacterOnLeftSit; //Field offset: 0x40
	private bool _haveCharacterOnRightSit; //Field offset: 0x41
	private bool _init; //Field offset: 0x42

	public LevelSeesaw() { }

	[CompilerGenerated]
	private void <DoSwingIfPossible>b__15_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <DoSwingIfPossible>b__15_1() { }

	private void AnimateIfNeeded() { }

	private void Awake() { }

	private bool DoSwingIfPossible() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBeginDropOnSit(LevelSeesawSit sit, LevelItem character, LevelCASeesawBaseSitAreaHandler levelCAParentHandler) { }

	private void OnBeginSwing() { }

	private void OnDestroy() { }

	private void OnEndDropOnSit(LevelSeesawSit sit, LevelItem character) { }

	private void OnInterrupteSit(LevelSeesawSit sit, LevelItem character, LevelCASeesawBaseSitAreaHandler levelCAParentHandler) { }

	private void OnLevelPostInit() { }

	private void OnPickUpFromSit(LevelSeesawSit sit, LevelItem character, LevelCASeesawBaseSitAreaHandler levelCAParentHandler) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

