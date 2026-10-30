namespace PWC.Level;

public class LevelObjectDoorToOtherLevel : LevelDoorToOtherLevelBase
{
	[SerializeField]
	private GameObject _openDoor; //Field offset: 0x50
	[SerializeField]
	private GameObject _closedDoor; //Field offset: 0x58

	public LevelObjectDoorToOtherLevel() { }

	protected virtual void SetState(bool isOpen) { }

}

