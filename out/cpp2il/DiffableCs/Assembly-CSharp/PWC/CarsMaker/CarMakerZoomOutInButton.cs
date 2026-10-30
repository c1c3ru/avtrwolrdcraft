namespace PWC.CarsMaker;

public class CarMakerZoomOutInButton : ButtonBase
{
	[SerializeField]
	private CarMakerCameraFocus _cameraFocus; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Sprite _zoomInButtonSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _zoomOutButtonSprite; //Field offset: 0x38

	public CarMakerZoomOutInButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void SyncToZoomState() { }

}

