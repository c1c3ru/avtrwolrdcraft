namespace Game.Level;

public class LevelAirplaneTakeOffItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject _airplane; //Field offset: 0x20
	[SerializeField]
	private CShape _airplaneCshape; //Field offset: 0x28
	[SerializeField]
	private float _XstartingPoint; //Field offset: 0x30
	[SerializeField]
	private float _XtakeOffPoint; //Field offset: 0x34
	[SerializeField]
	private float _XresetPoint; //Field offset: 0x38
	[SerializeField]
	private Transform _endTakeOffPoint; //Field offset: 0x40
	[SerializeField]
	private bool _isGoingLeft; //Field offset: 0x48
	private int _tweenID; //Field offset: 0x4C
	private int _rotationTweenID; //Field offset: 0x50

	public LevelAirplaneTakeOffItemHandler() { }

	[CompilerGenerated]
	private void <DrivingInLane>b__10_0() { }

	[CompilerGenerated]
	private void <ResetAirplane>b__12_0() { }

	[CompilerGenerated]
	private void <TakeOff>b__11_0() { }

	private void DrivingInLane() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ResetAirplane() { }

	private void TakeOff() { }

}

