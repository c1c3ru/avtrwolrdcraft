namespace Game.Level;

public class LevelCrossAllLevelMannequinHandler : MonoBehaviour
{
	private LevelMannequin _levelMannequin; //Field offset: 0x20
	private string _sceneGuid; //Field offset: 0x28

	public LevelCrossAllLevelMannequinHandler() { }

	private void Awake() { }

	protected override string GetBulkDataKey() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

}

