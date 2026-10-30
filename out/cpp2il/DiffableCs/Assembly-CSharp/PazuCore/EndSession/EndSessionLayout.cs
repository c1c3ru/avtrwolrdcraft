namespace PazuCore.EndSession;

public class EndSessionLayout : MonoBehaviour
{
	[CompilerGenerated]
	private static EndSessionLayout <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GameObject prefab; //Field offset: 0x20
	[CompilerGenerated]
	private EndSessionCanvas <MyEndSessionCanvas>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsClearBottomLeftCalled>k__BackingField; //Field offset: 0x30

	public private static EndSessionLayout Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsClearBottomLeftCalled
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private EndSessionCanvas MyEndSessionCanvas
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public EndSessionLayout() { }

	private void Awake() { }

	public void ClearBottomLeft() { }

	[CompilerGenerated]
	public static EndSessionLayout get_Instance() { }

	[CompilerGenerated]
	public bool get_IsClearBottomLeftCalled() { }

	[CompilerGenerated]
	public EndSessionCanvas get_MyEndSessionCanvas() { }

	public void Hide() { }

	public void HideAndDestroy() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(EndSessionLayout value) { }

	[CompilerGenerated]
	private void set_IsClearBottomLeftCalled(bool value) { }

	[CompilerGenerated]
	private void set_MyEndSessionCanvas(EndSessionCanvas value) { }

	private void SetCanvasVisible(bool visible) { }

	public void Show() { }

	private void Start() { }

}

