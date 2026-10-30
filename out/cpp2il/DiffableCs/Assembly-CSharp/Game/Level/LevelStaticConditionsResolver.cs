namespace Game.Level;

public class LevelStaticConditionsResolver : ConditionResolverComponent
{
	[SerializeField]
	public UnityEvent onConditionsMet; //Field offset: 0x28

	public LevelStaticConditionsResolver() { }

	public override void OnConditionsCheck() { }

}

