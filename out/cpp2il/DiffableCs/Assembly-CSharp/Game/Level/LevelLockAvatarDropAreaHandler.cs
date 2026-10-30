namespace Game.Level;

public class LevelLockAvatarDropAreaHandler : MonoBehaviour
{
	private LevelDropArea _dropArea; //Field offset: 0x20
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x28

	public LevelLockAvatarDropAreaHandler() { }

	private void Awake() { }

	private bool BlockDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void Lock(DragDropItemBase item) { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void SetAvatarClothingLocked(ILevelAvatar avatar, bool isLocked) { }

	private void SetAvatarHandItemsLocked(ILevelAvatar avatar, bool isLocked) { }

	private void Unlock(DragDropItemBase item) { }

}

