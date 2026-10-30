namespace Game.Level;

public class WeatherJsonProcessor : MonoBehaviour
{
	[Header("Relative path inside Assets (e.g., Assets/WeatherJsons)")]
	public string folderPath; //Field offset: 0x20
	[Header("Weather Type Conversion")]
	[Tooltip("The weather type to look for in filenames (e.g., Rain)")]
	public WeatherType sourceWeatherType; //Field offset: 0x28
	[Header("New WeatherType to replace with")]
	public WeatherType targetWeatherType; //Field offset: 0x2C

	public WeatherJsonProcessor() { }

	[ContextMenu("Duplicate _rain.json to _snow.json and update weather type")]
	public void DuplicateRainJsonsToSnow() { }

}

