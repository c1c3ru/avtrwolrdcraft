namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelSimpleSoundPlayer : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private string _soundName; //Field offset: 0x20
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	[SerializeField]
	private bool _isLoop; //Field offset: 0x30

	public LevelSimpleSoundPlayer() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

