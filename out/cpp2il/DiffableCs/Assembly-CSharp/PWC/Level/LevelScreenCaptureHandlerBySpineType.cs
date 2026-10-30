namespace PWC.Level;

public class LevelScreenCaptureHandlerBySpineType : LevelScreenCaptureHandler, ILevelSpawnDuringGameplay, ILevelMakerUIMenuItem
{
	[SerializeField]
	private LevelSitArea _levelSitArea; //Field offset: 0x80
	[SerializeField]
	private List<AvatarSizeTypeCaptureData> _captureData; //Field offset: 0x88
	private Dictionary<AvatarSizeType, Vector3> _captureDataDictionary; //Field offset: 0x90
	private Vector3 _rectInitialPosition; //Field offset: 0x98

	public LevelScreenCaptureHandlerBySpineType() { }

	protected virtual void Awake() { }

	public virtual void FixCaptureCameraPosition() { }

	private void OnAvatarSit(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	protected virtual void OnDestroy() { }

}

