namespace PWC.Level;

public class LevelCamera : GameCamera
{
	[SerializeField]
	private RectTransform _area; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<RectTransform> OnBeforeSetBoundsCallAction; //Field offset: 0xD0

	public event Action<RectTransform> OnBeforeSetBoundsCallAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCamera() { }

	[CompilerGenerated]
	public void add_OnBeforeSetBoundsCallAction(Action<RectTransform> value) { }

	public void Init() { }

	[CompilerGenerated]
	public void remove_OnBeforeSetBoundsCallAction(Action<RectTransform> value) { }

	protected virtual bool ShouldSaveZoomStateInPersistentData() { }

}

