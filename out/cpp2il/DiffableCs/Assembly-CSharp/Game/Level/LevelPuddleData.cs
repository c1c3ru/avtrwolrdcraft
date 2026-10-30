namespace Game.Level;

public class LevelPuddleData
{
	public string prefabGuid; //Field offset: 0x10
	public Vector3 positionOffset; //Field offset: 0x18
	public WeatherDropAreaType weatherDropAreaType; //Field offset: 0x24
	public List<WeatherType> supportedWeatherTypes; //Field offset: 0x28
	public string parentSceneGuid; //Field offset: 0x30
	public int sortingOrder; //Field offset: 0x38

	public LevelPuddleData(string prefabGuid, Vector3 positionOffset, WeatherDropAreaType weatherDropAreaType, List<WeatherType> supportedWeatherTypes, string parentSceneGuid, int sortingOrder) { }

}

