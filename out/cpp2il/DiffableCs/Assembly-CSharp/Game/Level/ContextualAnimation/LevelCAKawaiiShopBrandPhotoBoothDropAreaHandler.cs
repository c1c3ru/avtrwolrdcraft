namespace Game.Level.ContextualAnimation;

public class LevelCAKawaiiShopBrandPhotoBoothDropAreaHandler : LevelCADropAreaHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x80

	public LevelCAKawaiiShopBrandPhotoBoothDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

