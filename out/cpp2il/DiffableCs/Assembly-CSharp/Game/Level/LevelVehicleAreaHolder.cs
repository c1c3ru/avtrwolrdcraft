namespace Game.Level;

public class LevelVehicleAreaHolder : MonoBehaviour
{
	public static LevelVehicleAreaHolder instance; //Field offset: 0x0
	[SerializeField]
	private LevelCamera _levelCamera; //Field offset: 0x20
	[SerializeField]
	private List<LevelCrossWalkAreaHandler> _levelCrossWalkAreaHandlers; //Field offset: 0x28
	[SerializeField]
	private List<LevelRoadBlockAreaHandler> _levelRoadBlockers; //Field offset: 0x30
	[SerializeField]
	private List<LevelVehicleParkingSpotAreaHandler> _levelVehicleParkingSpotAreaHandlers; //Field offset: 0x38
	[SerializeField]
	private float _paddingLeft; //Field offset: 0x40
	[SerializeField]
	private float _paddingRight; //Field offset: 0x44
	public float RoadYPosition; //Field offset: 0x48

	public LevelCamera LevelCamera
	{
		 get { } //Length: 8
	}

	public List<LevelCrossWalkAreaHandler> LevelCrossWalkAreaHandlers
	{
		 get { } //Length: 8
	}

	public List<LevelRoadBlockAreaHandler> LevelRoadBlockers
	{
		 get { } //Length: 8
	}

	public List<LevelVehicleParkingSpotAreaHandler> LevelVehicleParkingSpotAreaHandlers
	{
		 get { } //Length: 8
	}

	public float PaddingLeft
	{
		 get { } //Length: 8
	}

	public float PaddingRight
	{
		 get { } //Length: 8
	}

	public LevelVehicleAreaHolder() { }

	private void Awake() { }

	public LevelCamera get_LevelCamera() { }

	public List<LevelCrossWalkAreaHandler> get_LevelCrossWalkAreaHandlers() { }

	public List<LevelRoadBlockAreaHandler> get_LevelRoadBlockers() { }

	public List<LevelVehicleParkingSpotAreaHandler> get_LevelVehicleParkingSpotAreaHandlers() { }

	public float get_PaddingLeft() { }

	public float get_PaddingRight() { }

	public List<LevelPlayerVehicle> GetAllVehiclesInArea(Vector2 area) { }

}

