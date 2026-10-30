namespace PazuCore;

public class ScaleToPortraitScreen : MonoBehaviour
{
	[SerializeField]
	private float _tablet; //Field offset: 0x20
	[SerializeField]
	private float _tall; //Field offset: 0x24
	[SerializeField]
	private float _veryTall; //Field offset: 0x28
	public Action OnApplyCompleted; //Field offset: 0x30

	public ScaleToPortraitScreen() { }

	private void ApplyValuesForCurrentScreen() { }

	private void SetScale(float scale) { }

	private void Start() { }

}

