namespace Game.Level.ContextualAnimation;

public class LevelCADropAreaForAnimalsHandlerWithData : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private bool _allowAllSpineTypes; //Field offset: 0x94
	[SerializeField]
	private List<SpineType> _allowedSpineTypes; //Field offset: 0x98
	private SpineType _currentType; //Field offset: 0xA0

	public LevelCADropAreaForAnimalsHandlerWithData() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

}

