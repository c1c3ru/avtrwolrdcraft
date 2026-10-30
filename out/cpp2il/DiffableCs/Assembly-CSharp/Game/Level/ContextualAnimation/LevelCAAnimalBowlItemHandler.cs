namespace Game.Level.ContextualAnimation;

public class LevelCAAnimalBowlItemHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelItem item; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	private const string EATING_ANIMATION_NAME = "Bowl_Eating"; //Field offset: 0x0
	[SerializeField]
	private bool _isfillable; //Field offset: 0x80
	[ConditionalField("_isfillable", True, True, (array) null)]
	[SerializeField]
	private LevelFillableItemHandler _fillable; //Field offset: 0x88
	[SerializeField]
	private LevelDropArea _foodDropArea; //Field offset: 0x90
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	private List<AnimalType> _animalTypesToAllow; //Field offset: 0xA0
	[SerializeField]
	private bool _overrideThumb; //Field offset: 0xA8
	[SerializeField]
	private Sprite _sprite; //Field offset: 0xB0
	private AnimalType _currentAnimalType; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC0

	public LevelCAAnimalBowlItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void PlayDrinkingSound() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

