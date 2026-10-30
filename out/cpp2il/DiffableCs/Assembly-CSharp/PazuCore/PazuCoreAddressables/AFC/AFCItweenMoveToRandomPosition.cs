namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCItweenMoveToRandomPosition : MonoBehaviour
{
	internal enum DurationType
	{
		MoveBySpeed = 0,
		MoveByTime = 1,
	}

	[SerializeField]
	protected DurationType _durationType; //Field offset: 0x20
	[SerializeField]
	private float _time; //Field offset: 0x24
	[SerializeField]
	private float _speed; //Field offset: 0x28
	[SerializeField]
	private float _delay; //Field offset: 0x2C
	[SerializeField]
	private bool _islocal; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onTargetReach; //Field offset: 0x38
	[SerializeField]
	private float _rangeOnX; //Field offset: 0x40
	[SerializeField]
	private float _rangeOnY; //Field offset: 0x44
	private Vector2 _currentPosition; //Field offset: 0x48
	private Vector3 _newPosition; //Field offset: 0x50

	public AFCItweenMoveToRandomPosition() { }

	[CompilerGenerated]
	private void <MoveTo>b__12_0() { }

	private void GetNewPosition() { }

	public void MoveTo() { }

	private void Start() { }

}

