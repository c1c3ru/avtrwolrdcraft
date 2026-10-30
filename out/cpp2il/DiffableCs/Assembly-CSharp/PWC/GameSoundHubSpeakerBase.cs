namespace PWC;

public abstract class GameSoundHubSpeakerBase : MonoBehaviour, ILevelSpawnDuringGameplay
{
	public static readonly Dictionary<String, List`1<GameSoundHubSpeakerBase>> All; //Field offset: 0x0
	[SerializeField]
	protected string _linkId; //Field offset: 0x20
	protected ISoundHubTarget _soundHubTarget; //Field offset: 0x28
	private bool _isInit; //Field offset: 0x30

	private static GameSoundHubSpeakerBase() { }

	protected GameSoundHubSpeakerBase() { }

	private void Awake() { }

	private void LinkSpeakerToHub() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnPrePostInit() { }

	public override void OnSpawnDuringGameplay() { }

	protected abstract void PerformLinkAction(GameSoundHub soundHub, ParameterType parameterType) { }

}

