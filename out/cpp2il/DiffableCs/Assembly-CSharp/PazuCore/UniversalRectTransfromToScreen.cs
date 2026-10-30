namespace PazuCore;

public class UniversalRectTransfromToScreen : MonoBehaviour
{
	[Header("Portrait Position")]
	[SerializeField]
	private Vector2 _positionPortrait; //Field offset: 0x20
	[SerializeField]
	private Vector2 _positionTall; //Field offset: 0x28
	[SerializeField]
	private Vector2 _positionVeryTall; //Field offset: 0x30
	[Header("Portrait Scale")]
	[SerializeField]
	private float _scalePortrait; //Field offset: 0x38
	[SerializeField]
	private float _scaleTall; //Field offset: 0x3C
	[SerializeField]
	private float _scaleVeryTall; //Field offset: 0x40
	[Header("Landscape Position")]
	[SerializeField]
	private Vector2 _positionLandscape; //Field offset: 0x44
	[SerializeField]
	private Vector2 _positionWide; //Field offset: 0x4C
	[SerializeField]
	private Vector2 _positionVeryWide; //Field offset: 0x54
	[Header("Landscape Scale")]
	[SerializeField]
	private float _scaleLandscape; //Field offset: 0x5C
	[SerializeField]
	private float _scaleWide; //Field offset: 0x60
	[SerializeField]
	private float _scaleVeryWide; //Field offset: 0x64
	[CompilerGenerated]
	private Action OnApplyCompleted; //Field offset: 0x68

	public event Action OnApplyCompleted
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public UniversalRectTransfromToScreen() { }

	[CompilerGenerated]
	private void <Editor_SaveValuesForCurrentScreen>b__19_0() { }

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

