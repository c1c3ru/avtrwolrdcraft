namespace PWC.UGC;

public class UGCZoomOutButton : ButtonBase
{
	[SerializeField]
	private GameObject _view; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Sprite _zoomInSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _zoomOutSprite; //Field offset: 0x38

	public UGCZoomOutButton() { }

	protected virtual void Awake() { }

	private void OnCameraZoomIn() { }

	private void OnCameraZoomOut() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnUGCEntityDeselected(IUGCEntity ugcEntity) { }

	private void OnUGCEntitySelected(IUGCEntity ugcEntity) { }

	private void Start() { }

}

