namespace Game.Level.ContextualAnimation;

public class LevelCAPilotHatClothingSpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const string prefabGuid = "b531a09c-17ee-4294-bcd9-a32d9fee7f30"; //Field offset: 0x0
	[SerializeField]
	private LevelClothingItem _clothingItem; //Field offset: 0x98
	private PDPrefab pdPrefabInstance; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAPilotHatClothingSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

