namespace PWC.PersistentData;

public class LevelOnSecretSolvedEvent : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelResetLevelWithItemData
{
	[SerializeField]
	public UnityEvent onSecretSolvedEvent; //Field offset: 0x20
	[SerializeField]
	protected List<SecretFullId> _secretsToCheckList; //Field offset: 0x28
	[SerializeField]
	private bool _isOneTimeResolved; //Field offset: 0x30
	[SerializeField]
	private bool _ensureExtraDataMatch; //Field offset: 0x31
	private int _totalSecretsSolved; //Field offset: 0x34
	private bool _wasSolved; //Field offset: 0x38

	public LevelOnSecretSolvedEvent() { }

	private void Awake() { }

	protected void CheckIsAllSecretsSolved() { }

	protected override bool CheckIsSolvedBaseOnData(string secretData) { }

	public void ForceWasSolved() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsSecretDataMatch(String[] extraData) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnSecretSolved(LevelType levelType, SecretData secretData) { }

	private override void PWC.Level.ILevelResetLevelWithItemData.OnResetLevelWithItemData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

