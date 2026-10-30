//Type is in global namespace

public class BackgroundPlanetEvents : MonoBehaviour
{
	[SerializeField]
	private bool _invokeActionOnLoad; //Field offset: 0x20
	[Header("Events")]
	[SerializeField]
	private UnityEvent _onDay; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onSunset; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onNight; //Field offset: 0x38
	private BackgroundPlanet instance; //Field offset: 0x40

	public BackgroundPlanetEvents() { }

	protected override void Awake() { }

	public void InvokeEventByDayState(TimeOfDay timeOfDay) { }

	protected void InvokeOnLoad() { }

	protected override void OnDestroy() { }

	protected override void Start() { }

}

