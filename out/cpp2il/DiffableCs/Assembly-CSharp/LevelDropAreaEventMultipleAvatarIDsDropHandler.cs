//Type is in global namespace

public class LevelDropAreaEventMultipleAvatarIDsDropHandler : LevelDropAreaEventOnItemDropHandler
{
	[SerializeField]
	protected List<Int32> _avatarIds; //Field offset: 0x80
	private List<LevelItem> _inTheDropArea; //Field offset: 0x88

	public LevelDropAreaEventMultipleAvatarIDsDropHandler() { }

	private bool CheckWhetherAvatarIDIsInDropArea(LevelItem levelItem) { }

	protected virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnItemPickUp(LevelItem levelItem) { }

}

