namespace Game.Level;

public class LevelCameraScreenFilmRollDefaultFilm : LevelCameraScreenFilmRoll
{
	[SerializeField]
	private Texture2D _defaultTexture; //Field offset: 0x90

	public LevelCameraScreenFilmRollDefaultFilm() { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPreInit() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

