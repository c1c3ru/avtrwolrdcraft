namespace PWC.UGC;

public class LevelChangeAmbienceByMapArea : MonoBehaviour
{
	private const string FOLDER_PATH = "Level/ChangeableBackgrounds/SoundData/AmbienceData_"; //Field offset: 0x0
	private BackgroundPlanetSoundHandler _bgPlanetSoundHandler; //Field offset: 0x20

	public LevelChangeAmbienceByMapArea() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

