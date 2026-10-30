namespace Game.Level.ContextualAnimation;

public class LevelCAReporterMicrophoneItemHandler : LevelCAItemHandlerBase
{
	private const string TAKING_INTERVIEW_ANIMATION_NAME = "Taking_Interview"; //Field offset: 0x0
	private const string INTERVIEW_REACT_ANIMATION_NAME = "CA/Reporter/Talking_To_Reporter"; //Field offset: 0x0
	private LevelCharacter _reactCharacter; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAReporterMicrophoneItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void ReactToInterview(LevelCharacter currentCharacter) { }

	private void StopCharacterReactionIfNeeeded(string configAnimationName) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

