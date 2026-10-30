namespace Game.Level;

public class LevelEventCashRegisterCardMachine : LevelBleepOnEnterElement, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private string _label; //Field offset: 0x88
	[SerializeField]
	private bool _oneTimeEvent; //Field offset: 0x90
	[SerializeField]
	private UnityEvent OnScannedAction; //Field offset: 0x98
	private bool _eventHappened; //Field offset: 0xA0

	public LevelEventCashRegisterCardMachine() { }

	private bool CheckItemLabel(GameObject item) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnEnter(LevelDragActionByTagItemHandler handler) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

