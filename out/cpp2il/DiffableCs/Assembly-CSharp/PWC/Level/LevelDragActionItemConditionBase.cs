namespace PWC.Level;

public abstract class LevelDragActionItemConditionBase : MonoBehaviour
{
	protected LevelDragActionItemHandlerBase _dragActionItemHandle; //Field offset: 0x20

	protected LevelDragActionItemConditionBase() { }

	protected override void Awake() { }

	protected abstract void FilterTarget(ILevelConsumer target, ref bool canConsume) { }

	protected override void OnDestroy() { }

}

