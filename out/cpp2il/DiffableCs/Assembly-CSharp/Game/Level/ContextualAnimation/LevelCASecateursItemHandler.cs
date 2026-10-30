namespace Game.Level.ContextualAnimation;

public class LevelCASecateursItemHandler : LevelCADropAreaHandlerWithData
{
	private const string OPEN_EVENT = "Change_Object_State_Open"; //Field offset: 0x0
	private const string CLOSE_EVENT = "Change_Object_State_Closed"; //Field offset: 0x0
	private const string CRAFT_EVENT = "Trigger_Reaction"; //Field offset: 0x0
	private const string OPEN_SOUND = "Secateurs_Open"; //Field offset: 0x0
	private const string CLOSE_SOUND = "Secateurs_Close"; //Field offset: 0x0
	[SerializeField]
	private LevelToggleableSprite _bush; //Field offset: 0x98
	[SerializeField]
	private string _label; //Field offset: 0xA0
	[SerializeField]
	private GameSoundPlayer _soundPlayerForSecateurs; //Field offset: 0xA8
	[SerializeField]
	private ParticleSystem _particles; //Field offset: 0xB0
	private LevelCharacter _character; //Field offset: 0xB8
	private LevelToggleableSprite _secateurs; //Field offset: 0xC0
	private int _currentPlayingIndex; //Field offset: 0xC8

	public LevelCASecateursItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnBeforeDetachFromParentAction(LevelItem levelItem, Transform transform) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void ToggleSprite(LevelToggleableSprite toggleableSprite, int index) { }

}

