namespace Game.Level;

public class LevelVehicleParkingSpotPassengersEventHandler : MonoBehaviour
{
	[SerializeField]
	private LevelVehicleParkingSpotAreaHandler _parkingSpot; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onFirstPassengerEnterEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onLastPassengerLeftEvent; //Field offset: 0x30
	private bool _hasPassengers; //Field offset: 0x38
	private LevelPlayerVehicle _trackedVehicle; //Field offset: 0x40
	private readonly List<LevelAvatarRestAreaBase> _trackedRestAreas; //Field offset: 0x48

	public LevelVehicleParkingSpotPassengersEventHandler() { }

	private void Awake() { }

	private bool HasPassengers(LevelItem ignoredItem = null) { }

	private void OnAvatarEndDropOnRestArea(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnBeforeDestroyLevelItem(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea _) { }

	private void OnLevelPermanentPostInit() { }

	private void OnParkingChanged(LevelVehicleParkingSpotAreaHandler _, LevelPlayerVehicle __) { }

	private void OnPlayerVehicleCleared(LevelVehicleParkingSpotAreaHandler _) { }

	private void Refresh(LevelItem ignoredItem = null) { }

	private void TrackVehicle() { }

	private void UntrackVehicle() { }

}

