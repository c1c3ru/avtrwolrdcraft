namespace Game.Level;

public class LevelPuddleDropArea : LevelDropArea, IHasWaterSurface
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public PDPrefab splash; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal void <OnItemEndDrop>b__0() { }

	}

	public WeatherDropAreaType weatherDropAreaType; //Field offset: 0xD8
	public List<WeatherType> supportedWeatherTypes; //Field offset: 0xE0
	private Vector3 _spalshOffset; //Field offset: 0xE8

	public LevelPuddleDropArea() { }

	protected virtual void Awake() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemEndDrop(LevelItem item) { }

	private void OnWeatherChange(WeatherType weatherType) { }

}

