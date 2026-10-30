namespace Game.Level.ContextualAnimation;

public class LevelCATemplatedItemCharacterChangeHairHandler : LevelCAItemCharacterChangeHairHandler
{
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0xB8
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0xC0
	[SerializeField]
	private string _skinName; //Field offset: 0xC8

	public LevelCATemplatedItemCharacterChangeHairHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

