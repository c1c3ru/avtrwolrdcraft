namespace Game.Level;

public class LevelPoopBagCollectingCounter : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private float _numberOfTimesNeededToCollectPoop; //Field offset: 0x20
	[SerializeField]
	private LevelItem _gift; //Field offset: 0x28
	private int _numberOfTimesCollectedPoopWithABag; //Field offset: 0x30

	public LevelPoopBagCollectingCounter() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void PoopBagCollectingCounter(LevelItem levelItem_1, LevelItem levelItem_2) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

