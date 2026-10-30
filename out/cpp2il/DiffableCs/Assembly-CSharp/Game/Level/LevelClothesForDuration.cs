namespace Game.Level;

public class LevelClothesForDuration : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	internal class Config
	{
		public String[] items; //Field offset: 0x10

		public Config() { }

	}

	[SerializeField]
	private int _interval; //Field offset: 0x20
	[SerializeField]
	private TextAsset[] _configFiles; //Field offset: 0x28
	[SerializeField]
	private Transform[] _parents; //Field offset: 0x30
	private bool _didTimePass; //Field offset: 0x38
	private int _index; //Field offset: 0x3C
	private long _dateTimeTicks; //Field offset: 0x40
	private Config[] _allConfigs; //Field offset: 0x48

	public LevelClothesForDuration() { }

	private void Awake() { }

	private void EnsureNothingInAllPlaces() { }

	private void GetAllConfigs() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsInConfigs(LevelClothingItem clothingItem) { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private void ReplaceClothesWithNextClothes() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

