namespace Game.Level.CashRegister;

public class LevelCashRegisterMonitor : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected LevelBleepOnEnterElement _cardsScanner; //Field offset: 0x20
	[SerializeField]
	protected TextMesh _textMesh; //Field offset: 0x28
	[SerializeField]
	protected int _maxDigitsCount; //Field offset: 0x30
	private int _currentMoneyAmount; //Field offset: 0x34

	public LevelCashRegisterMonitor() { }

	private void AddMoney(int amount) { }

	public void AddMoneyFromItem(LevelItem levelItem) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBleep(LevelDragActionByTagItemHandler handler) { }

	private void OnDestroy() { }

	[ContextMenu("Reset Money Amount")]
	public void ResetMoneyAmount() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

