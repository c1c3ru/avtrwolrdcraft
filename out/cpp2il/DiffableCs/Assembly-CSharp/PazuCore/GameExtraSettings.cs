namespace PazuCore;

[CreateAssetMenu]
public class GameExtraSettings : ScriptableObject
{
	public string defaultCloseWindowSound; //Field offset: 0x18
	public Name_Back_Scene nameBackScene; //Field offset: 0x20
	public Name_Audio backgroundMusics; //Field offset: 0x28
	public Name_AudioEvent audioEvents; //Field offset: 0x30
	public List<GameObject> dontDestroyOnLoad; //Field offset: 0x38
	public GameLocalizationSettings localizationSettings; //Field offset: 0x40
	public AudioClipPaths audiolClipPaths; //Field offset: 0x48
	public bool multiTouchEnabled; //Field offset: 0x50
	public bool showFullGameButton; //Field offset: 0x51
	[ConditionalField("showFullGameButton", True, True, (array) null)]
	public bool overrideFullGameButtonText; //Field offset: 0x52
	[ConditionalField("overrideFullGameButtonText", True, True, (array) null)]
	public string fullGameButtonText; //Field offset: 0x58
	public SceneMap sceneMap; //Field offset: 0x60
	public bool useCloudGameData; //Field offset: 0x68
	[ConditionalField("useCloudGameData", True, True, (array) null)]
	public int gameDataVersion; //Field offset: 0x6C
	public bool useNewEndSession; //Field offset: 0x70
	public bool useAnalytics; //Field offset: 0x71
	public bool useActionBarHomePlayButton; //Field offset: 0x72
	public bool useTimeLock; //Field offset: 0x73
	public bool useActionBarNextGameWidget; //Field offset: 0x74
	public bool androidUseGoogleAnalytics; //Field offset: 0x75
	public bool dontOfferSubscriptionPurchase; //Field offset: 0x76

	public GameExtraSettings() { }

}

