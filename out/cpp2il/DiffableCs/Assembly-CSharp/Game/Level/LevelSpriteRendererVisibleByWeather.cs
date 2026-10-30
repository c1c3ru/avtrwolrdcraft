namespace Game.Level;

public class LevelSpriteRendererVisibleByWeather : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private List<WeatherType> _supportedWeatherTypes; //Field offset: 0x28
	[SerializeField]
	private bool _isALight; //Field offset: 0x30
	private bool _hasInit; //Field offset: 0x31
	private int _tweenID; //Field offset: 0x34

	public List<WeatherType> SupportedWeatherTypes
	{
		 get { } //Length: 8
	}

	public LevelSpriteRendererVisibleByWeather() { }

	private void Awake() { }

	public List<WeatherType> get_SupportedWeatherTypes() { }

	private void OnDestroy() { }

	private void OnWeatherChange(WeatherType weatherType) { }

}

