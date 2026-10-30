namespace Game.Level;

public class LevelLightSecretHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelLight[] _requiredOnLights; //Field offset: 0x20
	[SerializeField]
	private LevelLight[] _requiredOffLights; //Field offset: 0x28
	[SerializeField]
	private bool _isOneTimeOnly; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onSolveAction; //Field offset: 0x38
	private int _turnedOffLightsCounter; //Field offset: 0x40
	private int _turnedOnLightsCounter; //Field offset: 0x44
	private bool _isSolved; //Field offset: 0x48

	public LevelLightSecretHandler() { }

	public void Awake() { }

	private void CheckIsSolved() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnRequiredOffLampStateChange(bool isOn) { }

	private void OnRequiredOnLampStateChange(bool isOn) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

