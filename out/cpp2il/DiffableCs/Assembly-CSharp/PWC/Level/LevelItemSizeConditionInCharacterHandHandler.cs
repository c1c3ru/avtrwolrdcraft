namespace PWC.Level;

public class LevelItemSizeConditionInCharacterHandHandler : MonoBehaviour
{
	private const float MAX_SIZE = 2; //Field offset: 0x0
	private LevelCharacter _sitCharacter; //Field offset: 0x20
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x28

	public LevelItemSizeConditionInCharacterHandHandler() { }

	private void Awake() { }

	private bool CanHoldLevelItem(LevelItem levelItem) { }

	private void FreeItemFromCharacter(LevelItem levelItem) { }

	private void OnAvatarBeginDrop(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnPutItemInCharacterBone(LevelItem levelItem) { }

}

