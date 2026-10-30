//Type is in global namespace

public class LevelCADanceEarPieceGALXELeaderSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	[SerializeField]
	private LevelClothingItem _clothingItem; //Field offset: 0x98
	private string rapperEarPiece; //Field offset: 0xA0
	private string cutieEarPiece; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCADanceEarPieceGALXELeaderSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

