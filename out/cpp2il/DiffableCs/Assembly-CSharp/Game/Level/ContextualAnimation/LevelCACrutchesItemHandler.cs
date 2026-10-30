namespace Game.Level.ContextualAnimation;

public class LevelCACrutchesItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x98
	[SerializeField]
	private string _skinName; //Field offset: 0xA0
	private LevelCharacter _levelCharacter; //Field offset: 0xA8

	public LevelCACrutchesItemHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private bool OverrideCharacterPlayProperIdleAnimation() { }

}

