//Type is in global namespace

public class LevelCADanceEarPieceMOONZCutieSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	[SerializeField]
	private LevelClothingItem _clothingItem; //Field offset: 0x98
	private string leaderEarPiece; //Field offset: 0xA0
	private string rapperEarPiece; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCADanceEarPieceMOONZCutieSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

