namespace PWC.Level;

[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_isFlipped"})]
public class LevelDropAreaForceFlippedStatePerSideHandler : LevelDropAreaForceFlippedStateHandler
{
	[SerializeField]
	private bool _isFlippedLeftSide; //Field offset: 0x30
	[SerializeField]
	private bool _isFlippedRightSide; //Field offset: 0x31

	public LevelDropAreaForceFlippedStatePerSideHandler() { }

	protected virtual void OnItemBeginDrop(LevelItem levelItem) { }

}

