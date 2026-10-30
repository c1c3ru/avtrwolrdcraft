namespace Game.Level.ContextualAnimation;

public class LevelCAHorseHandler : LevelCAHandlerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x80
	[SerializeField]
	private HorseType _horseType; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private LevelHorse _horse; //Field offset: 0x98

	public int HorseType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelCAHorseHandler() { }

	public int get_HorseType() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual SpineType GetSpineType() { }

	protected virtual bool IsAllowedInWaterArea() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public void set_HorseType(int value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual bool ShouldPlayPreAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

