namespace PazuCore;

public abstract class SceneButtonsCanvasBase : MonoBehaviour
{
	[CompilerGenerated]
	private static SceneButtonsCanvasBase <Current>k__BackingField; //Field offset: 0x0
	private Canvas _canvas; //Field offset: 0x20
	protected bool _isReady; //Field offset: 0x28

	public private static SceneButtonsCanvasBase Current
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	protected SceneButtonsCanvasBase() { }

	protected override void Awake() { }

	protected GameObject CreateButton(string prefabName) { }

	protected override void CreateDefaultButtons() { }

	protected void DestroyButtonIfExists(ref GameObject button) { }

	protected void FitButtonsToScreen(ScreenType screenType) { }

	protected void FitCanvasScalerToScreen(bool changeMatchWidthOrHeightForIpad) { }

	[CompilerGenerated]
	public static SceneButtonsCanvasBase get_Current() { }

	public static bool IsReady() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Current(SceneButtonsCanvasBase value) { }

	public void SetVisible(bool visible) { }

}

