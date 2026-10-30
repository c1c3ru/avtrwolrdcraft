namespace Game.Level.CashRegister;

public class LevelStoreAlarm : LevelActionOnItemEnter
{
	[SerializeField]
	protected LevelDropArea _alarmArea; //Field offset: 0x48
	private bool isAlarmOn; //Field offset: 0x50

	public LevelStoreAlarm() { }

	protected virtual void Awake() { }

	private bool IsCharHoldingItem(LevelCharacter character) { }

	private bool OnCharacterEndDropAnimation(ILevelAvatar avatar) { }

	protected virtual void OnItemEnter(LevelItem levelItem) { }

	protected virtual void OnItemExit(LevelItem levelItem, ExitReasonType exitReasonType) { }

}

