namespace Game.Level;

public class LevelFlipOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	public Action OnFlipAction; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private string _soundName; //Field offset: 0x30

	public LevelFlipOnClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

