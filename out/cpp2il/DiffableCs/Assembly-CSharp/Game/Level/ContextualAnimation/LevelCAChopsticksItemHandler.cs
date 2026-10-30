namespace Game.Level.ContextualAnimation;

public class LevelCAChopsticksItemHandler : LevelCAItemHandlerWithData
{
	private const string EVENT_NAME_FOR_ADDING_SKIN = "Add_Skin"; //Field offset: 0x0
	private const string EVENT_NAME_FOR_REMOVING_SKIN = "Remove_Skin"; //Field offset: 0x0
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x98
	[SerializeField]
	private string _skinName; //Field offset: 0xA0
	private List<Skin> _skins; //Field offset: 0xA8
	private bool _canAddSkin; //Field offset: 0xB0
	private bool _canRemoveSkin; //Field offset: 0xB1

	public LevelCAChopsticksItemHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

