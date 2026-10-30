namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCActionPerScrollerPositionPerScreen : MonoBehaviour
{
	internal enum State
	{
		Vertical = 0,
		Horizontal = 1,
	}

	[SerializeField]
	private State _scrollState; //Field offset: 0x20
	[Header("Tablet")]
	[SerializeField]
	private float _tabletMinScrollerPosition; //Field offset: 0x24
	[SerializeField]
	private float _tabletMaxScrollerPosition; //Field offset: 0x28
	[FormerlySerializedAs("_tallMinScrollerPosition")]
	[Header("Long")]
	[SerializeField]
	private float _longMinScrollerPosition; //Field offset: 0x2C
	[FormerlySerializedAs("_tallMaxScrollerPosition")]
	[SerializeField]
	private float _longMaxScrollerPosition; //Field offset: 0x30
	[FormerlySerializedAs("_veryMinTallScrollerPosition")]
	[Header("Very Long")]
	[SerializeField]
	private float _veryLongMinScrollerPosition; //Field offset: 0x34
	[FormerlySerializedAs("_veryMaxTallScrollerPosition")]
	[SerializeField]
	private float _veryLongMaxScrollerPosition; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _event; //Field offset: 0x40
	[SerializeField]
	private ScrollRect _scrollerRect; //Field offset: 0x48
	[SerializeField]
	private bool _canCallMultipleTimes; //Field offset: 0x50
	private float _scrollerMinPosition; //Field offset: 0x54
	private float _scrollerMaxPosition; //Field offset: 0x58
	private float _normalizedPosition; //Field offset: 0x5C
	private bool _didCallEvent; //Field offset: 0x60
	private bool _isInPositionRange; //Field offset: 0x61

	public AFCActionPerScrollerPositionPerScreen() { }

	private void Awake() { }

	private void CallEvent() { }

	private void OnDestroy() { }

	private void ScrollerPositionCheck(Vector2 vector) { }

}

