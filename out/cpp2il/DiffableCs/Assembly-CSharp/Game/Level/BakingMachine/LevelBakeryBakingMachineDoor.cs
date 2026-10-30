namespace Game.Level.BakingMachine;

public class LevelBakeryBakingMachineDoor : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	[SerializeField]
	private LevelBakeryBakingMachine _bakingMachine; //Field offset: 0x20

	public LevelBakeryBakingMachineDoor() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

}

