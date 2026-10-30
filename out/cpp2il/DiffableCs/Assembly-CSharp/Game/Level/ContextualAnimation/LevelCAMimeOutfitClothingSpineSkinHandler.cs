namespace Game.Level.ContextualAnimation;

public class LevelCAMimeOutfitClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAMimeOutfitClothingSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void PlayClapForAllCharacters(ICATarget target) { }

}

