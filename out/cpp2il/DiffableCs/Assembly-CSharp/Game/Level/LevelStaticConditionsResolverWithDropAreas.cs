namespace Game.Level;

public class LevelStaticConditionsResolverWithDropAreas : LevelStaticConditionsResolver
{
	[SerializeField]
	private List<LevelConsumerAreaBase> _areas; //Field offset: 0x30

	public LevelStaticConditionsResolverWithDropAreas() { }

	public virtual void OnConditionsCheck() { }

}

