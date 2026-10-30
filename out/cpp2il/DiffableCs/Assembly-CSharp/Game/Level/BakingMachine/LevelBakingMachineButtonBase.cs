namespace Game.Level.BakingMachine;

public abstract class LevelBakingMachineButtonBase : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	internal enum StateType
	{
		None = 0,
		Normal = 1,
		Pressed = 2,
		Disabled = 3,
	}

	[Range(1, 6)]
	[SerializeField]
	private int _index; //Field offset: 0x20
	[SerializeField]
	private string _clickSoundName; //Field offset: 0x28
	protected LevelBakingMachine _machine; //Field offset: 0x30
	private StateType _currentStateType; //Field offset: 0x38

	protected LevelBakingMachineButtonBase() { }

	public string GetAnimationsNamePrefix() { }

	public StateType GetStateType() { }

	public void Init(LevelBakingMachine machine) { }

	protected abstract void OnClickInternal(PointerEventData eventData) { }

	protected override void PlayClickSound() { }

	public void SetState(StateType stateType) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

	private override void UnityEngine.EventSystems.IPointerDownHandler.OnPointerDown(PointerEventData eventData) { }

}

