namespace Game.Level;

public class LevelMidiControllerListener : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _onState; //Field offset: 0x28
	[SerializeField]
	private Sprite _offState; //Field offset: 0x30

	public LevelMidiControllerListener() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnMidiControllerSetActive(bool value) { }

}

