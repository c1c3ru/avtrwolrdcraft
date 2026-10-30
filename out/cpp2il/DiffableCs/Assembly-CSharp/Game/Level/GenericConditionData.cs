namespace Game.Level;

public class GenericConditionData
{
	public ILevelAvatar activeAvatar; //Field offset: 0x10
	public List<ILevelAvatar> avatarGroup; //Field offset: 0x18
	public List<LevelPlayerVehicle> vehicles; //Field offset: 0x20

	public GenericConditionData() { }

}

