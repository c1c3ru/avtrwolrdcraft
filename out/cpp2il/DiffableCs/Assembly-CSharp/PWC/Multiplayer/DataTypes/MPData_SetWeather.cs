namespace PWC.Multiplayer.DataTypes;

public class MPData_SetWeather : MPDataBase
{
	public Int32[] weatherPerWorld; //Field offset: 0x28

	public MPData_SetWeather() { }

	public virtual void HandleReceviedData() { }

}

