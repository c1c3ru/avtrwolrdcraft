namespace Game.Level.ContextualAnimation;

public class LevelCATravelStrollerToddlerSitAreaHandler : LevelCAParentHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCATravelStrollerToddlerSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual string GetSpacialTrackAnimationName() { }

	public virtual SpineType GetSpineType() { }

}

