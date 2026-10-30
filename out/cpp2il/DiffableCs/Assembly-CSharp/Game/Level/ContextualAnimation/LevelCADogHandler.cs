namespace Game.Level.ContextualAnimation;

public class LevelCADogHandler : LevelCAHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x80
	[SerializeField]
	private DogType _dogType; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private LevelDog _dog; //Field offset: 0x98

	public int DogType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelCADogHandler() { }

	public int get_DogType() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public void set_DogType(int value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual bool ShouldPlayPreAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

