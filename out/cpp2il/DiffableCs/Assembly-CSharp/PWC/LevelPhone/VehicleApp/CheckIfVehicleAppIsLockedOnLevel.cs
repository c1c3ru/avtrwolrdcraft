namespace PWC.LevelPhone.VehicleApp;

public class CheckIfVehicleAppIsLockedOnLevel : MonoBehaviour
{
	[SerializeField]
	private Application _vehicleApplication; //Field offset: 0x20
	[SerializeField]
	private Image _appImage; //Field offset: 0x28
	[SerializeField]
	private Sprite _disabledSprite; //Field offset: 0x30

	public CheckIfVehicleAppIsLockedOnLevel() { }

	private void OnEnable() { }

}

