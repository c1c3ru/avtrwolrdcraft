namespace PWC;

public class GameSoundHub : GameSoundPlayer
{
	internal enum ParameterType
	{
		None = 0,
		On = 1,
		Off = 2,
	}

	public static readonly Dictionary<String, GameSoundHub> All; //Field offset: 0x0
	[SerializeField]
	private bool _considerSelfForVolumeFactor; //Field offset: 0x40
	[SerializeField]
	private string _linkId; //Field offset: 0x48
	[CompilerGenerated]
	private Action<GameSoundHub, ParameterType> OnLinkAction; //Field offset: 0x50

	public event Action<GameSoundHub, ParameterType> OnLinkAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	private static GameSoundHub() { }

	public GameSoundHub() { }

	[CompilerGenerated]
	public void add_OnLinkAction(Action<GameSoundHub, ParameterType> value) { }

	private void Awake() { }

	protected virtual float GetVolumeFactorForDistance(Vector2 cameraPosition, Vector2 soundSourcePosition) { }

	private void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnPlay() { }

	private void OnPostInitAction() { }

	protected virtual void OnStop() { }

	[CompilerGenerated]
	public void remove_OnLinkAction(Action<GameSoundHub, ParameterType> value) { }

}

