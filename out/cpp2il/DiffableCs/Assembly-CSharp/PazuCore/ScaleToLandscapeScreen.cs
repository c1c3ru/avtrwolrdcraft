namespace PazuCore;

public class ScaleToLandscapeScreen : MonoBehaviour
{
	[SerializeField]
	private float _tablet; //Field offset: 0x20
	[SerializeField]
	private float _wide; //Field offset: 0x24
	[SerializeField]
	private float _veryWide; //Field offset: 0x28
	public Action OnApplyCompleted; //Field offset: 0x30

	public ScaleToLandscapeScreen() { }

	private void ApplyValuesForCurrentScreen() { }

	private void SetScale(float scale) { }

	private void Start() { }

}

