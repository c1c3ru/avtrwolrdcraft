namespace Game.Level;

public class LevelWaffleMachineButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelWaffleMachine _waffleMachine; //Field offset: 0x20
	[SerializeField]
	private int index; //Field offset: 0x28

	public LevelWaffleMachineButton() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

