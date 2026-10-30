namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCScreenSwipeReceiver : MonoBehaviour
{
	[SerializeField]
	private bool _canSwipeLeft; //Field offset: 0x20
	[SerializeField]
	private bool _canSwipeRight; //Field offset: 0x21
	[SerializeField]
	private bool _canSwipeUp; //Field offset: 0x22
	[SerializeField]
	private bool _canSwipeDown; //Field offset: 0x23
	[Header("UnityEvents")]
	[SerializeField]
	private UnityEvent _leftSwipeActions; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _rightSwipeActions; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _upSwipeActions; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _downSwipeActions; //Field offset: 0x40
	[SerializeField]
	private float _dragThreshold; //Field offset: 0x48
	private Vector2 _beginSwipePosition; //Field offset: 0x4C
	private Vector2 _endSwipePosition; //Field offset: 0x54

	public AFCScreenSwipeReceiver() { }

	private void Start() { }

	private void Update() { }

}

