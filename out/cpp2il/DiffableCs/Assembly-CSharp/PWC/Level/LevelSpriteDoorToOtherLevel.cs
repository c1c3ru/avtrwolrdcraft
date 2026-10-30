namespace PWC.Level;

public class LevelSpriteDoorToOtherLevel : LevelDoorToOtherLevelBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x50
	[SerializeField]
	private Sprite _openDoor; //Field offset: 0x58
	[SerializeField]
	private Sprite _closedDoor; //Field offset: 0x60

	public LevelSpriteDoorToOtherLevel() { }

	protected virtual void SetState(bool isOpen) { }

}

