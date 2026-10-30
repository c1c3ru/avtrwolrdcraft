namespace Game.Level;

public class LevelSpineScaleItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SkeletonAnimation _scale; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _leftDropArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _rightDropArea; //Field offset: 0x30
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x38

	public LevelSpineScaleItemHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemEndDrop_Left(LevelItem levelItem) { }

	private void OnItemEndDrop_Right(LevelItem levelItem) { }

	private void OnItemPickUp_Left(LevelItem levelItem) { }

	private void OnItemPickUp_Right(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

