namespace ScreenScripts;

public class PositionPerScreen : MonoBehaviour
{
	[SerializeField]
	private bool _initiateInStart; //Field offset: 0x20
	[SerializeField]
	private bool _initiateInAwake; //Field offset: 0x21
	[SerializeField]
	private Vector2 _veryWide; //Field offset: 0x24
	[SerializeField]
	private Vector2 _wide; //Field offset: 0x2C
	[SerializeField]
	private Vector2 _ipad; //Field offset: 0x34

	public PositionPerScreen() { }

	private void Awake() { }

	public void Position() { }

	private void Start() { }

}

