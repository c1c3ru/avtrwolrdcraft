namespace PazuCore;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager instance; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Choose which GameSettings asset to use")]
	private GameSettings _settings; //Field offset: 0x20
	[SerializeField]
	private GameExtraSettings _extraSettings; //Field offset: 0x28

	public GameExtraSettings ExtraSettings
	{
		 get { } //Length: 8
	}

	public GameSettings MainSettings
	{
		 get { } //Length: 8
	}

	public SettingsManager() { }

	private void Awake() { }

	public GameExtraSettings get_ExtraSettings() { }

	public GameSettings get_MainSettings() { }

	private void InitExtraSettings() { }

	private void Start() { }

}

