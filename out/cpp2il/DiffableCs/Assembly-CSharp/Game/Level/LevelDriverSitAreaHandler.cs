namespace Game.Level;

public class LevelDriverSitAreaHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IPointerClickHandler
{
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x20
	[SerializeField]
	private LevelDrivingVehicleBase _vehicle; //Field offset: 0x28
	[SerializeField]
	private bool _canLeaveStation; //Field offset: 0x30
	[CompilerGenerated]
	private bool <CanDragDriver>k__BackingField; //Field offset: 0x31

	public bool CanDragDriver
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelDriverSitAreaHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_CanDragDriver() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	private void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public void set_CanDragDriver(bool value) { }

}

