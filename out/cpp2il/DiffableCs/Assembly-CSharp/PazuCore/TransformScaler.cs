namespace PazuCore;

public class TransformScaler : MonoBehaviour
{
	[SerializeField]
	private float _scaleWide; //Field offset: 0x20
	[SerializeField]
	private float _scaleVeryWide; //Field offset: 0x24
	[SerializeField]
	private float _scaleTall; //Field offset: 0x28
	[SerializeField]
	private float _scaleVeryTall; //Field offset: 0x2C
	[SerializeField]
	private float _scaleDefaultLandscape; //Field offset: 0x30
	[SerializeField]
	private float _scaleDefaultPortrait; //Field offset: 0x34

	public TransformScaler() { }

	private void Awake() { }

	private void FixScale() { }

	private void ScaleBy(float scale) { }

	private void SetScale(float scale) { }

}

