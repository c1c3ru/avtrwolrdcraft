namespace Game.Level;

public class LevelPlayParticalesOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private string _soundName; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem[] _particales; //Field offset: 0x30

	public LevelPlayParticalesOnClick() { }

	public void ForceClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

