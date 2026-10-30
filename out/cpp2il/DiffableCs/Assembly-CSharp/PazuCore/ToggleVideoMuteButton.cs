namespace PazuCore;

public class ToggleVideoMuteButton : ButtonBase
{
	private static bool _isVideoMute; //Field offset: 0x0
	private static readonly List<ToggleVideoMuteButton> _buttons; //Field offset: 0x8
	[SerializeField]
	private VideoPlayer _videoPlayer; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Sprite _mutedSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _notMutedSprite; //Field offset: 0x38
	private bool _didCallOnEnableOnce; //Field offset: 0x40

	private static ToggleVideoMuteButton() { }

	public ToggleVideoMuteButton() { }

	[CompilerGenerated]
	private void <OnEnable>b__8_0(VideoPlayer x) { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void Start() { }

	private void SyncMuteState() { }

}

