namespace PWC.Level;

public class LevelNamePDMigrationHelper : MonoBehaviour
{
	private static LevelNamePDMigrationHelper _instance; //Field offset: 0x0
	[SerializeField]
	private string _oldLevelName; //Field offset: 0x20
	private string _filePathToDeleteOnDataLoaded; //Field offset: 0x28
	private Nullable<Boolean> _isMigrating; //Field offset: 0x30

	public LevelNamePDMigrationHelper() { }

	private void Awake() { }

	public static bool IsMigrationInProgress() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private bool TryOverrideSceneName(Scene scene, out string sceneNameOverride) { }

}

