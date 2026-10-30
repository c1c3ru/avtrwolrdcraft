namespace PazuCore.AF.ActionBar;

public class GameHomePlayButton : ButtonBase, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[CompilerGenerated]
	private static Action OnButtonClick; //Field offset: 0x0
	[SerializeField]
	private string _imageKey; //Field offset: 0x20
	[SerializeField]
	private Texture _gameTexture; //Field offset: 0x28
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x30
	private bool _didClick; //Field offset: 0x38
	private string _textureName; //Field offset: 0x40

	public static event Action OnButtonClick
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public GameHomePlayButton() { }

	[CompilerGenerated]
	public static void add_OnButtonClick(Action value) { }

	public void DownloadImageIfNeeded() { }

	private void Hide() { }

	protected virtual void OnClick() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnButtonClick(Action value) { }

	private void SetImage() { }

	public void SetVisible(bool isVisible) { }

	private void Show() { }

}

