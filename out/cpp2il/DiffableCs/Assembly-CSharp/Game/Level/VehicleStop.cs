namespace Game.Level;

public class VehicleStop
{
	public float xStopPosition; //Field offset: 0x10
	public float yStopPosition; //Field offset: 0x14
	public float xConditionDistance; //Field offset: 0x18
	public VehicleStopType vehicleStopType; //Field offset: 0x1C
	public LevelCrossWalkAreaHandler levelCrossWalkAreaHandler; //Field offset: 0x20

	public VehicleStop() { }

}

