namespace PWC.Level;

public abstract class LevelItemDragPositionHandlerBase : MonoBehaviour
{
	protected LevelItem _levelItem; //Field offset: 0x20

	protected LevelItemDragPositionHandlerBase() { }

	protected override void Awake() { }

	protected override void OnDestroy() { }

	protected abstract Vector2 OverrideDragPosition(Vector2 position) { }

}

