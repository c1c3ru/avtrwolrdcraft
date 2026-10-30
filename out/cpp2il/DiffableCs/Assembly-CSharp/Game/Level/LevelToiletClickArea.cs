namespace Game.Level;

[AddComponentMenu(null)]
public class LevelToiletClickArea : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20

	public LevelToiletClickArea() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

}

