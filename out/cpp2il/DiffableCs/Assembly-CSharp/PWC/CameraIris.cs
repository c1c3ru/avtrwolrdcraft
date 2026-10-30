namespace PWC;

public class CameraIris : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	private readonly Color _sunriseColor; //Field offset: 0x28
	private readonly Color _dayColor; //Field offset: 0x38
	private readonly Color _sunsetColor; //Field offset: 0x48
	private readonly Color _nightColor; //Field offset: 0x58

	public CameraIris() { }

	private void Awake() { }

	private Color GetCorrectIrisColor() { }

	public void Init() { }

	private void OnBackgroundPlanetClick() { }

	private void OnDestroy() { }

}

