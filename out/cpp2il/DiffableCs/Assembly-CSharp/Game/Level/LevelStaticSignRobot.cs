namespace Game.Level;

public class LevelStaticSignRobot : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDynamicSignRobot _robot; //Field offset: 0x20
	[SerializeField]
	private GameObject _gameObjectToDestroy; //Field offset: 0x28
	private bool _isRevived; //Field offset: 0x30

	public LevelStaticSignRobot() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void ReviveRobot(bool isJumpOutOfFrame) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

