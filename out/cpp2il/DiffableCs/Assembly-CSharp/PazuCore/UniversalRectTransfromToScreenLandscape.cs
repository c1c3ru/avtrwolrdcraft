namespace PazuCore;

public class UniversalRectTransfromToScreenLandscape : MonoBehaviour
{
	[Header("Position")]
	[SerializeField]
	private Vector2 _positionLandscape; //Field offset: 0x20
	[SerializeField]
	private Vector2 _positionWide; //Field offset: 0x28
	[SerializeField]
	private Vector2 _positionVeryWide; //Field offset: 0x30
	[Header("Scale")]
	[SerializeField]
	private float _scaleLandscape; //Field offset: 0x38
	[SerializeField]
	private float _scaleWide; //Field offset: 0x3C
	[SerializeField]
	private float _scaleVeryWide; //Field offset: 0x40
	[CompilerGenerated]
	private Action OnApplyCompleted; //Field offset: 0x48

	public event Action OnApplyCompleted
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public UniversalRectTransfromToScreenLandscape() { }

	[CompilerGenerated]
	private void <Editor_SaveValuesForCurrentScreen>b__13_0() { }

	[CompilerGenerated]
	public void add_OnApplyCompleted(Action value) { }

	private void ApplyValuesForCurrentScreen() { }

	[ContextMenu("Apply Values For Current Screen")]
	private void Editor_ApplyValuesForCurrentScreen() { }

	[ContextMenu("Save Values For Current Screen")]
	private void Editor_SaveValuesForCurrentScreen() { }

	[CompilerGenerated]
	public void remove_OnApplyCompleted(Action value) { }

	private void SetAnchoredPosition(Vector2 position) { }

	private void SetScale(float scale) { }

	private void Start() { }

}

