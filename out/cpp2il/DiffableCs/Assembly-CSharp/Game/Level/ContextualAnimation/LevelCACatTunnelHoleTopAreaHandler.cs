namespace Game.Level.ContextualAnimation;

public class LevelCACatTunnelHoleTopAreaHandler : LevelCACatTunnelHoleAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configsWithCatFight; //Field offset: 0xA8

	public LevelCACatTunnelHoleTopAreaHandler() { }

	protected virtual List<LevelCAConfig> GetConfigs() { }

	protected virtual List<LevelCAConfig> GetConfigsWithCatFight() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

}

