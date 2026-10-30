namespace Game.Level;

public class LevelAlarmClock : LevelItem
{
	private enum StateType
	{
		None = 0,
		Off = 1,
		Tick = 2,
		Alarm = 3,
	}

	private const string TICK_AUDIO_CLIP_NAME = "Clock_Ticking_Loop"; //Field offset: 0x0
	private const string ALARM_AUDIO_CLIP_NAME = "Clock_Alarm_Loop"; //Field offset: 0x0
	[SerializeField]
	private GameObject _handle; //Field offset: 0x348
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x350
	private int _tweenId; //Field offset: 0x358
	private StateType _stateType; //Field offset: 0x35C

	public LevelAlarmClock() { }

	[CompilerGenerated]
	private void <SetAlarm>b__12_0() { }

	private void ChangeState() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void SetAlarm() { }

	private void SetOff() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetTick() { }

	private void SyncState() { }

}

