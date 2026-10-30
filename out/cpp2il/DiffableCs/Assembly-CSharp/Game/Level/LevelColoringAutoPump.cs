namespace Game.Level;

public class LevelColoringAutoPump : LevelAutoPump, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private Color[] _colors; //Field offset: 0x38
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _runtimeColoredSpriteHandler; //Field offset: 0x40
	private int _index; //Field offset: 0x48

	public LevelColoringAutoPump() { }

	protected virtual void Awake() { }

	public void ColorIndexDecrease() { }

	public void ColorIndexIncrease() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnItemEndDropAction(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

