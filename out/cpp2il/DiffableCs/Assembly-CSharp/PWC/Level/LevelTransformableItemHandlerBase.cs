namespace PWC.Level;

public abstract class LevelTransformableItemHandlerBase : LevelTransformableObjectHandlerBase
{
	[SerializeField]
	private bool _dontRestoreOnSceneLoad; //Field offset: 0x79
	protected LevelItem _levelItem; //Field offset: 0x80

	protected LevelTransformableItemHandlerBase() { }

	protected virtual void Awake() { }

	protected virtual bool CanBeClicked() { }

	protected virtual void DestroySelf() { }

	public bool GetDontRestoreOnSceneLoad() { }

	protected virtual int GetSortingOrder() { }

}

