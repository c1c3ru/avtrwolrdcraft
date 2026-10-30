namespace PWC.Level;

public class LevelGreenScreenEventsHandler : MonoBehaviour
{
	[SerializeField]
	private LevelGreenScreenSpriteRenderer _greenScreenSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private GreenScreenTextureLabelUnityEvent[] _greenScreenLabelEvents; //Field offset: 0x28

	public LevelGreenScreenEventsHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnSetTextureTextureLabelHandler(string label) { }

}

