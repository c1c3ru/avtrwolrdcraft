namespace Game.Level;

public class LevelAnimalIDHandler : MonoBehaviour, ILevelSpawnDuringGameplay, IHasTempID, IHasPersistentData, IRequirePDSceneObject
{
	private const string GLOBLAPD_DID_PERFORM_MIGRATION = "DidPerformMigration"; //Field offset: 0x0
	[SerializeField]
	private int _id; //Field offset: 0x20
	[SerializeField]
	private LevelAnimal _animal; //Field offset: 0x28
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x30
	[SerializeField]
	private string _oldSystemName; //Field offset: 0x38
	private bool _didOnReadyPostLoad; //Field offset: 0x40
	private bool _didPerformMigration; //Field offset: 0x41

	public int ID
	{
		 get { } //Length: 8
	}

	public LevelAnimalIDHandler() { }

	private void Awake() { }

	public void CopyComponent(LevelAnimalIDHandler original, GameObject destination) { }

	public void DeleteDidPerformMigration() { }

	private void EnsureOnReadyPostLoad() { }

	public int get_ID() { }

	private string GetDidPerformMigrationKey() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override int GetTempID() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

