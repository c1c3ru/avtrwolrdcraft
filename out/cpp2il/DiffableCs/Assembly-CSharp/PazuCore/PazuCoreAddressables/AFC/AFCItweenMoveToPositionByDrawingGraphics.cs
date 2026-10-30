namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCItweenMoveToPositionByDrawingGraphics : MonoBehaviour
{
	internal enum IsGreaterDurationType
	{
		MoveBySpeed = 0,
		MoveByTime = 1,
	}

	internal enum IsLowerDurationType
	{
		MoveBySpeed = 0,
		MoveByTime = 1,
	}

	[Header("IsGreater")]
	[SerializeField]
	private float _tabletIsGreater; //Field offset: 0x20
	[SerializeField]
	private float _longIsGreater; //Field offset: 0x24
	[SerializeField]
	private float _veryLongIsGreater; //Field offset: 0x28
	[SerializeField]
	protected IsGreaterDurationType _isGreaterDurationType; //Field offset: 0x2C
	[SerializeField]
	private float _isGreaterTime; //Field offset: 0x30
	[SerializeField]
	private float _isGreaterSpeed; //Field offset: 0x34
	[SerializeField]
	private float _isGreaterDelay; //Field offset: 0x38
	[Header("IsLower")]
	[SerializeField]
	private float _tabletIsLower; //Field offset: 0x3C
	[SerializeField]
	private float _longIsLower; //Field offset: 0x40
	[SerializeField]
	private float _veryLongIsLower; //Field offset: 0x44
	[SerializeField]
	protected IsLowerDurationType _isLowerDurationType; //Field offset: 0x48
	[SerializeField]
	private float _isLowerTime; //Field offset: 0x4C
	[SerializeField]
	private float _isLowerSpeed; //Field offset: 0x50
	[SerializeField]
	private float _isLowerDelay; //Field offset: 0x54
	[SerializeField]
	private bool _isLocal; //Field offset: 0x58
	[SerializeField]
	private UnityEvent _onTargetReach; //Field offset: 0x60
	private float _greater; //Field offset: 0x68
	private float _lower; //Field offset: 0x6C

	public AFCItweenMoveToPositionByDrawingGraphics() { }

	[CompilerGenerated]
	private void <IsGreater>b__21_0() { }

	[CompilerGenerated]
	private void <IsGreater>b__21_1() { }

	public void IsGreater(bool isGreater) { }

	private void Start() { }

}

