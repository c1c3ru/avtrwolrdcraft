namespace Game.Level.ContextualAnimation;

public class LevelCACandleItemHandler : LevelCAItemHandlerBase
{
	private const string CANDLE_BLOW_OUT_ANIMATION_NAME = "Candle_Blow_Out"; //Field offset: 0x0
	[SerializeField]
	private LevelLight _candle; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCACandleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

