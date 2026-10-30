namespace Game.Level;

public class LevelStaticConditionsResolverWithHoldingAvatar : LevelStaticConditionsResolver
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x30

	public LevelStaticConditionsResolverWithHoldingAvatar() { }

	public virtual void OnConditionsCheck() { }

}

