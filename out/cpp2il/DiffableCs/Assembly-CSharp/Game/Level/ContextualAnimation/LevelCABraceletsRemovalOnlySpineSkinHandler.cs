namespace Game.Level.ContextualAnimation;

public class LevelCABraceletsRemovalOnlySpineSkinHandler : LevelCASpineSkinHandlerBase
{
	private const string DISPLAY_BRACELET_ANIMATION = "Display_Bracelet"; //Field offset: 0x0
	private const string REMOVE_BRACELET_ANIMATION = "Remove_Bracelets"; //Field offset: 0x0
	public static Action<List`1<LevelCharacter>> CharactersCloseWhenDisplayingBraceletAction; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABraceletsRemovalOnlySpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	private List<LevelCharacter> GetCloseCharacters() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual bool IsSilent() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOffBracelet(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

