namespace Game.World;

public class WeatherButton : ButtonBase
{
	[SerializeField]
	private WeatherType _weatherType; //Field offset: 0x20
	[SerializeField]
	private float _intensity; //Field offset: 0x24
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Sprite _selected; //Field offset: 0x30
	[SerializeField]
	private Sprite _notSelected; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	private string _world; //Field offset: 0x48

	public WeatherButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	public void SetWeatherData() { }

}

