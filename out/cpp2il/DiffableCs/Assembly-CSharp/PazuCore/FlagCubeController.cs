namespace PazuCore;

public class FlagCubeController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<SupportedLanguage, Boolean> <>9__13_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Sync>b__13_0(SupportedLanguage lang) { }

	}

	[CompilerGenerated]
	private static Action<FlagCubeController> OnTapLanguage; //Field offset: 0x0
	public const string FLAGS_RESOURCES_PATH = "PazuCore/Art/flags/"; //Field offset: 0x0
	public GameObject background; //Field offset: 0x20
	public GameObject flag; //Field offset: 0x28
	public GameObject text; //Field offset: 0x30
	public GameObject button; //Field offset: 0x38
	public GameObject selected; //Field offset: 0x40
	public GameObject soon; //Field offset: 0x48
	public GameObject langsCountText; //Field offset: 0x50
	[HideInInspector]
	public Country country; //Field offset: 0x58
	[HideInInspector]
	public List<SupportedLanguage> languages; //Field offset: 0x60

	public static event Action<FlagCubeController> OnTapLanguage
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public FlagCubeController() { }

	[CompilerGenerated]
	public static void add_OnTapLanguage(Action<FlagCubeController> value) { }

	public void Deselect() { }

	public void OnTap() { }

	[CompilerGenerated]
	public static void remove_OnTapLanguage(Action<FlagCubeController> value) { }

	public void Select() { }

	public void Sync(Country country, List<SupportedLanguage> languages) { }

}

