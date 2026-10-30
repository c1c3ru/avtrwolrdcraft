namespace PWC.Level;

public class OnlySoundOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	protected string _soundName; //Field offset: 0x20

	public OnlySoundOnClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

