namespace Game.Level;

public class LevelStageTheme : LevelEntity, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private StageThemeType _stageTriggerType; //Field offset: 0x40
	[SerializeField]
	private LevelCharactersOnlyDropArea _charactersOnlyDropArea; //Field offset: 0x48
	private bool _isOn; //Field offset: 0x50

	public LevelStageTheme() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnStageCurtainClosed(StageThemeType stageTriggerType) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ThemeSetActive(bool performBasicDrop = true) { }

}

