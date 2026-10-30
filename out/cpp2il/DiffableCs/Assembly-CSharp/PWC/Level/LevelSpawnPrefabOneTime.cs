namespace PWC.Level;

public class LevelSpawnPrefabOneTime : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x20
	private BoolPD _didSpawnPDData; //Field offset: 0x28

	public LevelSpawnPrefabOneTime() { }

	private void Awake() { }

	protected override bool CanSpawn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnPreLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

