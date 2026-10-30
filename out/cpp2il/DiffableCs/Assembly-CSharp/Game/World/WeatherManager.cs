namespace Game.World;

public class WeatherManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal string <.cctor>b__33_0(LevelWorldType w) { }

		internal int <.cctor>b__33_1(LevelWorldType w) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass21_0
	{
		public bool isMultiplayerGame; //Field offset: 0x0

	}

	internal enum WeatherType
	{
		Clear = 0,
		Rain = 1,
		Snow = 6,
		Snow_Xmas = 7,
		Halloween = 8,
	}

	public static WeatherType CurrentWeatherType; //Field offset: 0x0
	private const string PLAYERPREFS_KEY_TYPE = "PazuWorld_WeatherType"; //Field offset: 0x0
	public const float TRANSITION_TIME = 2,5; //Field offset: 0x0
	private static Int32[] _weatherPerLevel; //Field offset: 0x8
	private static readonly Dictionary<String, Int32> _worldTypeIndexByName; //Field offset: 0x10
	[CompilerGenerated]
	private static Action<WeatherType> OnWeatherChangeAction; //Field offset: 0x18
	private static readonly LevelWorldType[] _worlds; //Field offset: 0x20

	public static event Action<WeatherType> OnWeatherChangeAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static IReadOnlyList<LevelWorldType> Worlds
	{
		 get { } //Length: 88
	}

	private static WeatherManager() { }

	public WeatherManager() { }

	[CompilerGenerated]
	internal static void <SetWeatherDataOnAllWorlds>g__SetValue|21_0(int index, int value, ref <>c__DisplayClass21_0 unnamed_param_2) { }

	[CompilerGenerated]
	public static void add_OnWeatherChangeAction(Action<WeatherType> value) { }

	private static void ApplyWeatherFromCurrentScene() { }

	private void Awake() { }

	public static IReadOnlyList<LevelWorldType> get_Worlds() { }

	public static float GetIntensity(WeatherType weatherType) { }

	public static Int32[] GetWeatherDataOnAllWorlds() { }

	public static WeatherType GetWeatherForWorld(string world) { }

	public static string GetWeatherTypePrefKey(string world) { }

	public static bool HasValidHolidayPacks() { }

	private static void InitWeatherData() { }

	public static bool IsSnowy(WeatherType current) { }

	public static void LoadWeatherForWorld(string world) { }

	private void OnDestroy() { }

	private void OnExitMultiplayer() { }

	[CompilerGenerated]
	public static void remove_OnWeatherChangeAction(Action<WeatherType> value) { }

	private static void ResetWeatherData() { }

	public static void SaveWeatherForWorld(string world, WeatherType weatherType) { }

	public static void SetWeather(string world, WeatherType weatherType) { }

	public static void SetWeatherData(string world, WeatherType weatherType) { }

	public static void SetWeatherDataOnAllWorlds(Int32[] weatherPerLevel) { }

	private static bool TryGetWorldIndex(string world, out int index) { }

	public static bool WeatherMatches(WeatherType required, WeatherType current) { }

	public static bool WeatherMatchesAny(IEnumerable<WeatherType> requiredList, WeatherType current) { }

}

