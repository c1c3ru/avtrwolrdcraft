namespace Game.Level;

public class LevelAddCAOnAllCharactersHandlerByWeather : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public AvatarSpineSkinsManagerBase skinsManager; //Field offset: 0x10
		public Predicate<SpineTypeCondition> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal bool <TryAddCaScriptToAvatar>b__0(SpineTypeCondition x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public AvatarSpineSkinsManagerBase skinsManager; //Field offset: 0x10
		public Predicate<SpineTypeCondition> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal bool <TryRemoveCaScriptFromAvatar>b__0(SpineTypeCondition x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public WeatherType usedWeatherType; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <UpdateConfig>b__0(CAScriptsToAddByWeather x) { }

	}

	internal enum CAScriptsEnumByWeather
	{
		None = 0,
		LevelCARainCharacterHandler = 1,
		LevelCARainToddlerHandler = 2,
		LevelCARainDogHandler = 3,
		LevelCARainCatHandler = 4,
		LevelCASnowCharacterHandler = 6,
		LevelCASnowToddlerHandler = 7,
		LevelCASnowDogHandler = 8,
		LevelCASnowCatHandler = 9,
		LevelCASnowHorseHandler = 10,
		LevelCASnowSurfaceCharacterHandler = 11,
		LevelCASnowSurfaceToddlerHandler = 12,
		LevelCASnowSurfaceDogHandler = 13,
		LevelCASnowSurfaceCatHandler = 14,
		LevelCASnowSurfaceHorseHandler = 15,
	}

	internal class CAScriptsToAdd
	{
		public CAScriptsEnumByWeather _scriptToAdd; //Field offset: 0x10
		public bool activeIndoor; //Field offset: 0x14
		public bool activeOutdoor; //Field offset: 0x15
		public List<SpineTypeCondition> _conditions; //Field offset: 0x18

		public CAScriptsToAdd() { }

	}

	internal class CAScriptsToAddByWeather
	{
		public WeatherType weatherType; //Field offset: 0x10
		public List<CAScriptsToAdd> cAScriptsToAdd; //Field offset: 0x18

		public CAScriptsToAddByWeather() { }

	}

	private static readonly Dictionary<CAScriptsEnumByWeather, Type> _map; //Field offset: 0x0
	[SerializeField]
	private List<CAScriptsToAddByWeather> _caScriptsToAddByWeather; //Field offset: 0x20
	private List<Type> types; //Field offset: 0x28
	private CAScriptsToAddByWeather _config; //Field offset: 0x30

	private static LevelAddCAOnAllCharactersHandlerByWeather() { }

	public LevelAddCAOnAllCharactersHandlerByWeather() { }

	private void AddCaScriptToAvatar(ICATarget levelAvatar, bool isActiveIndoor, bool isActiveOutdoor, Type type) { }

	private void Awake() { }

	private void OnAfterAvatarSpawn(ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPrePostInitAction() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	private void RemoveCAScriptFromAvatar(ICATarget levelAvatar, Type type) { }

	private bool TryAddCaScriptToAvatar(ILevelAvatar levelAvatar) { }

	private bool TryRemoveCaScriptFromAvatar(ILevelAvatar levelAvatar) { }

	private void UpdateConfig() { }

}

