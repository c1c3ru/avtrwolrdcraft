namespace Game.Level;

public class LevelMidiControllerSpeakerPedal : StationaryInteractableItem
{
	[SerializeField]
	private LevelMidiControllerSpeaker _speaker; //Field offset: 0x40

	public LevelMidiControllerSpeakerPedal() { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	public virtual void OnPointerUp(PointerEventData eventData) { }

}

