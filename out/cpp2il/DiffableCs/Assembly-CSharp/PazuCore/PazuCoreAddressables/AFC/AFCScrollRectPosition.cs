namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCScrollRectPosition : MonoBehaviour
{
	internal enum DurationType
	{
		MoveBySpeed = 0,
		MoveByTime = 1,
	}

	internal enum State
	{
		Vertical = 0,
		Horizontal = 1,
	}

	[SerializeField]
	private State _scrollState; //Field offset: 0x20
	[SerializeField]
	protected DurationType _durationType; //Field offset: 0x24
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x28
	[SerializeField]
	private float _time; //Field offset: 0x30
	[SerializeField]
	private float _speed; //Field offset: 0x34
	[SerializeField]
	private float _delay; //Field offset: 0x38
	[Header("Postion Per Screen")]
	[SerializeField]
	private float _tablet; //Field offset: 0x3C
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private float _long; //Field offset: 0x40
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private float _verLong; //Field offset: 0x44
	[SerializeField]
	private UnityEvent _onReachedTarget; //Field offset: 0x48
	private float _goToPostion; //Field offset: 0x50

	public AFCScrollRectPosition() { }

	[CompilerGenerated]
	private void <GoToVerticalPosition>b__14_0() { }

	private void Awake() { }

	public void GoToVerticalPosition() { }

	private void UpdateScrollerPos(float pos) { }

}

