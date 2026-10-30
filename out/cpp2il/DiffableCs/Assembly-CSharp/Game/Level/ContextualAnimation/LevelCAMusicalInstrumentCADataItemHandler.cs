namespace Game.Level.ContextualAnimation;

public class LevelCAMusicalInstrumentCADataItemHandler : LevelCAMusicalInstrumentItemHandlerBase, IHaveAnimationSearch
{
	public LevelCAItemHandlerData Data; //Field offset: 0xD8

	public LevelCAMusicalInstrumentCADataItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public override LevelCAConfig GetCAConfigByAnimationName(string animationName) { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

}

