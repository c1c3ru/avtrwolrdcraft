namespace Game.Level;

public abstract class LevelEventOnLabelDropAreaItemHandlerBase : MonoBehaviour
{
	[SerializeField]
	private bool _checkOnPostInit; //Field offset: 0x20
	public UnityEvent onDropAction; //Field offset: 0x28
	public UnityEvent onPickUp; //Field offset: 0x30
	protected LevelItem _levelItem; //Field offset: 0x38
	protected ILevelLabelHandler _iLabelHandler; //Field offset: 0x40
	private bool _isOnDropArea; //Field offset: 0x48

	protected LevelEventOnLabelDropAreaItemHandlerBase() { }

	protected override void Awake() { }

	protected abstract ILevelLabelHandler GetLabelHandler() { }

	private bool IsConditionMet(LevelDropArea dropArea) { }

	private void OnBeginDrag(DragDropItemBase dropItemBase, PointerEventData eventData) { }

	protected override void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnPostInit() { }

}

