namespace Game.Level.ContextualAnimation;

public class LevelCABabyBathtubCharacterItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelBabyDropArea _babyDropArea; //Field offset: 0x88
	private bool _hasBaby; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABabyBathtubCharacterItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	private void OnBabyDrop(LevelItem levelItem) { }

	private void OnBabyPickup(LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

}

