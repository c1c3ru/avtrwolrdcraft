namespace ScreenScripts;

public class ScalePerScreen : MonoBehaviour
{
	[SerializeField]
	private bool _initiateInStart; //Field offset: 0x20
	[SerializeField]
	private float _veryWide; //Field offset: 0x24
	[SerializeField]
	private float _wide; //Field offset: 0x28
	[SerializeField]
	private float _ipad; //Field offset: 0x2C

	public ScalePerScreen() { }

	public void Scale() { }

	private void Start() { }

}

