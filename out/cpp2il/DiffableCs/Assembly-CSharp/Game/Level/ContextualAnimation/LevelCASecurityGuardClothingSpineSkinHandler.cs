namespace Game.Level.ContextualAnimation;

public class LevelCASecurityGuardClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	[SerializeField]
	private LevelClothingItem _clothingItem; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCASecurityGuardClothingSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

