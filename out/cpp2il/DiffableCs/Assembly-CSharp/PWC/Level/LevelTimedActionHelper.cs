namespace PWC.Level;

public class LevelTimedActionHelper : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[SerializeField]
	private float _delayDuration; //Field offset: 0x20
	public UnityEvent OnTimePassed; //Field offset: 0x28
	private bool _isInProgress; //Field offset: 0x30
	private int _tweenId; //Field offset: 0x34

	public LevelTimedActionHelper() { }

	[CompilerGenerated]
	private void <StartTimer>b__8_0() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public void StartTimer() { }

	public void StopTimer() { }

}

