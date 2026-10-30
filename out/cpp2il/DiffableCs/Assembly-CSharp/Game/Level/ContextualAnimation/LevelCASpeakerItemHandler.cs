namespace Game.Level.ContextualAnimation;

public class LevelCASpeakerItemHandler : LevelCAItemHandlerBase
{
	private const string ENJOING_MUSIC_ANIMATION_NAME = "Enjoying_Music"; //Field offset: 0x0
	private const string VIBING_ANIMATION_NAME = "Vibing_With_Speaker"; //Field offset: 0x0
	private const string TAP_ANIMATION_NAME = "Tap_And_Listen"; //Field offset: 0x0
	private const string TAP_DANCE_ANIMATION_NAME = "Tap_And_Listen_Dance"; //Field offset: 0x0
	[SerializeField]
	private LevelToggleableAudioItemHandler _soundMaker; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCASpeakerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

