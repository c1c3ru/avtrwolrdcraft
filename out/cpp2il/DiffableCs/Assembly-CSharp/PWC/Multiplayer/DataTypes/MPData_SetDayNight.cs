namespace PWC.Multiplayer.DataTypes;

public class MPData_SetDayNight : MPDataBase
{
	public int timeOfDay; //Field offset: 0x28

	public MPData_SetDayNight() { }

	public virtual void HandleReceviedData() { }

}

