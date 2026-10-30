namespace PWC.Level;

public abstract class LevelConsumerAreaConditionBase : MonoBehaviour
{
	protected LevelConsumerAreaBase _consumerArea; //Field offset: 0x20

	protected LevelConsumerAreaConditionBase() { }

	protected override void Awake() { }

	protected abstract void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	protected override void OnDestroy() { }

}

