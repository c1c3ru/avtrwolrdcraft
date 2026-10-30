namespace Game.Level;

public class CurrentActiveAvatarHasNearbySpineTypeCondition : GenericConditionBase
{
	public float _radius; //Field offset: 0x10
	public List<SpineType> _spineTypesToCheck; //Field offset: 0x18

	public CurrentActiveAvatarHasNearbySpineTypeCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

