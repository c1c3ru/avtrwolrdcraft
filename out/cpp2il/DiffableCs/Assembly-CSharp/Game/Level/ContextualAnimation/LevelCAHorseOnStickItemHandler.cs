namespace Game.Level.ContextualAnimation;

public class LevelCAHorseOnStickItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x98
	[SerializeField]
	private string _skinName; //Field offset: 0xA0

	public LevelCAHorseOnStickItemHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

