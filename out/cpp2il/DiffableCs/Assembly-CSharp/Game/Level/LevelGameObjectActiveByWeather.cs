namespace Game.Level;

public class LevelGameObjectActiveByWeather : MonoBehaviour
{
	[SerializeField]
	private GameObject _clearGameObject; //Field offset: 0x20
	[SerializeField]
	private GameObject _rainGameObject; //Field offset: 0x28
	[SerializeField]
	private GameObject _snowGameObject; //Field offset: 0x30
	[SerializeField]
	private bool _preventActivating; //Field offset: 0x38

	public LevelGameObjectActiveByWeather() { }

	private void Awake() { }

	public void Editor_PerformDiagnosticsTest(bool isInScene) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	private void OnWeatherPostInit() { }

	private void SetActiveWeather(WeatherType weatherType) { }

}

