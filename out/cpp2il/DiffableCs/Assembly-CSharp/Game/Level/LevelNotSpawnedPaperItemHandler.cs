namespace Game.Level;

public class LevelNotSpawnedPaperItemHandler : LevelPaperItemHandler
{
	[SerializeField]
	private Sprite[] _shapes; //Field offset: 0x50
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x58
	[SerializeField]
	private string _soundName; //Field offset: 0x60
	private int _index; //Field offset: 0x68

	public LevelNotSpawnedPaperItemHandler() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void SetDrawingShapeColor(Color color) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetRandomDrawing() { }

}

