namespace Game.Level.ContextualAnimation;

public class LevelCAMeetingRoomSitAreaHandler : LevelCAParentHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAMeetingRoomSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

