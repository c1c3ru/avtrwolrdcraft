namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTrainDoors : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelTrain _train; //Field offset: 0x40

	public LevelTrainDoors() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

