namespace Game.Level;

public class LevelWallClock : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x20
	[SerializeField]
	private GameObject _bigNeedle; //Field offset: 0x28
	[SerializeField]
	private GameObject _smallNeedle; //Field offset: 0x30
	[SerializeField]
	private int _finalHour; //Field offset: 0x38
	[SerializeField]
	private int _finalMinute; //Field offset: 0x3C
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	[Space]
	private UnityEvent _onCorrectTimeEvent; //Field offset: 0x50
	private bool _isAnimating; //Field offset: 0x58
	private int _curHour; //Field offset: 0x5C
	private int _curMinute; //Field offset: 0x60

	public LevelWallClock() { }

	[CompilerGenerated]
	private void <AdvanceTime>b__12_0() { }

	[CompilerGenerated]
	private void <AdvanceTime>b__12_1() { }

	private void AdvanceTime(GameObject needle) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

